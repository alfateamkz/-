using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Portfolios;
using Alfateam.Website.API.Models.ClientModels.Team;
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
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Localization.Items.Team;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Roles.Access;
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
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<IEnumerable<TeamStructureClientModel>>(new Func<RequestResult>[]
            {
                () => CheckContentAreaRights(session, ContentAccessModelType.Posts, 1),
                () => {
                    var items = GetAvailableModels(session.User, GetTeamStructuresList(), offset, count);
                    var models = TeamStructureClientModel.CreateItems(items.Cast<TeamStructure>(), LanguageId);
                    return RequestResult<IEnumerable<TeamStructureClientModel>>.AsSuccess(models);
                }
            });
        }

        [HttpGet, Route("GetTeamStructure")]
        public async Task<RequestResult<TeamStructure>> GetTeamStructure(int id)
        {
            return TryGetOne(GetTeamStructuresFullIncludedList(), id, ContentAccessModelType.Team);
        }




        [HttpPost, Route("CreateTeamStructure")]
        public async Task<RequestResult<TeamStructure>> CreateTeamStructure(TeamStructure structure)
        {
            return await TryCreate(DB.TeamStructures, structure, ContentAccessModelType.Team, () => PrepareTeamStructureBeforeCreate(structure));
        }




        [HttpDelete, Route("DeleteTeamStructure")]
        public async Task<RequestResult> DeleteTeamStructure(int id)
        {
            var item = GetTeamStructuresList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamGroup>(new[]
            {
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => TryDelete(DB.TeamStructures, item, ContentAccessModelType.Team)
            });
        }


        #endregion

        #region Отдельные команды

        [HttpGet, Route("GetTeamGroup")]
        public async Task<RequestResult<TeamGroup>> GetTeamGroup(int id)
        {
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamGroup>(new[]
            {
                () => RequestResult.FromBoolean(group != null, 404, "Сущность по данному id не найдена"),
                () => TryGetOne(GetTeamStructuresList(), group.TeamStructureId, ContentAccessModelType.Team),
                () => RequestResult<TeamGroup>.AsSuccess(group)
            });
        }

        [HttpGet, Route("GetTeamGroupLocalization")]
        public async Task<RequestResult<TeamGroupLocalization>> GetTeamGroupLocalization(int id)
        {
            var localization = DB.TeamGroupLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamGroupLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Сущность по данному id не найдена"),
                () => CheckFromTeamGroup(localization.TeamGroupId, ContentAccessModel.WatchLevel),
                () => new RequestResult<TeamGroupLocalization>().SetSuccess(localization)
            });
        }




        [HttpPost, Route("AddTeamGroup")]
        public async Task<RequestResult<TeamGroup>> AddTeamGroup(int structureId, TeamGroup item)
        {
            var structure = GetTeamStructuresList().FirstOrDefault(o => o.Id == structureId && !o.IsDeleted);
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes<TeamGroup>(new[]
            {
                () => RequestResult.FromBoolean(structure != null,404, "Сущность по данному id не найдена"),
                () => CheckContentAreaRights(session, structure, ContentAccessModelType.Team, ContentAccessModel.CreateNewLevel),
                () => CheckBasePropsBeforeCreate(item),
                () => PrepareTeamGroupBeforeCreate(item).Result,
                () =>
                {
                    structure.Groups.Add(item);
                    UpdateModel(DB.TeamStructures,structure);
                    return new RequestResult<TeamGroup>().SetSuccess(item);
                }
            });

        }
  
        [HttpPost, Route("AddTeamGroupLocalization")]
        public async Task<RequestResult<TeamGroupLocalization>> AddTeamGroupLocalization(int itemId, TeamGroupLocalization localization)
        {
            var mainEntity = GetTeamGroupsList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<TeamGroupLocalization>(new[]
            {
                () => RequestResult.FromBoolean(mainEntity != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromTeamStructure(mainEntity.TeamStructureId, ContentAccessModel.CreateNewLevel),
                () =>
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.TeamGroups,mainEntity);
                    return RequestResult<TeamGroupLocalization>.AsSuccess(localization);
                }
            });
        }



        [HttpPut, Route("UpdateTeamGroupMain")]
        public async Task<RequestResult<TeamGroup>> UpdateTeamGroupMain(TeamGroupMainEditModel model)
        {
            var item = GetTeamGroupsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamGroup>(new[]
            {
                () => RequestResult.FromBoolean(item != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromTeamStructure(item.TeamStructureId, ContentAccessModel.EditCurrentLevel),
                () => UpdateModel(DB.TeamGroups, model, item)
            });
        }
    
        [HttpPut, Route("UpdateTeamGroupLocalization")]
        public async Task<RequestResult<TeamGroupLocalization>> UpdateTeamGroupLocalization(TeamGroupLocalizationEditModel model)
        {
            var localization = DB.TeamGroupLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamGroupLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromTeamGroup(localization.TeamGroupId, ContentAccessModel.EditLocalizationsLevel),
                () => UpdateModel(DB.TeamGroupLocalizations, model, localization)
            });
        }





        [HttpDelete, Route("DeleteTeamGroup")]
        public async Task<RequestResult> DeleteTeamGroup(int id)
        {
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(group != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromTeamStructure(group.TeamStructureId, ContentAccessModel.DeleteLevel),
                () => DeleteModel(DB.TeamGroups,group)
            });
        }

        [HttpDelete, Route("DeleteTeamGroupLocalization")]
        public async Task<RequestResult> DeleteTeamGroupLocalization(int id)
        {
            var localization = DB.TeamGroupLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(localization != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromTeamGroup(localization.TeamGroupId, ContentAccessModel.DeleteLevel),
                () => DeleteModel(DB.TeamGroupLocalizations, localization, false)
            });
        }


        #endregion

        #region Члены команды

        [HttpGet, Route("GetTeamMember")]
        public async Task<RequestResult<TeamMember>> GetTeamMember(int id)
        {
            var member = GetTeamMembersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamMember>(new[]
            {
                () => RequestResult.FromBoolean(member != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromTeamGroup(member.TeamGroupId, ContentAccessModel.WatchLevel),
                () => RequestResult<TeamMember>.AsSuccess(member)
            });
        }

        [HttpGet, Route("GetTeamMemberLocalization")]
        public async Task<RequestResult<TeamMemberLocalization>> GetTeamMemberLocalization(int id)
        {
            var localization = DB.TeamMemberLocalizations.Include(o => o.Language).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamMemberLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromMember(localization.TeamMemberId, ContentAccessModel.WatchLevel),
                () => new RequestResult<TeamMemberLocalization>().SetSuccess(localization)
            });
        }





        [HttpPost, Route("AddTeamMember")]
        public async Task<RequestResult<TeamMember>> AddTeamMember(int groupId,TeamMember item)
        {
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);
            return TryFinishAllRequestes<TeamMember>(new[]
            {
                () => RequestResult.FromBoolean(group != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromTeamGroup(groupId,ContentAccessModel.CreateNewLevel),
                () => CheckBasePropsBeforeCreate(item),
                () => PrepareTeamMemberBeforeCreate(item).Result,
                () =>
                {
                    group.Members.Add(item);
                    UpdateModel(DB.TeamGroups,group);
                    return new RequestResult<TeamMember>().SetSuccess(item);
                }
            });
        }

        [HttpPost, Route("AddTeamMemberLocalization")]
        public async Task<RequestResult<TeamMemberLocalization>> AddTeamMemberLocalization(int itemId, TeamMemberLocalization localization)
        {
            var mainEntity = GetTeamMembersList().FirstOrDefault(o => o.Id == itemId);
            return TryFinishAllRequestes<TeamMemberLocalization>(new[]
            {
                () => RequestResult.FromBoolean(mainEntity != null , 404, "Сущность с данным id не найдена"),
                () => CheckFromTeamGroup(mainEntity.TeamGroupId, ContentAccessModel.CreateNewLevel),
                () => 
                {
                    mainEntity.Localizations.Add(localization);
                    UpdateModel(DB.TeamMembers,mainEntity);
                    return RequestResult<TeamMemberLocalization>.AsSuccess(localization);
                }
            });
        }



        [HttpPut, Route("UpdateTeamMemberMain")]
        public async Task<RequestResult<TeamMember>> UpdateTeamMemberMain(TeamMemberMainEditModel model)
        {
            var item = GetTeamMembersList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamMember>(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Запись по данному id не найдена"),
                () => CheckFromTeamGroup(item.TeamGroupId, ContentAccessModel.EditCurrentLevel),
                () => PrepareTeamMemberBeforeUpdate(item).Result,
                () => UpdateModel(DB.TeamMembers, model, item)
            });
        }

        [HttpPut, Route("UpdateTeamMemberLocalization")]
        public async Task<RequestResult<TeamMemberLocalization>> UpdateTeamMemberLocalization(TeamMemberLocalizationEditModel model)
        {
            var localization = DB.TeamMemberLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryFinishAllRequestes<TeamMemberLocalization>(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Локализация с данным id не найдена"),
                () => CheckFromMember(localization.TeamMemberId, ContentAccessModel.EditLocalizationsLevel),
                () => UpdateModel(DB.TeamMemberLocalizations, model, localization)
            });
        }





        [HttpDelete, Route("DeleteTeamMember")]
        public async Task<RequestResult> DeleteTeamMember(int id)
        {
            var member = GetTeamMembersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(member != null,404, "Запись по данному id не найдена"),
                () => CheckFromTeamGroup(member.TeamGroupId, ContentAccessModel.DeleteLevel),
                () => DeleteModel(DB.TeamMembers,member)
            });
        }

        [HttpDelete, Route("DeleteTeamMemberLocalization")]
        public async Task<RequestResult> DeleteTeamMemberLocalization(int id)
        {
            var localization = DB.TeamMemberLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(localization != null,404, "Запись по данному id не найдена"),
                () => CheckFromMember(localization.TeamMemberId, ContentAccessModel.DeleteLevel),
                () => DeleteModel(DB.TeamMemberLocalizations, localization, false)
            });
        }

        #endregion


        [HttpPut, Route("UpdateAvailability")]
        public async Task<RequestResult<Availability>> UpdateAvailability(AvailabilityEditModel model)
        {
            bool hasThisModel = false;

            var user = GetSessionWithRoleInclude().User;
            hasThisModel |= GetAvailableModels(user, DB.TeamStructures.IncludeAvailability()).Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                return new RequestResult<Availability>().SetError(403, "У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return TryUpdateAvailability(model, ContentAccessModelType.Team);
        }





        #region Private prepare methods

        private async Task<RequestResult> PrepareTeamStructureBeforeCreate(TeamStructure structure)
        {
            foreach(var group in structure.Groups)
            {
                var groupPrepareResult = await PrepareTeamGroupBeforeCreate(group);
                if (!groupPrepareResult.Success)
                {
                    return groupPrepareResult;
                }
            }
            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> PrepareTeamGroupBeforeCreate(TeamGroup group)
        {
            foreach(var member in group.Members)
            {
                var memberPrepareResult = await PrepareTeamMemberBeforeCreate(member);
                if (!memberPrepareResult.Success)
                {
                    return memberPrepareResult;
                }
            }
            return RequestResult.AsSuccess();
        }


        private async Task<RequestResult> PrepareTeamMemberBeforeCreate(TeamMember item)
        {
            //Загрузка фото сотрудника
            var imgUploadResult = await TryUploadFile("mainImg", FileType.Image);
            if (!imgUploadResult.Success)
            {
                return imgUploadResult;
            }
            item.ImgPath = imgUploadResult.Value;
            return RequestResult.AsSuccess();
        }
        private async Task<RequestResult> PrepareTeamMemberBeforeUpdate(TeamMember item)
        {
            //Загрузка фото сотрудника
            if (Request.Form.Files.Any(o => o.Name == "mainImg"))
            {
                var imgUploadResult = await TryUploadFile("mainImg", FileType.Image);
                if (!imgUploadResult.Success)
                {
                    return imgUploadResult;
                }
                item.ImgPath = imgUploadResult.Value;
            }
            return RequestResult.AsSuccess();
        }



        #endregion

        #region Private Check methods
        private RequestResult CheckFromMember(int memberId, int requiredLevel)
        {
            //Получаем члена команды, чтобы потом проверить права доступа
            var member = GetTeamMembersList().FirstOrDefault(o => o.Id == memberId && !o.IsDeleted);
            if (member == null)
            {
                return RequestResult.AsError(404, "Сущность с данным id не найдена");
            }

            return CheckFromTeamGroup(member.TeamGroupId, requiredLevel);
        }
        private RequestResult CheckFromTeamGroup(int groupId, int requiredLevel)
        {
            //Получаем группу, чтобы потом проверить права доступа
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);
            if (group == null)
            {
                return RequestResult.AsError(500, "Внутренняя ошибка");
            }

            return CheckFromTeamStructure(group.TeamStructureId, requiredLevel);
        }
        private RequestResult CheckFromTeamStructure(int structureId,int requiredLevel)
        {
            var item = GetTeamStructuresList().FirstOrDefault(o => o.Id == structureId && !o.IsDeleted);
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404, "Структура по данному id не найдена"),
                () => CheckContentAreaRights(GetSessionWithRoleInclude(), item, ContentAccessModelType.Team, requiredLevel),
                () => RequestResult.AsSuccess()
            });
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
