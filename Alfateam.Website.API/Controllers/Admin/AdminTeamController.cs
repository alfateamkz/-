﻿using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Enums;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam.Website.API.Models.DTO.Team;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTOLocalization.Events;
using Alfateam.Website.API.Models.DTOLocalization.Team;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Enums;
using Alfateam.Core.Enums;
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
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Models.DTOLocalization.Posts;
using Alfateam2._0.Models.ContentItems;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using Alfateam.Core;
using Alfateam.Core.Helpers;
using Alfateam.Website.API.Helpers;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminTeamController : AbsAdminController
    {

        public AdminTeamController(ControllerParams @params) : base(@params)
        {
        }

        #region Структуры команд


        [HttpGet, Route("GetTeamStructures")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<ItemsWithTotalCount<TeamStructureDTO>> GetTeamStructures(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<TeamStructure, TeamStructureDTO>(GetAvailableTeamStructures(), offset, count);
        }

        [HttpGet, Route("GetTeamStructure")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<TeamStructureDTO> GetTeamStructure(int id)
        {
            return (TeamStructureDTO)DbService.TryGetOne(GetAvailableTeamStructures(), id, new TeamStructureDTO());
        }




        [HttpPost, Route("CreateTeamStructure")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 4)]
        public async Task<TeamStructureDTO> CreateTeamStructure(TeamStructureDTO structure)
        {
            return (TeamStructureDTO)DbService.TryCreateAvailabilityEntity(DB.TeamStructures, structure, this.Session, (entity) => {
                entity.MainLanguageId = 1;
            });
        }




        [HttpDelete, Route("DeleteTeamStructure")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 5)]
        public async Task DeleteTeamStructure(int id)
        {
            var item = GetAvailableTeamStructures().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.TeamStructures, item);
        }


        #endregion

        #region Отдельные команды

        [HttpGet, Route("GetTeamGroups")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<IEnumerable<TeamGroupDTO>> GetTeamGroups(int structureId)
        {
            var groups = GetTeamGroupsList().Where(o => o.TeamStructureId == structureId && !o.IsDeleted);

            CheckFromTeamStructure(structureId);
            return new TeamGroupDTO().CreateDTOs(groups).Cast<TeamGroupDTO>();
        }

        [HttpGet, Route("GetTeamGroup")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<TeamGroupDTO> GetTeamGroup(int structureId,int groupId)
        {
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == groupId && o.TeamStructureId == structureId && !o.IsDeleted);

            CheckFromTeamGroup(groupId);
            return (TeamGroupDTO)new TeamGroupDTO().CreateDTO(group);
        }

        [HttpGet, Route("GetTeamGroupLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<IEnumerable<TeamGroupLocalizationDTO>> GetTeamGroupLocalizations(int id)
        {
            var localizations = DB.TeamGroupLocalizations.Include(o => o.LanguageEntity).Where(o => o.TeamGroupId == id && !o.IsDeleted);
            var mainEntity = GetTeamGroupsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromTeamGroup(id);
            return DbService.GetLocalizationModels(localizations, mainEntity, new TeamGroupLocalizationDTO()).Cast<TeamGroupLocalizationDTO>();
        }

        [HttpGet, Route("GetTeamGroupLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<TeamGroupLocalizationDTO> GetTeamGroupLocalization(int id)
        {
            var localization = DB.TeamGroupLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetTeamGroupsList().FirstOrDefault(o => o.Id == localization?.TeamGroupId && !o.IsDeleted);

            CheckFromTeamGroup(localization?.TeamGroupId);
            return (TeamGroupLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new TeamGroupLocalizationDTO());
        }




        [HttpPost, Route("AddTeamGroup")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 4)]
        public async Task<TeamGroupDTO> AddTeamGroup(TeamGroupDTO model)
        {
            CheckFromTeamStructure(model.TeamStructureId);
            return (TeamGroupDTO)DbService.TryCreateEntity(DB.TeamGroups, model);
        }
  
        [HttpPost, Route("AddTeamGroupLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 3)]
        public async Task<TeamGroupLocalizationDTO> AddTeamGroupLocalization(int itemId, TeamGroupLocalizationDTO model)
        {
            var mainEntity = GetTeamGroupsList().FirstOrDefault(o => o.Id == itemId);

            CheckFromTeamGroup(itemId);
            return (TeamGroupLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.TeamGroups, mainEntity, model);
        }



        [HttpPut, Route("UpdateTeamGroupMain")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 3)]
        public async Task<TeamGroupDTO> UpdateTeamGroupMain(TeamGroupDTO model)
        {
            var item = GetTeamGroupsList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            CheckFromTeamGroup(model.Id);
            return (TeamGroupDTO)DbService.TryUpdateEntity(DB.TeamGroups, model, item);
        }
    
        [HttpPut, Route("UpdateTeamGroupLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 3)]
        public async Task<TeamGroupLocalizationDTO> UpdateTeamGroupLocalization(TeamGroupLocalizationDTO model)
        {
            var localization = DB.TeamGroupLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetTeamGroupsList().FirstOrDefault(o => o.Id == localization.TeamGroupId && !o.IsDeleted);

            CheckFromTeamGroup(localization.TeamGroupId);
            return (TeamGroupLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.TeamGroupLocalizations, localization, model, mainEntity);
        }





        [HttpDelete, Route("DeleteTeamGroup")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 5)]
        public async Task DeleteTeamGroup(int id)
        {
            var item = GetTeamGroupsList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromTeamGroup(id);
            DbService.TryDeleteEntity(DB.TeamGroups, item);
        }

        [HttpDelete, Route("DeleteTeamGroupLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 5)]
        public async Task DeleteTeamGroupLocalization(int id)
        {
            var item = DB.TeamGroupLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetTeamGroupsList().FirstOrDefault(o => o.Id == item.TeamGroupId && !o.IsDeleted);

            CheckFromTeamGroup(item?.TeamGroupId);
            DbService.TryDeleteLocalizationEntity(DB.TeamGroupLocalizations, item, mainModel);
        }


        #endregion

        #region Члены команды


        [HttpGet, Route("GetTeamMembers")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<IEnumerable<TeamMemberDTO>> GetTeamMembers(int groupId)
        {
            var members = GetTeamMembersList().Where(o => o.TeamGroupId == groupId && !o.IsDeleted);

            CheckFromTeamGroup(groupId);
            return new TeamMemberDTO().CreateDTOs(members).Cast<TeamMemberDTO>();
        }
        [HttpGet, Route("GetTeamMember")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<TeamMemberDTO> GetTeamMember(int groupId, int memberId)
        {
            var member = GetTeamMembersList().FirstOrDefault(o => o.Id == memberId && o.TeamGroupId == groupId && !o.IsDeleted);

            CheckFromMember(memberId);
            return (TeamMemberDTO)new TeamMemberDTO().CreateDTO(member);
        }

        [HttpGet, Route("GetTeamMemberLocalizations")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<IEnumerable<TeamMemberLocalizationDTO>> GetTeamMemberLocalizations(int id)
        {
            var localizations = DB.TeamMemberLocalizations.Include(o => o.LanguageEntity).Where(o => o.TeamMemberId == id && !o.IsDeleted);
            var mainEntity = GetTeamMembersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new TeamMemberLocalizationDTO()).Cast<TeamMemberLocalizationDTO>();
        }

        [HttpGet, Route("GetTeamMemberLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 1)]
        public async Task<TeamMemberLocalizationDTO> GetTeamMemberLocalization(int id)
        {
            var localization = DB.TeamMemberLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = GetTeamMembersList().FirstOrDefault(o => o.Id == localization?.TeamMemberId && !o.IsDeleted);

            return (TeamMemberLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new TeamMemberLocalizationDTO());
        }





        [HttpPost, Route("AddTeamMember")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 4)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg и резюме (опционально) с именем cvFile")]
        public async Task<TeamMemberDTO> AddTeamMember(/*int groupId, */[FromForm(Name = "model")] TeamMemberDTO model)
        {
            CheckFromTeamGroup(model.TeamGroupId);
            return (TeamMemberDTO)DbService.TryCreateEntity(DB.TeamMembers, model, (entity) =>
            {
                HandleTeamMember(entity, DBModelFillMode.Create, null);
            });
        }

        [HttpPost, Route("AddTeamMemberLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 3)]
        [SwaggerOperation(description: "Нужно загрузить резюме (опционально) с именем cvFile")]
        public async Task<TeamMemberLocalizationDTO> AddTeamMemberLocalization(int itemId, [FromForm(Name = "model")] TeamMemberLocalizationDTO model)
        {
            var mainEntity = GetTeamMembersList().FirstOrDefault(o => o.Id == itemId);

            CheckFromMember(itemId);
            return (TeamMemberLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.TeamMembers, mainEntity, model, (entity) =>
            {
                HandleTeamMemberLocalization(entity, DBModelFillMode.Create, null);
            });
        }



        [HttpPut, Route("UpdateTeamMemberMain")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 2)]
        [SwaggerOperation(description: "Нужно загрузить изображение через форму с именем mainImg и резюме (опционально) с именем cvFile, если изменяем файлы")]
        public async Task<TeamMemberDTO> UpdateTeamMemberMain([FromForm(Name = "model")] TeamMemberDTO model)
        {
            var item = GetTeamMembersList().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            CheckFromMember(model.Id);
            return (TeamMemberDTO)DbService.TryUpdateEntity(DB.TeamMembers, model, item, (entity) =>
            {
                HandleTeamMember(entity, DBModelFillMode.Update, model.DetailContent.CreateDBModelFromDTO());
            });
        }

        [HttpPut, Route("UpdateTeamMemberLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 3)]
        [SwaggerOperation(description: "Нужно загрузить резюме (опционально) с именем cvFile, если изменяем файл")]
        public async Task<TeamMemberLocalizationDTO> UpdateTeamMemberLocalization([FromForm(Name = "model")] TeamMemberLocalizationDTO model)
        {
            var localization = DB.TeamMemberLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = GetTeamMembersList().FirstOrDefault(o => o.Id == localization?.TeamMemberId && !o.IsDeleted);

            CheckFromMember(localization?.TeamMemberId);
            return (TeamMemberLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.TeamMemberLocalizations, localization, model, mainEntity, (entity) =>
            {
                HandleTeamMemberLocalization(entity, DBModelFillMode.Update, model.DetailContent.CreateDBModelFromDTO());
            });
        }





        [HttpDelete, Route("DeleteTeamMember")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 5)]
        public async Task DeleteTeamMember(int id)
        {
            var item = GetTeamMembersList().FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            CheckFromMember(id);
            DbService.TryDeleteEntity(DB.TeamMembers, item);
        }

        [HttpDelete, Route("DeleteTeamMemberLocalization")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 5)]
        public async Task DeleteTeamMemberLocalization(int id)
        {
            var item = DB.TeamMemberLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = GetTeamMembersList().FirstOrDefault(o => o.Id == item.TeamMemberId && !o.IsDeleted);

            CheckFromMember(item?.TeamMemberId);
            DbService.TryDeleteLocalizationEntity(DB.TeamMemberLocalizations, item, mainModel);
        }

        #endregion


        [HttpPut, Route("UpdateAvailability")]
        [CheckContentAreaRights(ContentAccessModelType.Team, 2)]
        public async Task<AvailabilityDTO> UpdateAvailability(AvailabilityDTO model)
        {
            bool hasThisModel = false;

            var user = this.Session.User;
            hasThisModel |= DbService.GetAvailableModels(user, DB.TeamStructures.IncludeAvailability())
                                     .Any(o => o.AvailabilityId == model.Id && !o.IsDeleted);

            if (!hasThisModel)
            {
                throw new Exception403("У данного пользователя нет прав на редактирование матрицы доступности");
            }

            return DbService.TryUpdateAvailability(model, this.Session);
        }









       

        

        #region Private prepare methods
        private void HandleTeamMember(TeamMember entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            const string formFilename = "mainImg";
            const string cvFilename = "cvFile";

            if ((mode == DBModelFillMode.Update && FilesService.IsFileUploaded(formFilename))
              || mode == DBModelFillMode.Create)
            {
                entity.ImgPath = FilesService.TryUploadFile(formFilename, FileType.Image);
            }

            if (FilesService.IsFileUploaded(cvFilename))
            {
                entity.CVFilepath = FilesService.TryUploadFile(cvFilename, FileType.Document);
            }

            if (mode == DBModelFillMode.Create)
            {
                FilesService.UploadContentMedia(entity.DetailContent);
            }
            else if (mode == DBModelFillMode.Update /*&& !entity.DetailContent.AreSame(newContentForUpdate)*/)
            {
                FilesService.UpdateContentMedia(entity.DetailContent, newContentForUpdate);
            }
        }
        private void HandleTeamMemberLocalization(TeamMemberLocalization entity, DBModelFillMode mode, Content newContentForUpdate)
        {
            const string cvFilename = "cvFile";

            if (FilesService.IsFileUploaded(cvFilename))
            {
                entity.CVFilepath = FilesService.TryUploadFile(cvFilename, FileType.Document);
            }


            if (mode == DBModelFillMode.Create)
            {
                FilesService.UploadContentMedia(entity.DetailContent);
            }
            else if (mode == DBModelFillMode.Update /*&& !entity.DetailContent.AreSame(newContentForUpdate)*/)
            {
                FilesService.UpdateContentMedia(entity.DetailContent, newContentForUpdate);
            }
        }

        #endregion

        #region Private Check methods
        private void CheckFromMember(int? memberId)
        {
            var member = GetTeamMembersList().FirstOrDefault(o => o.Id == memberId && !o.IsDeleted);
            if (memberId == null || member == null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }

            CheckFromTeamGroup(member.TeamGroupId);
        }
        private void CheckFromTeamGroup(int? groupId)
        {
            var group = GetTeamGroupsList().FirstOrDefault(o => o.Id == groupId && !o.IsDeleted);
            if (groupId == null || group == null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }

            CheckFromTeamStructure(group.TeamStructureId);
        }
        private void CheckFromTeamStructure(int? structureId)
        {
            var item = GetTeamStructuresList().FirstOrDefault(o => o.Id == structureId && !o.IsDeleted);
            if (structureId == null || item == null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }
        }
        #endregion

        #region Private get available methods
        private IEnumerable<TeamStructure> GetAvailableTeamStructures()
        {
            return DbService.GetAvailableModels(this.Session.User, GetTeamStructuresFullIncludedList()).Cast<TeamStructure>();
        }

        #endregion

        #region Private get included methods

        private IQueryable<TeamStructure> GetTeamStructuresList()
        {
            var items = DB.TeamStructures.IncludeAvailability()
                                          .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.MainLanguage)
                                          .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                          .Include(o => o.Groups).ThenInclude(o => o.MainLanguage)
                                          .Include(o => o.Groups).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                          .Where(o => !o.IsDeleted);

            return items;
        }
        private IEnumerable<TeamStructure> GetTeamStructuresFullIncludedList()
        {
            var items = DB.TeamStructures.IncludeAvailability()
                                         .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.MainLanguage)
                                         .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                         .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                         .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                         .Include(o => o.Groups).ThenInclude(o => o.MainLanguage)
                                         .Include(o => o.Groups).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                         .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                         .Where(o => !o.IsDeleted)
                                         .ToList();

            ContentIncludeHelper.IncludeHierarchy(DB, items.SelectMany(o => o.Groups).SelectMany(o => o.Members).Select(o => o.DetailContent));
            ContentIncludeHelper.IncludeHierarchy(DB, items.SelectMany(o => o.Groups).SelectMany(o => o.Members).SelectMany(o => o.Localizations).Select(o => o.DetailContent));
            return items;
        }


        private IEnumerable<TeamGroup> GetTeamGroupsList()
        {
            return DB.TeamGroups.Include(o => o.Members).ThenInclude(o => o.MainLanguage)
                                .Include(o => o.Members).ThenInclude(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Include(o => o.MainLanguage)
                                .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                .Where(o => !o.IsDeleted)
                                .ToList();
        }

        private IEnumerable<TeamMember> GetTeamMembersList()
        {
            var items = DB.TeamMembers.Include(o => o.MainLanguage)
                                      .Include(o => o.Localizations).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                      .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                                      .Include(o => o.Localizations).ThenInclude(o => o.DetailContent).ThenInclude(o => o.Items)
                                      .Include(o => o.DetailContent).ThenInclude(o => o.Items)
                                      .Where(o => !o.IsDeleted)
                                      .ToList();

            ContentIncludeHelper.IncludeHierarchy(DB, items.Select(o => o.DetailContent));
            ContentIncludeHelper.IncludeHierarchy(DB, items.SelectMany(o => o.Localizations).Select(o => o.DetailContent));
            return items;
        }
        #endregion

    }
}
