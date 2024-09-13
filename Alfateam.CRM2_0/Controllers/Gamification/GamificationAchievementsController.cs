using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.CreateModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.EditModels.Gamification.Achievements;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Gamification.Achievements;
using Alfateam.CRM2_0.Models.Gamification.Events;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Alfateam.CRM2_0.Controllers.Gamification
{
    [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
    public class GamificationAchievementsController : AbsGamificationController
    {
        public GamificationAchievementsController(ControllerParams @params) : base(@params)
        {
        }

        #region Достижения

        [HttpGet, Route("GetAchievements")]
        public async Task<RequestResult> GetAchievements(int offset, int count = 20)
        {
            var queryable = DB.Achievements.Include(o => o.Category)
                                           .Where(o => o.GamificationModelId == this.GetGamificationId());

            return DBService.GetMany<Achievement, AchievementClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetAchievement")]
        public async Task<RequestResult> GetAchievement(int id)
        {
            var achievement = DB.Achievements.Include(o => o.Category)
                                             .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAchievement(achievement),
                () => RequestResult<Achievement>.AsSuccess(achievement)
            });
        }




        [HttpPost, Route("CreateAchievement")]
        public async Task<RequestResult> CreateAchievement(AchievementCreateModel model)
        {
            var category = DB.AchievementCategories.FirstOrDefault(o => o.Id == model.CategoryId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAchievementCategory(category),
                () => DBService.TryCreateModel(DB.Achievements, model, (item) =>
                {
                    var imgUploadResult = FileService.TryUploadFile("imgPath", Enums.FileType.Image).Result;
                    if (!imgUploadResult.Success)
                    {
                        return imgUploadResult;
                    }
                    item.ImagePath = imgUploadResult.Value;

                    item.GamificationModelId = (int)this.GetGamificationId();
                    return RequestResult<Achievement>.AsSuccess(item);
                })
            });
        }

        [HttpPut, Route("UpdateAchievement")]
        public async Task<RequestResult> UpdateAchievement(AchievementEditModel model)
        {
            var achievement = DB.Achievements.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var category = DB.AchievementCategories.FirstOrDefault(o => o.Id == model.CategoryId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAchievement(achievement),
                () => CheckBaseAchievementCategory(category),
                () =>
                {
                    if(Request.Form.Files.Any(o => o.Name == "imgPath"))
                    {
                        var imgUploadResult = FileService.TryUploadFile("imgPath",Enums.FileType.Image).Result;
                        if (!imgUploadResult.Success)
                        {
                            return imgUploadResult;
                        }
                        achievement.ImagePath = imgUploadResult.Value;
                    }
                    return DBService.TryUpdateModel(DB.Achievements, achievement, model);
                }
            });
        }

        [HttpDelete, Route("DeleteAchievement")]
        public async Task<RequestResult> DeleteAchievement(int id)
        {
            var achievement = DB.Achievements.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAchievement(achievement),
                () => DBService.DeleteModel(DB.Achievements, achievement)
            });
        }

        #endregion

        #region Категории достижений

        [HttpGet, Route("GetAchievementCategories")]
        public async Task<RequestResult> GetAchievementCategories(int offset, int count = 20)
        {
            var queryable = DB.AchievementCategories.Where(o => o.GamificationModelId == this.GetGamificationId());
            return DBService.GetMany<AchievementCategory, AchievementCategoryClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetAchievementCategory")]
        public async Task<RequestResult> GetAchievementCategory(int id)
        {
            var category = DB.AchievementCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAchievementCategory(category),
                () => RequestResult<AchievementCategory>.AsSuccess(category)
            });
        }



        [HttpPost, Route("CreateAchievementCategory")]
        public async Task<RequestResult> CreateAchievementCategory(AchievementCategoryCreateModel model)
        {
            return DBService.TryCreateModel(DB.AchievementCategories, model, (item) =>
            {
                item.GamificationModelId = (int)this.GetGamificationId();
                return RequestResult<AchievementCategory>.AsSuccess(item);
            });
        }

        [HttpPut, Route("UpdateAchievementCategory")]
        public async Task<RequestResult> UpdateAchievementCategory(AchievementCategoryEditModel model)
        {
            var category = DB.AchievementCategories.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAchievementCategory(category),
                () => DBService.TryUpdateModel(DB.AchievementCategories, category, model)
            });
        }

        [HttpDelete, Route("DeleteAchievementCategory")]
        public async Task<RequestResult> DeleteAchievementCategory(int id)
        {
            var category = DB.AchievementCategories.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAchievementCategory(category),
                () => DBService.DeleteModel(DB.AchievementCategories, category)
            });
        }

        #endregion



        [HttpPut, Route("AssignAchievementToUser")]
        public async Task<RequestResult> AssignAchievementToUser(int achievementId, int userId)
        {
            var achievement = DB.Achievements.FirstOrDefault(o => o.Id == achievementId && !o.IsDeleted);

            var user = DB.Users.Include(o => o.GamificationUser).ThenInclude(o => o.Achievements)
                               .Include(o => o.GamificationUser).ThenInclude(o => o.Data)
                               .FirstOrDefault(o => o.Id == userId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseAchievement(achievement),
                () => RequestResult.FromBoolean(user != null, 400, $"Пользователь с id={userId} не найден"),
                () => RequestResult.FromBoolean(user.BusinessId == this.BusinessId,403, $"Нет доступа к пользователю с id={userId}"),
                () => RequestResult.FromBoolean(!user.GamificationUser.Achievements.Any(o => o.AchievementId == achievementId)
                                                                                ,400, $"Данное достижение уже было назначено пользователю"),
                () =>
                {
                    user.GamificationUser.Achievements.Add(new Models.Gamification.Data.GamificationUserAchievement
                    {
                        AchievementId = achievementId,
                    });
                    user.GamificationUser.Data.Coins += achievement.Reward;
                    user.GamificationUser.Data.Rating += achievement.Rating;

                    user.GamificationUser.Events.Add(new AchievementGamificationEvent
                    {
                        Achievement = achievement,
                        Title = achievement.Title,
                        Karma = achievement.Rating,
                        Coins = achievement.Reward,
                    });

                    DBService.UpdateModel(DB.Users, user);
                    return RequestResult.AsSuccess();
                }
            });
        }








        #region Private check methods

        private RequestResult CheckBaseAchievement(Achievement achievement)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(achievement != null,404,"Достижение с данным id не найдена"),
                () => RequestResult.FromBoolean(achievement.GamificationModelId == this.GetGamificationId(),403,"Нет доступа к данному достижению"),
            });
        }
        private RequestResult CheckBaseAchievementCategory(AchievementCategory category)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(category != null,404,"Категория с данным id не найдена"),
                () => RequestResult.FromBoolean(category.GamificationModelId == this.GetGamificationId(),403,"Нет доступа к данной категории"),
            });
        }

        #endregion
    }
}
