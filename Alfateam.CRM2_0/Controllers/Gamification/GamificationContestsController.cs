using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Gamification.Contests;
using Alfateam.CRM2_0.Models.ClientModels.Gamification.Shop;
using Alfateam.CRM2_0.Models.CreateModels.Gamification.Contests;
using Alfateam.CRM2_0.Models.CreateModels.Gamification.Shop;
using Alfateam.CRM2_0.Models.EditModels.Gamification.Contests;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Gamification.Contests;
using Alfateam.CRM2_0.Models.Gamification.Shop;
using Alfateam.Website.API.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Alfateam.CRM2_0.Controllers.Gamification
{
    public class GamificationContestsController : AbsGamificationController
    {
        public GamificationContestsController(ControllerParams @params) : base(@params)
        {
        }

        #region Конкурсы

        [HttpGet, Route("GetContests")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetContests(int offset, int count = 20)
        {
            var queryable = DB.Contests.Include(o => o.Result)
                                       .Where(o => o.GamificationModelId == this.GetGamificationId());

            return DBService.GetMany<Contest, ContestClientModel>(queryable, offset, count);
        }

        [HttpGet, Route("GetContest")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetContest(int id)
        {
            var contest = DB.Contests.Include(o => o.Result)
                                     .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContest(contest),
                () => RequestResult<Contest>.AsSuccess(contest)
            });
        }




        [HttpPost, Route("CreateContest")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> CreateContest(ContestCreateModel model)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => DBService.TryCreateModel(DB.Contests, model, (item) =>
                {

                    var checkBase = CheckContestDates(item);
                    if (!checkBase.Success)
                    {
                        return checkBase;
                    }


                    var imgUploadResult = FileService.TryUploadFile("imgPath", Enums.FileType.Image).Result;
                    if (!imgUploadResult.Success)
                    {
                        return imgUploadResult;
                    }
                    item.ImagePath = imgUploadResult.Value;

                    item.GamificationModelId = (int)this.GetGamificationId();
                    return RequestResult<Contest>.AsSuccess(item);
                })
            });
        }

        [HttpPut, Route("UpdateContest")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> UpdateContest(ContestEditModel model)
        {
            var contest = DB.Contests.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContestToEdit(contest),
                () => CheckContestDates(contest),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    if(Request.Form.Files.Any(o => o.Name == "imgPath"))
                    {
                        var imgUploadResult = FileService.TryUploadFile("imgPath", Enums.FileType.Image).Result;
                        if (!imgUploadResult.Success)
                        {
                            return imgUploadResult;
                        }
                        contest.ImagePath = imgUploadResult.Value;
                    }

                    return DBService.UpdateModel(DB.Contests, contest, model);
                }
            });

        }

        [HttpDelete, Route("DeleteContest")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> DeleteContest(int id)
        {
            var contest = DB.Contests.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContestToEdit(contest),
                () => DBService.DeleteModel(DB.Contests, contest)
            });
        }

        #endregion

        #region Призовые места

        [HttpGet, Route("GetContestPlacesModels")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetContestPlacesModels(int id)
        {
            var contest = DB.Contests.Include(o => o.Places).ThenInclude(o => o.Prize)
                                     .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContest(contest),
                () =>
                {
                    var clientModels = ContestPlacesClientModel.CreateItems(contest.Places.Where(o => !o.IsDeleted));
                    return RequestResult<IEnumerable<ContestPlacesClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetContestPlacesModel")]
        [AccessActionFilter(roles: new[] { UserRole.Employee })]
        public async Task<RequestResult> GetContestPlacesModel(int contestId, int placesId)
        {
            var contest = DB.Contests.FirstOrDefault(o => o.Id == contestId && !o.IsDeleted);
            var places = DB.ContestPlaces.FirstOrDefault(o => o.Id == placesId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContestAndPlaces(contest, places),
                () =>
                {
                    var clientModel = ContestPlacesClientModel.Create(places);
                    return RequestResult<ContestPlacesClientModel>.AsSuccess(clientModels);
                }
            });
        }






        [HttpPost, Route("CreateContestPlacesModel")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> CreateContestPlacesModel(int contestId, ContestPlacesCreateModel model)
        {
            var contest = DB.Contests.Include(o => o.Places)
                                     .FirstOrDefault(o => o.Id == contestId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContest(contest),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var places = model.Create();

                    var checkResult = CheckContestPlaces(contest,places);
                    if(!checkResult.Success)
                    {
                        return checkResult;
                    }
                   

                    contest.Places.Add(places);
                    DBService.UpdateModel(DB.Contests, contest);
                    return RequestResult<ContestPlaces>.AsSuccess(places);
                }
            });
        }

        [HttpPut, Route("UpdateContestPlacesModel")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> UpdateContestPlacesModel(int contestId, ContestPlacesEditModel model)
        {
            var contest = DB.Contests.Include(o => o.Places)
                                 .FirstOrDefault(o => o.Id == contestId && !o.IsDeleted);

            var places = DB.ContestPlaces.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContestAndPlacesToEdit(contest, places),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    model.Fill(places);

                    var checkResult = CheckContestPlaces(contest,places);
                    if(!checkResult.Success)
                    {
                        return checkResult;
                    }

                    return DBService.UpdateModel(DB.ContestPlaces, places);
                }
            });
        }

        [HttpDelete, Route("DeleteContestPlacesModel")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> DeleteContestPlacesModel(int contestId, int placesId)
        {
            var contest = DB.Contests.FirstOrDefault(o => o.Id == contestId && !o.IsDeleted);
            var places = DB.ContestPlaces.FirstOrDefault(o => o.Id == placesId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContestAndPlacesToEdit(contest, places),
                () => DBService.DeleteModel(DB.ContestPlaces, places)
            });
        }

        #endregion

        #region Результат конкурса

        [HttpPut, Route("SetContestResult")]
        [AccessActionFilter(roles: new[] { UserRole.President, UserRole.TopManager, UserRole.PartnerOrganigationDirector, UserRole.PartnerOrganigationTopManager })]
        public async Task<RequestResult> SetContestResult(int contestId, ContestResultCreateModel model)
        {
            var contest = DB.Contests.Include(o => o.Places)
                                     .FirstOrDefault(o => o.Id == contestId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContestToEdit(contest),
                () =>
                {
                    int placesCount = contest.Places.Where(o => !o.IsDeleted).Max(o => o.GetLastPlace());
                    if(placesCount != model.Winners.Count)
                    {
                        return RequestResult.AsError(400, "Кол-во победителей должно быть равно количеству мест");
                    }

                    for(int i =1; i < placesCount + 1; i++)
                    {
                        var winner = model.Winners.FirstOrDefault(o => o.Place == i);
                        if(winner == null)
                        {
                            return RequestResult.AsError(400, $"Не выбран победитель на {i} место");
                        }

                        var winnerUser = DB.Users.FirstOrDefault(o => o.Id == winner.UserId && !o.IsDeleted);
                        if(winnerUser == null)
                        {
                            return RequestResult.AsError(400, $"Пользователь с id={winner.UserId} не найден");
                        }
                        else if(winnerUser.BusinessId != this.BusinessId)
                        {
                            return RequestResult.AsError(403, $"Нет доступа к пользователю с id={winner.UserId}");
                        }
                    }

                    contest.Result = model.Create();
                    DBService.UpdateModel(DB.Contests, contest);

                    return RequestResult<ContestResult>.AsSuccess(contest.Result);
                }
            });
        }

        #endregion







        #region Private check methods

        private RequestResult CheckBaseContest(Contest contest)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(contest != null,404,"Конкурс с данным id не найден"),
                () => RequestResult.FromBoolean(contest.GamificationModelId == this.GetGamificationId(),403,"Нет доступа к данному конкурсу"),
            });
        }
        private RequestResult CheckBaseContestToEdit(Contest contest)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContest(contest),
                () => RequestResult.FromBoolean(contest.ResultId == null, 403, "Редактирование завершенного конкурса невозможно"),
            });
        }



        private RequestResult CheckBaseContestAndPlaces(Contest contest, ContestPlaces places)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContest(contest),
                () => RequestResult.FromBoolean(places != null,404,"Призовые места с данным id не найдены"),
                () => RequestResult.FromBoolean(places.ContestId == contest.Id,403,"Призовые места не принадлежат данному конкурсу"),
            });
        }
        private RequestResult CheckBaseContestAndPlacesToEdit(Contest contest, ContestPlaces places)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseContestAndPlaces(contest, places),
                () => RequestResult.FromBoolean(contest.ResultId == null, 403, "Редактирование завершенного конкурса невозможно"),
            });
        }




        private RequestResult CheckContestDates(Contest model)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(model.StartDate <= model.EndDate, 400, "Дата начала не может быть позже даты завершения"),
                () => RequestResult.FromBoolean(model.StartDate >= DateTime.UtcNow, 400, "Дата начала не может быть раньше сегодняшнего момента"),
                () => RequestResult.FromBoolean(model.EndDate >= DateTime.UtcNow, 400, "Дата завершения не может быть раньше сегодняшнего момента"),
            });
        }
        private RequestResult CheckContestPlaces(Contest contest, ContestPlaces places)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(places.ArePlacesCorrect(),400, "Неверно расставлены места"),
                () =>
                {
                    int lastPlace = contest.Places.Where(o => !o.IsDeleted).Max(o => o.GetLastPlace());
                    if(lastPlace +1 != places.FirstValue)
                    {
                        return RequestResult.AsError(400, $"Места должны начинаться с {lastPlace +1}");
                    }
                    return RequestResult.AsSuccess();
                }
            });
        }

        #endregion
    }
}
