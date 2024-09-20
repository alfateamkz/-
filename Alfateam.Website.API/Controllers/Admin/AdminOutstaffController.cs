using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Exceptions;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Outstaff;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.DTO.Shop;
using Alfateam.Website.API.Models.DTO.Team;
using Alfateam.Website.API.Models.DTOLocalization.Outstaff;
using Alfateam.Website.API.Models.DTOLocalization.Shop;
using Alfateam.Website.API.Models.DTOLocalization.Team;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;
using Alfateam2._0.Models.Localization.Outstaff;
using Alfateam2._0.Models.Outstaff;
using Alfateam2._0.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Diagnostics;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminOutstaffController : AbsAdminController
    {
        public AdminOutstaffController(ControllerParams @params) : base(@params)
        {
        }

        #region Сетка аутстафф


        [HttpGet, Route("GetOutstaffMatrix")]
        [OutstaffSectionAccess(1)]
        public async Task<OutstaffMatrixDTO> GetOutstaffMatrix()
        {
            return (OutstaffMatrixDTO)new OutstaffMatrixDTO().CreateDTO(DB.GetOutstaffMatrix());
        }

        #endregion

        #region Колонки сетки аутстафф


        [HttpGet, Route("GetOutstaffColumn")]
        [OutstaffSectionAccess(1)]
        public async Task<OutstaffColumnDTO> GetOutstaffColumn(int id)
        {
            return (OutstaffColumnDTO)DbService.TryGetOne(DB.GetOutstaffMatrix().Columns, id, new OutstaffColumnDTO());
        }


        [HttpGet, Route("GetOutstaffColumnLocalizations")]
        [OutstaffSectionAccess(1)]
        public async Task<IEnumerable<OutstaffColumnLocalizationDTO>> GetOutstaffColumnLocalizations(int id)
        {
            var localizations = DB.OutstaffColumnLocalizations.Include(o => o.LanguageEntity).Where(o => o.OutstaffColumnId == id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new OutstaffColumnLocalizationDTO()).Cast<OutstaffColumnLocalizationDTO>();
        }

        [HttpGet, Route("GetOutstaffColumnLocalization")]
        [OutstaffSectionAccess(1)]
        public async Task<OutstaffColumnLocalizationDTO> GetOutstaffColumnLocalization(int id)
        {
            var localization = DB.OutstaffColumnLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == localization?.OutstaffColumnId && !o.IsDeleted);

            return (OutstaffColumnLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new OutstaffColumnLocalizationDTO());
        }




        [HttpPost, Route("CreateOutstaffColumn")]
        [OutstaffSectionAccess(5)]
        public async Task<OutstaffColumnDTO> CreateOutstaffColumn(OutstaffColumnDTO model)
        {
            return (OutstaffColumnDTO)DbService.TryCreateEntity(DB.OutstaffColumns, model);
        }
     
        [HttpPost, Route("CreateOutstaffColumnLocalization")]
        [OutstaffSectionAccess(5)]
        public async Task<OutstaffColumnLocalizationDTO> CreateOutstaffColumnLocalization(int itemId, OutstaffColumnLocalizationDTO model)
        {
            var mainEntity = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
            return (OutstaffColumnLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.OutstaffColumns, mainEntity, model);
        }





        [HttpPut, Route("UpdateOutstaffColumnMain")]
        [OutstaffSectionAccess(2)]
        public async Task<OutstaffColumnDTO> UpdateOutstaffColumnMain(OutstaffColumnDTO model)
        {
            var item = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (OutstaffColumnDTO)DbService.TryUpdateEntity(DB.OutstaffColumns, model, item);
        }
        [HttpPut, Route("UpdateOutstaffColumnLocalization")]
        [OutstaffSectionAccess(3)]
        public async Task<OutstaffColumnLocalizationDTO> UpdateOutstaffColumnLocalization(OutstaffColumnLocalizationDTO model)
        {
            var localization = DB.OutstaffColumnLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == localization.OutstaffColumnId && !o.IsDeleted);

            return (OutstaffColumnLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.OutstaffColumnLocalizations, localization, model, mainEntity);
        }







        [HttpDelete, Route("DeleteOutstaffColumn")]
        [OutstaffSectionAccess(6)]
        public async Task DeleteOutstaffColumn(int id)
        {
            var item = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.OutstaffColumns, item);
        }

        [HttpDelete, Route("DeleteOutstaffColumnLocalization")]
        [OutstaffSectionAccess(6)]
        public async Task DeleteOutstaffColumnLocalization(int id)
        {
            var item = DB.OutstaffColumnLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == item?.OutstaffColumnId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.OutstaffColumnLocalizations, item, mainModel);
        }


        #endregion

        #region Услуги сетки аутстафф

        [HttpGet, Route("GetOutstaffItem")]
        [OutstaffSectionAccess(1)]
        public async Task<OutstaffItemDTO> GetOutstaffItem(int id)
        {
            return (OutstaffItemDTO)DbService.TryGetOne(DB.GetOutstaffMatrix().Items, id, new OutstaffItemDTO());
        }

        [HttpGet, Route("GetOutstaffItemLocalizations")]
        [OutstaffSectionAccess(1)]
        public async Task<IEnumerable<OutstaffItemLocalizationDTO>> GetOutstaffItemLocalizations(int id)
        {
            var localizations = DB.OutstaffItemLocalizations.Include(o => o.LanguageEntity).Where(o => o.OutstaffItemId == id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new OutstaffItemLocalizationDTO()).Cast<OutstaffItemLocalizationDTO>();
        }

        [HttpGet, Route("GetOutstaffItemLocalization")]
        [OutstaffSectionAccess(1)]
        public async Task<OutstaffItemLocalizationDTO> GetOutstaffItemLocalization(int id)
        {
            var localization = DB.OutstaffItemLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == localization?.OutstaffItemId && !o.IsDeleted);

            return (OutstaffItemLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new OutstaffItemLocalizationDTO());
        }




        [HttpPost, Route("CreateOutstaffItem")]
        [OutstaffSectionAccess(5)]
        public async Task<OutstaffItemDTO> CreateOutstaffItem(OutstaffItemDTO model)
        {
            return (OutstaffItemDTO)DbService.TryCreateEntity(DB.OutstaffItems, model);
        }

        [HttpPost, Route("CreateOutstaffItemLocalization")]
        [OutstaffSectionAccess(5)]
        public async Task<OutstaffItemLocalizationDTO> CreateOutstaffItemLocalization(int itemId, OutstaffItemLocalizationDTO model)
        {
            var mainEntity = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
            return (OutstaffItemLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.OutstaffItems, mainEntity, model);
        }





        [HttpPut, Route("UpdateOutstaffItemMain")]
        [OutstaffSectionAccess(2)]
        public async Task<OutstaffItemDTO> UpdateOutstaffItemMain(OutstaffItemDTO model)
        {
            var item = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (OutstaffItemDTO)DbService.TryUpdateEntity(DB.OutstaffItems, model, item);
        }

        [HttpPut, Route("UpdateOutstaffItemLocalization")]
        [OutstaffSectionAccess(3)]
        public async Task<OutstaffItemLocalizationDTO> UpdateOutstaffColumnLocalization(OutstaffItemLocalizationDTO model)
        {
            var localization = DB.OutstaffItemLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == localization.OutstaffItemId && !o.IsDeleted);

            return (OutstaffItemLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.OutstaffItemLocalizations, localization, model, mainEntity);
        }





        [HttpDelete, Route("DeleteOutstaffItem")]
        [OutstaffSectionAccess(6)]
        public async Task DeleteOutstaffItem(int id)
        {
            var item = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.OutstaffItems, item);
        }

        [HttpDelete, Route("DeleteOutstaffItemLocalization")]
        [OutstaffSectionAccess(6)]
        public async Task DeleteOutstaffItemLocalization(int id)
        {
            var item = DB.OutstaffItemLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == item?.OutstaffItemId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.OutstaffItemLocalizations, item, mainModel);
        }

        #endregion

        #region Пункты услуг сетки аутстафф

        [HttpGet, Route("GetOutstaffItemGrade")]
        [OutstaffSectionAccess(1)]
        public async Task<OutstaffItemGradeDTO> GetOutstaffItemGrade(int id)
        {
            return (OutstaffItemGradeDTO)DbService.TryGetOne(DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades), id, new OutstaffItemGradeDTO());
        }



        [HttpGet, Route("GetOutstaffItemGradeLocalizations")]
        [OutstaffSectionAccess(1)]
        public async Task<IEnumerable<OutstaffItemGradeLocalizationDTO>> GetOutstaffItemGradeLocalizations(int id)
        {
            var localizations = DB.OutstaffItemGradeLocalizations.Include(o => o.LanguageEntity).Where(o => o.OutstaffItemGradeId == id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == id && !o.IsDeleted);

            return DbService.GetLocalizationModels(localizations, mainEntity, new OutstaffItemGradeLocalizationDTO()).Cast<OutstaffItemGradeLocalizationDTO>();
        }

        [HttpGet, Route("GetOutstaffItemGradeLocalization")]
        [OutstaffSectionAccess(1)]
        public async Task<OutstaffItemGradeLocalizationDTO> GetOutstaffItemGradeLocalization(int id)
        {
            var localization = DB.OutstaffItemGradeLocalizations.Include(o => o.LanguageEntity).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == localization?.OutstaffItemGradeId && !o.IsDeleted);

            return (OutstaffItemGradeLocalizationDTO)DbService.GetLocalizationModel(localization, mainEntity, new OutstaffItemGradeLocalizationDTO());
        }





        [HttpPost, Route("CreateOutstaffItemGrade")]
        [OutstaffSectionAccess(5)]
        public async Task<OutstaffItemGradeDTO> CreateOutstaffItemGrade(OutstaffItemGradeDTO model)
        {
            return (OutstaffItemGradeDTO)DbService.TryCreateEntity(DB.OutstaffItemGrades, model);
        }
     
        [HttpPost, Route("CreateOutstaffItemGradeLocalization")]
        [OutstaffSectionAccess(5)]
        public async Task<OutstaffItemGradeLocalizationDTO> CreateOutstaffItemGradeLocalization(int itemId, OutstaffItemGradeLocalizationDTO model)
        {
            var mainEntity = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
            return (OutstaffItemGradeLocalizationDTO)DbService.TryCreateLocalizationEntity(DB.OutstaffItemGrades, mainEntity, model);
        }







        [HttpPut, Route("UpdateOutstaffItemGradeMain")]
        [OutstaffSectionAccess(2)]
        public async Task<OutstaffItemGradeDTO> UpdateOutstaffItemGradeMain(OutstaffItemGradeDTO model)
        {
            var item = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (OutstaffItemGradeDTO)DbService.TryUpdateEntity(DB.OutstaffItemGrades, model, item);
        }
        [HttpPut, Route("UpdateOutstaffItemGradeLocalization")]
        [OutstaffSectionAccess(3)]
        public async Task<OutstaffItemGradeLocalizationDTO> UpdateOutstaffItemGradeLocalization(OutstaffItemGradeLocalizationDTO model)
        {
            var localization = DB.OutstaffItemGradeLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            var mainEntity = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == localization.OutstaffItemGradeId && !o.IsDeleted);

            return (OutstaffItemGradeLocalizationDTO)DbService.TryUpdateLocalizationEntity(DB.OutstaffItemGradeLocalizations, localization, model, mainEntity);
        }




        [HttpDelete, Route("DeleteOutstaffItemGrade")]
        [OutstaffSectionAccess(6)]
        public async Task DeleteOutstaffItemGrade(int id)
        {
            var item = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.OutstaffItemGrades, item);
        }

        [HttpDelete, Route("DeleteOutstaffItemGradeLocalization")]
        [OutstaffSectionAccess(6)]
        public async Task DeleteOutstaffItemGradeLocalization(int id)
        {
            var item = DB.OutstaffItemGradeLocalizations.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            var mainModel = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == item?.OutstaffItemGradeId && !o.IsDeleted);

            DbService.TryDeleteLocalizationEntity(DB.OutstaffItemGradeLocalizations, item, mainModel);
        }


        #endregion

        #region Колонки пунктов услуг сетки аутстафф

        [HttpGet, Route("GetOutstaffItemGradeColumn")]
        [OutstaffSectionAccess(1)]
        public async Task<OutstaffItemGradeColumnDTO> GetOutstaffItemGradeColumn(int id)
        {
            return (OutstaffItemGradeColumnDTO)DbService.TryGetOne(DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).SelectMany(o => o.Prices), id, new OutstaffItemGradeColumnDTO());
        }





        [HttpPost, Route("CreateOutstaffItemGradeColumn")]
        [OutstaffSectionAccess(5)]
        public async Task<OutstaffItemGradeColumnDTO> CreateOutstaffItemGradeColumn(OutstaffItemGradeColumnDTO model)
        {
            return (OutstaffItemGradeColumnDTO)DbService.TryCreateEntity(DB.OutstaffItemGradeColumns, model);
        }



        [HttpPut, Route("UpdateOutstaffItemGradeColumn")]
        [OutstaffSectionAccess(2)]
        public async Task<OutstaffItemGradeColumnDTO> UpdateOutstaffItemGradeColumn(OutstaffItemGradeColumnDTO model)
        {
            var item = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).SelectMany(o => o.Prices).FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (OutstaffItemGradeColumnDTO)DbService.TryUpdateEntity(DB.OutstaffItemGradeColumns, model, item);
        }



        [HttpDelete, Route("DeleteOutstaffItemGradeColumn")]
        [OutstaffSectionAccess(6)]
        public async Task DeleteOutstaffItemGradeColumn(int id)
        {
            var item = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).SelectMany(o => o.Prices).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.OutstaffItemGradeColumns, item);
        }



        #endregion



        #region Матрицы цен

        [HttpPut, Route("UpdatePricingMatrix")]
        [OutstaffSectionAccess(4)]
        public async Task<PricingMatrixDTO> UpdatePricingMatrix(PricingMatrixDTO model)
        {
            var matrix = DB.GetIncludedPricingMatrix(model.Id);
            return (PricingMatrixDTO)DbService.TryUpdateEntity(DB.PricingMatrices, model, matrix);
        }

        [HttpPut, Route("SetDefaultCellPricingMatrix")]
        [OutstaffSectionAccess(4)]
        public async Task<PricingMatrixDTO> SetDefaultProductPricingMatrix(int cellId)
        {
            var column = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades)
                                               .SelectMany(o => o.Prices)
                                               .FirstOrDefault(o => o.Id == cellId && !o.IsDeleted);

            if(column is null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }

            column.CostPerHour = CreateDefaultPricingMatrix();
            DbService.UpdateEntity(DB.OutstaffItemGradeColumns, column);

            return (PricingMatrixDTO)new PricingMatrixDTO().CreateDTO(column.CostPerHour);
        }

        #endregion




    }
}
