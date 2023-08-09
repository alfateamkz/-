using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Portfolios;
using Alfateam.Website.API.Models.ClientModels.Team;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels;
using Alfateam.Website.API.Models.EditModels.General;
using Alfateam.Website.API.Models.EditModels.Team;
using Alfateam.Website.API.Models.LocalizationEditModels.Events;
using Alfateam.Website.API.Models.LocalizationEditModels.Team;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.Team;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Team;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminTeamController : AbsAdminController
    {

        public AdminTeamController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {

        }

        #region Структуры команд


        [HttpGet, Route("GetTeamStructures")]
        public async Task<RequestResult<IEnumerable<TeamStructureClientModel>>> GetTeamStructures(int offset, int count = 20)
        {
            var res = new RequestResult<IEnumerable<TeamStructureClientModel>>();

            var tryGetManyResponse = TryGetMany(GetTeamStructuresList(), ContentAccessModelType.Team, offset, count);
            if (!tryGetManyResponse.Success)
            {
                return res.FillFromRequestResult(tryGetManyResponse);
            }

            var models = TeamStructureClientModel.CreateItems(tryGetManyResponse.Value.ToList(), LanguageId);
            return res.SetSuccess(models);
        }

        [HttpGet, Route("GetTeamStructure")]
        public async Task<RequestResult<TeamStructure>> GetTeamStructure(int id)
        {
            return TryGetOne(GetTeamStructuresFullIncludedList(), id, ContentAccessModelType.Team);
        }




        [HttpPost, Route("CreateTeamStructure")]
        public async Task<RequestResult<TeamStructure>> CreateTeamStructure(TeamStructure structure)
        {
            return TryCreate(DB.TeamStructures, structure, ContentAccessModelType.Team);
        }




        [HttpDelete, Route("DeleteTeamStructure")]
        public async Task<RequestResult> DeleteTeamStructure(int id)
        {
            var res = new RequestResult();

            var item = GetTeamStructuresList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            return TryDelete(DB.TeamStructures, item, ContentAccessModelType.Team);
        }


        #endregion

        #region Отдельные команды

        [HttpGet, Route("GetTeamGroup")]
        public async Task<RequestResult<TeamGroup>> GetTeamGroup(int id)
        {
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (group == null)
            {
                return RequestResult<TeamGroup>.AsError(404, "Сущность с данным id не найдена");
            }

            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetTeamStructuresList(), group.TeamStructureId, ContentAccessModelType.Team);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<TeamGroup>().FillFromRequestResult(checkAccessResult);
            }

            return RequestResult<TeamGroup>.AsSuccess(group);
        }

        [HttpGet, Route("GetTeamGroupLocalization")]
        public async Task<RequestResult<TeamGroupLocalization>> GetTeamGroupLocalization(int id)
        {
            var localization = DB.TeamGroupLocalizations.Include(o => o.Language)
                                                        .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return new RequestResult<TeamGroupLocalization>().SetError(404, "Локализация с данным id не найдена");
            }

            var checkRes = CheckFromTeamGroup(localization.TeamGroupId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamGroupLocalization>().FillFromRequestResult(checkRes);
            }

            return new RequestResult<TeamGroupLocalization>().SetSuccess(localization);
        }




        [HttpPost, Route("AddTeamGroup")]
        public async Task<RequestResult<TeamGroup>> AddTeamGroup(int structureId, TeamGroup item)
        {

            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetTeamStructuresList(), structureId, ContentAccessModelType.Team);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<TeamGroup>().FillFromRequestResult(checkAccessResult);
            }
            var structure = checkAccessResult.Value;



            var сheckRes = CheckBasePropsBeforeCreate(item);
            if (!сheckRes.Success)
            {
                return new RequestResult<TeamGroup>().FillFromRequestResult(сheckRes);
            }


            structure.Groups.Add(item);
            DB.TeamStructures.Update(structure);
            DB.SaveChanges();
            return new RequestResult<TeamGroup>().SetSuccess(item);

        }
  
        [HttpPost, Route("AddTeamGroupLocalization")]
        public async Task<RequestResult<TeamGroupLocalization>> AddTeamGroupLocalization(int itemId, TeamGroupLocalization localization)
        {
            var mainEntity = GetTeamGroupsList().FirstOrDefault(o => o.Id == itemId);

            var checkRes = CheckFromTeamStructure(mainEntity.TeamStructureId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamGroupLocalization>().FillFromRequestResult(checkRes);
            }

            mainEntity.Localizations.Add(localization);
            DB.TeamGroups.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<TeamGroupLocalization>().SetSuccess(localization);
        }



        [HttpPut, Route("UpdateTeamGroupMain")]
        public async Task<RequestResult<TeamGroup>> UpdateTeamGroupMain(TeamGroupMainEditModel model)
        {
            var res = new RequestResult<TeamGroup>();

            var item = GetTeamGroupsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkRes = CheckFromTeamStructure(item.TeamStructureId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamGroup>().FillFromRequestResult(checkRes);
            }

            return UpdateModel(DB.TeamGroups, model, item);
        }
    
        [HttpPut, Route("UpdateTeamGroupLocalization")]
        public async Task<RequestResult<TeamGroupLocalization>> UpdateTeamGroupLocalization(TeamGroupLocalizationEditModel model)
        {
            var res = new RequestResult<TeamGroupLocalization>();

            var localization = DB.TeamGroupLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkRes = CheckFromTeamGroup(localization.TeamGroupId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamGroupLocalization>().FillFromRequestResult(checkRes);
            }

            return UpdateModel(DB.TeamGroupLocalizations, model, localization);
        }





        [HttpDelete, Route("DeleteTeamGroup")]
        public async Task<RequestResult> DeleteTeamGroup(int id)
        {
            var res = new RequestResult();

            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (group == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkRes = CheckFromTeamStructure(group.TeamStructureId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMember>().FillFromRequestResult(checkRes);
            }


            group.IsDeleted = true;
            DB.TeamGroups.Update(group);
            DB.SaveChanges();
            return RequestResult.AsSuccess();
        }

        [HttpDelete, Route("DeleteTeamGroupLocalization")]
        public async Task<RequestResult> DeleteTeamGroupLocalization(int id)
        {
            var res = new RequestResult();

            var localization = DB.TeamGroupLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkRes = CheckFromTeamGroup(localization.TeamGroupId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMemberLocalization>().FillFromRequestResult(checkRes);
            }

            return DeleteModel(DB.TeamGroupLocalizations, localization, false);
        }


        #endregion

        #region Члены команды

        [HttpGet, Route("GetTeamMember")]
        public async Task<RequestResult<TeamMember>> GetTeamMember(int id)
        {
            var member = GetTeamMembersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (member == null)
            {
                return RequestResult<TeamMember>.AsError(404, "Сущность с данным id не найдена");
            }

            var checkRes = CheckFromTeamGroup(member.TeamGroupId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMember>().FillFromRequestResult(checkRes);
            }

            return RequestResult<TeamMember>.AsSuccess(member);
        }

        [HttpGet, Route("GetTeamMemberLocalization")]
        public async Task<RequestResult<TeamMemberLocalization>> GetTeamMemberLocalization(int id)
        {
            var localization = DB.TeamMemberLocalizations.Include(o => o.Language)
                                                         .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return new RequestResult<TeamMemberLocalization>().SetError(404, "Локализация с данным id не найдена");
            }

            var checkRes = CheckFromMember(localization.TeamMemberId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMemberLocalization>().FillFromRequestResult(checkRes);
            }

            return new RequestResult<TeamMemberLocalization>().SetSuccess(localization);
        }





        [HttpPost, Route("AddTeamMember")]
        public async Task<RequestResult<TeamMember>> AddTeamMember(int groupId,TeamMember item)
        {

            //Получаем группу, чтобы потом проверить права доступа
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);
            if (group == null)
            {
                return RequestResult<TeamMember>.AsError(500, "Внутренняя ошибка");
            }

            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetTeamStructuresList(), group.TeamStructureId, ContentAccessModelType.Team);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<TeamMember>().FillFromRequestResult(checkAccessResult);
            }

            var сheckRes = CheckBasePropsBeforeCreate(item);
            if (!сheckRes.Success)
            {
                return new RequestResult<TeamMember>().FillFromRequestResult(сheckRes);
            }

            //Загрузка фото сотрудника
            var imgUploadResult = await TryUploadFile("mainImg", FileType.Image);
            if (!imgUploadResult.Success)
            {
                return new RequestResult<TeamMember>().FillFromRequestResult(imgUploadResult);
            }
            item.ImgPath = imgUploadResult.Value;


            group.Members.Add(item);
            DB.TeamGroups.Update(group);
            DB.SaveChanges();
            return new RequestResult<TeamMember>().SetSuccess(item);

        }

        [HttpPost, Route("AddTeamMemberLocalization")]
        public async Task<RequestResult<TeamMemberLocalization>> AddTeamMemberLocalization(int itemId, TeamMemberLocalization localization)
        {
            var mainEntity = GetTeamMembersList().FirstOrDefault(o => o.Id == itemId);

            var checkRes = CheckFromTeamGroup(mainEntity.TeamGroupId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMemberLocalization>().FillFromRequestResult(checkRes);
            }

            mainEntity.Localizations.Add(localization);
            DB.TeamMembers.Update(mainEntity);
            DB.SaveChanges();

            return new RequestResult<TeamMemberLocalization>().SetSuccess(localization);
        }



        [HttpPut, Route("UpdateTeamMemberMain")]
        public async Task<RequestResult<TeamMember>> UpdateTeamMemberMain(TeamMemberMainEditModel model)
        {
            var res = new RequestResult<TeamMember>();

            var item = GetTeamMembersList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (item == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkRes = CheckFromTeamGroup(item.TeamGroupId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMember>().FillFromRequestResult(checkRes);
            }


            //Загрузка фото сотрудника
            if (item.ImgPath != model.ImgPath)
            {
                var imgUploadResult = await TryUploadFile("mainImg", FileType.Image);
                if (!imgUploadResult.Success)
                {
                    return new RequestResult<TeamMember>().FillFromRequestResult(imgUploadResult);
                }
                item.ImgPath = imgUploadResult.Value;
            }



            return UpdateModel(DB.TeamMembers, model, item);
        }

        [HttpPut, Route("UpdateTeamMemberLocalization")]
        public async Task<RequestResult<TeamMemberLocalization>> UpdateTeamMemberLocalization(TeamMemberLocalizationEditModel model)
        {
            var res = new RequestResult<TeamMemberLocalization>();

            var localization = DB.TeamMemberLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Локализация с данным id не найдена");
            }

            var checkRes = CheckFromMember(localization.TeamMemberId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMemberLocalization>().FillFromRequestResult(checkRes);
            }


            return UpdateModel(DB.TeamMemberLocalizations, model, localization);
        }





        [HttpDelete, Route("DeleteTeamMember")]
        public async Task<RequestResult> DeleteTeamMember(int id)
        {
            var res = new RequestResult();

            var member = GetTeamMembersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (member == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkRes = CheckFromTeamGroup(member.TeamGroupId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMember>().FillFromRequestResult(checkRes);
            }


            member.IsDeleted = true;
            DB.TeamMembers.Update(member);
            DB.SaveChanges();
            return RequestResult.AsSuccess();
        }

        [HttpDelete, Route("DeleteTeamMemberLocalization")]
        public async Task<RequestResult> DeleteTeamMemberLocalization(int id)
        {
            var res = new RequestResult();

            var localization = DB.TeamMemberLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (localization == null)
            {
                return res.SetError(404, "Запись по данному id не найдена");
            }

            var checkRes = CheckFromMember(localization.TeamMemberId);
            if (!checkRes.Success)
            {
                return new RequestResult<TeamMemberLocalization>().FillFromRequestResult(checkRes);
            }

            return DeleteModel(DB.TeamMemberLocalizations, localization, false);
        }

        #endregion


        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityEditModel model)
        {
            bool hasThisModel = false;
            hasThisModel |= DB.TeamStructures.Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Team);
        }


        #region Private Check methods

        //TODO: уровни доступа !!!!
        private RequestResult CheckFromMember(int memberId)
        {
            //Получаем члена команды, чтобы потом проверить права доступа
            var member = GetTeamMembersList().FirstOrDefault(o => o.Id == memberId && !o.IsDeleted);
            if (member == null)
            {
                return RequestResult.AsError(404, "Сущность с данным id не найдена");
            }
            //Получаем группу, чтобы потом проверить права доступа
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == member.TeamGroupId && !o.IsDeleted);
            if (group == null)
            {
                return RequestResult.AsError(500, "Внутренняя ошибка");
            }
            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetTeamStructuresList(), group.TeamStructureId, ContentAccessModelType.Team);
            if (!checkAccessResult.Success)
            {
                return new RequestResult().FillFromRequestResult(checkAccessResult);
            }

            return RequestResult.AsSuccess();
        }
        private RequestResult CheckFromTeamGroup(int groupId)
        {
            //Получаем группу, чтобы потом проверить права доступа
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);
            if (group == null)
            {
                return RequestResult.AsError(500, "Внутренняя ошибка");
            }
            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetTeamStructuresList(), group.TeamStructureId, ContentAccessModelType.Team);
            if (!checkAccessResult.Success)
            {
                return new RequestResult().FillFromRequestResult(checkAccessResult);
            }

            return RequestResult.AsSuccess();
        }
        private RequestResult CheckFromTeamStructure(int structureId)
        {
            //Проверяем, есть ли доступ у пользователя к главной сущности
            var checkAccessResult = TryGetOne(GetTeamStructuresList(), structureId, ContentAccessModelType.Team);
            if (!checkAccessResult.Success)
            {
                return new RequestResult().FillFromRequestResult(checkAccessResult);
            }

            return RequestResult.AsSuccess();
        }
        #endregion

        #region Private get included methods

        private IQueryable<TeamStructure> GetTeamStructuresList()
        {
            return DB.TeamStructures.IncludeAvailability()
                                    .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.MainLanguage)
                                    .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                    .Include(o => o.Groups).ThenInclude(o => o.MainLanguage)
                                    .Include(o => o.Groups).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                    .Where(o => !o.IsDeleted);
        }
        private IQueryable<TeamStructure> GetTeamStructuresFullIncludedList()
        {
            return DB.TeamStructures.IncludeAvailability()
                                    .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.MainLanguage)
                                    .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                    .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                    .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                    .Include(o => o.Groups).ThenInclude(o => o.MainLanguage)
                                    .Include(o => o.Groups).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                    .Where(o => !o.IsDeleted);
        }


        private IQueryable<TeamGroup> GetTeamGroupsList()
        {
            return DB.TeamGroups.Include(o => o.Members).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.Language)
                                .Include(o => o.MainLanguage)
                                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                .Where(o => !o.IsDeleted);
        }

        private IQueryable<TeamMember> GetTeamMembersList()
        {
            return DB.TeamMembers.Include(o => o.MainLanguage)
                                 .Include(o => o.Localizations).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                 .Include(o => o.Localizations).ThenInclude(o => o.Language)
                                 .Include(o => o.DetailContent).ThenInclude(o => o.Items)
                                 .Where(o => !o.IsDeleted);
        }
        #endregion

    }
}
