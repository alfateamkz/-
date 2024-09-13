using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.ClientModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.ClientModels.Gamification.General;
using Alfateam.CRM2_0.Models.CreateModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.CreateModels.Gamification.General;
using Alfateam.CRM2_0.Models.EditModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.EditModels.Gamification.General;
using Alfateam.CRM2_0.Models.Gamification.Achievements;
using Alfateam.CRM2_0.Models.Gamification.Contests;
using Alfateam.CRM2_0.Models.Gamification.Events;
using Alfateam.CRM2_0.Models.Gamification.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Alfateam.CRM2_0.Controllers.Gamification
{
    public class GamificationLevelsController : AbsGamificationController
    {
        public GamificationLevelsController(ControllerParams @params) : base(@params)
        {
        }



        #region Уровни

        [HttpGet, Route("GetLevels")]
        public async Task<RequestResult> GetLevels(int offset, int count = 20)
        {
            var queryable = DB.Levels.Where(o => o.GamificationModelId == this.GetGamificationId());
            return DBService.GetMany<Level, LevelClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetLevel")]
        public async Task<RequestResult> GetLevel(int id)
        {
            var level = DB.Levels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevel(level),
                () => RequestResult<Level>.AsSuccess(level)
            });
        }





        [HttpPost, Route("CreateLevel")]
        public async Task<RequestResult> CreateLevel(LevelCreateModel model)
        {
            return DBService.TryCreateModel(DB.Levels, model, (item) =>
            {
                var fileUploadResult = FileService.TryUploadFile("img", Enums.FileType.Image).Result;
                if (!fileUploadResult.Success)
                {
                    return fileUploadResult;
                }

                var gamificationId = this.GetGamificationId();
                var lastNumber = DB.Levels.Where(o => o.GamificationModelId == gamificationId && !o.IsDeleted).Max(o => o.Number);


                item.ImagePath = fileUploadResult.Value;
                item.GamificationModelId = (int)this.GetGamificationId();
                item.Number = lastNumber + 1;
                return RequestResult<Level>.AsSuccess(item);
            });
        }

        [HttpPut, Route("UpdateLevel")]
        public async Task<RequestResult> UpdateLevel(LevelEditModel model)
        {
            var level = DB.Levels.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevel(level),
                () =>
                {

                    if(Request.Form.Files.Any(o => o.Name == "img"))
                    {
                        var fileUploadResult = FileService.TryUploadFile("img", Enums.FileType.Image).Result;
                        if (!fileUploadResult.Success)
                        {
                            return fileUploadResult;
                        }

                        level.ImagePath = fileUploadResult.Value;
                    }

                    return DBService.UpdateModel(DB.Levels, level);
                }
            });
        }

        [HttpDelete, Route("DeleteLevel")]
        public async Task<RequestResult> DeleteLevel(int id)
        {
            var level = DB.Levels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevel(level),
                () => DBService.DeleteModel(DB.Levels, level)
            });
        }


        #endregion

        #region Критерии перехода на уровень

        [HttpGet, Route("GetLevelCriterias")]
        public async Task<RequestResult> GetLevelCriterias(int levelId)
        {
            var level = DB.Levels.Include(o => o.Criterias)
                                 .FirstOrDefault(o => o.Id == levelId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevel(level),
                () =>
                {
                    var clientModels = LevelCriteriaClientModel.CreateItems(level.Criterias.Where(o => !o.IsDeleted));
                    return RequestResult<IEnumerable<LevelCriteriaClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetLevelCriteria")]
        public async Task<RequestResult> GetLevelCriteria(int levelId, int criteriaId)
        {
            var level = DB.Levels.FirstOrDefault(o => o.Id == levelId && !o.IsDeleted);
            var criteria = DB.LevelCriterias.FirstOrDefault(o => o.Id == criteriaId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevelAndCriteria(level, criteria),
                () =>
                {
                    var clientModel = LevelCriteriaClientModel.Create(criteria);
                    return RequestResult<LevelCriteriaClientModel>.AsSuccess(clientModel);
                }
            });
        }






        [HttpPost, Route("CreateLevelCriteria")]
        public async Task<RequestResult> CreateLevelCriteria(int levelId, LevelCriteriaCreateModel model)
        {
            var level = DB.Levels.FirstOrDefault(o => o.Id == levelId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevel(level),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var criteria = model.Create();
                    level.Criterias.Add(criteria);

                    DBService.UpdateModel(DB.Levels, level);


                    var users = DB.Users.Include(o => o.GamificationUser).ThenInclude(o => o.LevelInfo)
                                        .Where(o => o.GamificationUser.LevelInfo.LevelId == levelId);
                    foreach(var user in users)
                    {
                        user.GamificationUser.LevelInfo.RequirementInfos.Add(new Models.Gamification.Data.UserLevelCriteriaInfo
                        {
                            Criteria = criteria,
                        });
                    }

                    if (users.Any())
                    {
                        DB.UpdateRange(users);
                        DB.SaveChanges();
                    }  

                    return RequestResult<LevelCriteria>.AsSuccess(criteria);
                }
            });
        }

        [HttpPut, Route("UpdateLevelCriteria")]
        public async Task<RequestResult> UpdateLevelCriteria(int levelId, LevelCriteriaEditModel model)
        {
            var level = DB.Levels.FirstOrDefault(o => o.Id == levelId && !o.IsDeleted);
            var criteria = DB.LevelCriterias.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevelAndCriteria(level, criteria),
                () => DBService.UpdateModel(DB.LevelCriterias, criteria),
            });
        }

        [HttpDelete, Route("DeleteLevelCriteria")]
        public async Task<RequestResult> DeleteLevelCriteria(int levelId, int criteriaId)
        {
            var level = DB.Levels.FirstOrDefault(o => o.Id == levelId && !o.IsDeleted);
            var criteria = DB.LevelCriterias.FirstOrDefault(o => o.Id == criteriaId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevelAndCriteria(level, criteria),
                () => DBService.DeleteModel(DB.LevelCriterias, criteria),
            });
        }



        #endregion

        #region Награда за переход на уровень

        [HttpGet, Route("GetLevelReward")]
        public async Task<RequestResult> GetLevelReward(int id)
        {
            var level = DB.Levels.Include(o => o.Reward)
                                 .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevel(level),
                () => RequestResult<LevelReward>.AsSuccess(level.Reward)
            });
        }

        [HttpGet, Route("SetLevelReward")]
        public async Task<RequestResult> SetLevelReward(int id, LevelRewardEditModel model)
        {
            var level = DB.Levels.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var reward = DB.LevelRewards.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevelAndReward(level, reward),
                () => DBService.TryUpdateModel(DB.LevelRewards, reward, model)
            });
        }

        #endregion



        [HttpPut, Route("SetLevelCriteriaStatus")]
        public async Task<RequestResult> SetLevelCriteriaStatus(int criteriaId, int userId, bool isCompleted)
        {
            var criteria = DB.LevelCriterias.FirstOrDefault(o => o.Id == criteriaId && !o.IsDeleted);

            var user = DB.Users.Include(o => o.GamificationUser).ThenInclude(o => o.LevelInfo).ThenInclude(o => o.RequirementInfos)
                               .Include(o => o.GamificationUser).ThenInclude(o => o.Data)
                               .FirstOrDefault(o => o.Id == userId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(criteria != null,404,"Критерий перехода с данным id не найден"),
                () => RequestResult.FromBoolean(user != null, 400, $"Пользователь с id={userId} не найден"),
                () => RequestResult.FromBoolean(user.BusinessId == this.BusinessId,403, $"Нет доступа к пользователю с id={userId}"),
                () =>
                {
                    var userCriteria = user.GamificationUser.LevelInfo.RequirementInfos.FirstOrDefault(o => o.CriteriaId == criteriaId);
                    userCriteria.IsCompleted = isCompleted;
                    DBService.UpdateModel(DB.UserLevelCriteriaInfos, userCriteria);



                    double coins = 0;
                    double karma = 0;
                    string title = "";

                    if (isCompleted)
                    {
                        coins = criteria.Coins;
                        karma= criteria.Rating;
                        title = $"Выполнен критерий перехода {criteria.Title}";
                    }
                    else
                    {
                        coins = -criteria.Coins;
                        karma = -criteria.Rating;
                        title = $"Отмена выполнения критерия перехода {criteria.Title}";
                    }


                    user.GamificationUser.Data.Coins += coins;
                    user.GamificationUser.Data.Rating += karma;
                    user.GamificationUser.Events.Add(new LevelCriteriaGamificationEvent
                    {
                        Criteria = userCriteria.CriteriaId,
                        Coins = coins,
                        Karma= karma,
                        Title = title
                    });


                    return RequestResult.AsSuccess();
                }
            });
        }

        [HttpPut, Route("SetLevelUp")]
        public async Task<RequestResult> SetLevelUp(int userId)
        {
            var user = DB.Users.Include(o => o.GamificationUser).ThenInclude(o => o.LevelInfo).ThenInclude(o => o.RequirementInfos).ThenInclude(o => o.Criteria)
                               .Include(o => o.GamificationUser).ThenInclude(o => o.LevelInfo).ThenInclude(o => o.Level)
                               .Include(o => o.GamificationUser).ThenInclude(o => o.Data)
                               .FirstOrDefault(o => o.Id == userId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(user != null, 400, $"Пользователь с id={userId} не найден"),
                () => RequestResult.FromBoolean(user.BusinessId == this.BusinessId,403, $"Нет доступа к пользователю с id={userId}"),
                () =>
                {
                    var isLevelUpAvailable = user.GamificationUser.LevelInfo.RequirementInfos.Where(o => !o.Criteria.IsDeleted).All(o => o.IsCompleted);
                    if (!isLevelUpAvailable)
                    {
                        return RequestResult.AsError(403, $"Повышение уровня недоступно, не все критерии выполнены");
                    }

                    var nextLevel = DB.Levels.Include(o => o.Reward)
                                             .FirstOrDefault(o => o.GamificationModelId == GetGamificationId()
                                                               && !o.IsDeleted
                                                               && o.Number == user.GamificationUser.LevelInfo.Level.Number + 1);
                    if(nextLevel == null)
                    {
                        return RequestResult.AsError(400, $"Повышение невозможно. Достигнут максимальный уровень");
                    }

                    user.GamificationUser.LevelInfo.Level = nextLevel;
                    user.GamificationUser.Data.Coins += nextLevel.Reward.Coins;
                    user.GamificationUser.Data.Rating += nextLevel.Reward.Rating;

                    user.GamificationUser.Events.Add(new LevelGamificationEvent
                    {
                        NewLevel = nextLevel,
                        Coins =  nextLevel.Reward.Coins,
                        Karma = nextLevel.Reward.Rating,
                        Title = $"Переход на уровень {nextLevel.Title}"
                    });

                    user.GamificationUser.LevelInfo.RequirementInfos.Clear();
                    foreach(var criteria in nextLevel.Criterias.Where(o => !o.IsDeleted))
                    {
                        user.GamificationUser.LevelInfo.RequirementInfos.Add(new Models.Gamification.Data.UserLevelCriteriaInfo
                        {
                            CriteriaId = criteria.Id
                        });
                    }

                    DBService.UpdateModel(DB.Users, user);
                }
            });
        }





        #region Private check methods

        private RequestResult CheckBaseLevel(Level level)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(level != null,404,"Уровень с данным id не найден"),
                () => RequestResult.FromBoolean(level.GamificationModelId == this.GetGamificationId(),403,"Нет доступа к данному уровню"),
            });
        }
        private RequestResult CheckBaseLevelAndReward(Level level, LevelReward reward)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevel(level),
                () => RequestResult.FromBoolean(reward != null,404,"Награда с данным id не найдена"),
                () => RequestResult.FromBoolean(reward.LevelId == level.Id,403, "Награда не принадлежит текущему уровню"),
            });
        }
        private RequestResult CheckBaseLevelAndCriteria(Level level, LevelCriteria criteria)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseLevel(level),
                () => RequestResult.FromBoolean(criteria != null,404,"Критерий перехода с данным id не найден"),
                () => RequestResult.FromBoolean(criteria.LevelId == level.Id,403, "Критерий перехода не принадлежит текущему уровню"),
            });
        }

        #endregion

    }
}
