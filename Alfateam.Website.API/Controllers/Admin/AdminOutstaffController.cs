using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.General;
using Alfateam.Website.API.Models.Core;
using Alfateam.Website.API.Models.EditModels.Outstaff;
using Alfateam.Website.API.Models.EditModels.Shop;
using Alfateam.Website.API.Models.LocalizationEditModels.Outstaff;
using Alfateam.Website.API.Models.LocalizationEditModels.Shop;
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
        //TODO: реализовать методы isValid для сущностей сетки
        public AdminOutstaffController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {

        }

        #region Сетка аутстафф


        [HttpGet, Route("GetOutstaffMatrix")]
        public async Task<RequestResult<OutstaffMatrix>> GetOutstaffMatrix()
        {
            return TryFinishAllRequestes<OutstaffMatrix>(new[]
            {
                () => CheckAccess(1),
                () => RequestResult<OutstaffMatrix>.AsSuccess(DB.GetOutstaffMatrix())
            });
        }

        #endregion

        #region Колонки сетки аутстафф

        [HttpGet, Route("GetOutstaffColumn")]
        public async Task<RequestResult<OutstaffColumn>> GetOutstaffColumn(int id)
        {
            var column = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryGetOutstaffModel(column);
        }

        [HttpGet, Route("GetOutstaffColumnLocalization")]
        public async Task<RequestResult<OutstaffColumnLocalization>> GetOutstaffColumnLocalization(int id)
        {
            var localization = DB.GetOutstaffMatrix().Columns.Where(o => !o.IsDeleted)
                                                             .SelectMany(o => o.Localizations)
                                                             .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryGetOutstaffModel(localization);
        }




        [HttpPost, Route("CreateOutstaffColumn")]
        public async Task<RequestResult<OutstaffColumn>> CreateOutstaffColumn(OutstaffColumn item)
        {
            return TryFinishAllRequestes<OutstaffColumn>(new[]
            {
                () => CheckAccess(5),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var matrix = DB.GetOutstaffMatrix();
                    matrix.Columns.Add(item);
                    return UpdateModel(DB.OutstaffMatrices, matrix);
                }
           });
        }
     
        [HttpPost, Route("CreateOutstaffColumnLocalization")]
        public async Task<RequestResult<OutstaffColumnLocalization>> CreateOutstaffColumnLocalization(int itemId, OutstaffColumnLocalization localization)
        {
            var column = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
            return TryFinishAllRequestes<OutstaffColumnLocalization>(new[]
            {
                () => CheckAccess(5),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => RequestResult.FromBoolean(column != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    column.Localizations.Add(localization);
                    return UpdateModel(DB.OutstaffColumns, column);
                }
           });
        }





        [HttpPut, Route("UpdateOutstaffColumnMain")]
        public async Task<RequestResult<OutstaffColumn>> UpdateOutstaffColumnMain(OutstaffColumnMainEditModel model)
        {
            var column = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryUpdateOutstaffModel(DB.OutstaffColumns, model, column);
        }
        [HttpPut, Route("UpdateOutstaffColumnLocalization")]
        public async Task<RequestResult<OutstaffColumnLocalization>> UpdateOutstaffColumnLocalization(OutstaffColumnLocalizationEditModel model)
        {
            var localization = DB.OutstaffColumnLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryUpdateOutstaffLocalizationModel(DB.OutstaffColumnLocalizations, model, localization);
        }







        [HttpDelete, Route("DeleteOutstaffColumn")]
        public async Task<RequestResult> DeleteOutstaffColumn(int id)
        {
            var column = DB.GetOutstaffMatrix().Columns.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryDeleteOutstaffModel(DB.OutstaffColumns, column);
        }

        [HttpDelete, Route("DeleteOutstaffColumnLocalization")]
        public async Task<RequestResult> DeleteOutstaffColumnLocalization(int id)
        {
            var localization = DB.GetOutstaffMatrix().Columns.Where(o => !o.IsDeleted)
                                                             .SelectMany(o => o.Localizations)
                                                             .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryDeleteOutstaffModel(DB.OutstaffColumnLocalizations, localization, false);
        }


        #endregion

        #region Услуги сетки аутстафф

        [HttpGet, Route("GetOutstaffItem")]
        public async Task<RequestResult<OutstaffItem>> GetOutstaffItem(int id)
        {
            var item = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryGetOutstaffModel(item);
        }

        [HttpGet, Route("GetOutstaffItemLocalization")]
        public async Task<RequestResult<OutstaffItemLocalization>> GetOutstaffItemLocalization(int id)
        {
            var item = DB.GetOutstaffMatrix().Items.Where(o => !o.IsDeleted)
                                                   .SelectMany(o => o.Localizations)
                                                   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryGetOutstaffModel(item);
        }




        [HttpPost, Route("CreateOutstaffItem")]
        public async Task<RequestResult<OutstaffItem>> CreateOutstaffItem(OutstaffItem item)
        {
            return TryFinishAllRequestes<OutstaffItem>(new[]
            {
                () => CheckAccess(5),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var matrix = DB.GetOutstaffMatrix();
                    matrix.Items.Add(item);
                    return UpdateModel(DB.OutstaffMatrices, matrix);
                }
           });
        }

        [HttpPost, Route("CreateOutstaffItemLocalization")]
        public async Task<RequestResult<OutstaffItemLocalization>> CreateOutstaffItemLocalization(int itemId, OutstaffItemLocalization localization)
        {
            var outstaffItem = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
            return TryFinishAllRequestes<OutstaffItemLocalization>(new[]
            {
                () => CheckAccess(5),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => RequestResult.FromBoolean(outstaffItem != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    outstaffItem.Localizations.Add(localization);
                    return UpdateModel(DB.OutstaffItems, outstaffItem);
                }
           });
        }





        [HttpPut, Route("UpdateOutstaffItemMain")]
        public async Task<RequestResult<OutstaffItem>> UpdateOutstaffItemMain(OutstaffItemMainEditModel model)
        {
            var item = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryUpdateOutstaffModel(DB.OutstaffItems, model, item);
        }

        [HttpPut, Route("UpdateOutstaffItemLocalization")]
        public async Task<RequestResult<OutstaffItemLocalization>> UpdateOutstaffColumnLocalization(OutstaffItemLocalizationEditModel model)
        {
            var localization = DB.OutstaffItemLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryUpdateOutstaffLocalizationModel(DB.OutstaffItemLocalizations, model, localization);
        }





        [HttpDelete, Route("DeleteOutstaffItem")]
        public async Task<RequestResult> DeleteOutstaffItem(int id)
        {
            var item = DB.GetOutstaffMatrix().Items.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryDeleteOutstaffModel(DB.OutstaffItems, item);
        }

        [HttpDelete, Route("DeleteOutstaffItemLocalization")]
        public async Task<RequestResult> DeleteOutstaffItemLocalization(int id)
        {
            var item = DB.GetOutstaffMatrix().Items.Where(o => !o.IsDeleted)
                                                   .SelectMany(o => o.Localizations)
                                                   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryDeleteOutstaffModel(DB.OutstaffItemLocalizations, item, false);
        }

        #endregion

        #region Пункты услуг сетки аутстафф

        [HttpGet, Route("GetOutstaffItemGrade")]
        public async Task<RequestResult<OutstaffItemGrade>> GetOutstaffItemGrade(int id)
        {
            var grade = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryGetOutstaffModel(grade);
        }
  
        [HttpGet, Route("GetOutstaffItemGradeLocalization")]
        public async Task<RequestResult<OutstaffItemGradeLocalization>> GetOutstaffItemGradeLocalization(int id)
        {
            var localization = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades)  
                                                           .Where(o => !o.IsDeleted)
                                                           .SelectMany(o => o.Localizations)
                                                           .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryGetOutstaffModel(localization);
        }





        [HttpPost, Route("CreateOutstaffItemGrade")]
        public async Task<RequestResult<OutstaffItemGrade>> CreateOutstaffItemGrade(int itemId,OutstaffItemGrade item)
        {
            var outstaffItem = DB.OutstaffItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
            return TryFinishAllRequestes<OutstaffItemGrade>(new[]
            {
                () => CheckAccess(5),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => RequestResult.FromBoolean(outstaffItem != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    outstaffItem.Grades.Add(item);
                    return UpdateModel(DB.OutstaffItems, outstaffItem);
                }
           });
        }
     
        [HttpPost, Route("CreateOutstaffItemGradeLocalization")]
        public async Task<RequestResult<OutstaffItemGradeLocalization>> CreateOutstaffItemGradeLocalization(int itemId, OutstaffItemGradeLocalization localization)
        {
            var grade = DB.OutstaffItemGrades.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
            return TryFinishAllRequestes<OutstaffItemGradeLocalization>(new[]
            {
                () => CheckAccess(5),
                () => RequestResult.FromBoolean(localization.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => RequestResult.FromBoolean(grade != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    grade.Localizations.Add(localization);
                    return UpdateModel(DB.OutstaffItemGrades, grade);
                }
           });
        }







        [HttpPut, Route("UpdateOutstaffItemGradeMain")]
        public async Task<RequestResult<OutstaffItemGrade>> UpdateOutstaffItemGradeMain(OutstaffItemGradeMainEditModel model)
        {
            var grade = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryUpdateOutstaffModel(DB.OutstaffItemGrades, model, grade);
        }
        [HttpPut, Route("UpdateOutstaffItemGradeLocalization")]
        public async Task<RequestResult<OutstaffItemGradeLocalization>> UpdateOutstaffItemGradeLocalization(OutstaffItemGradeLocalizationEditModel model)
        {
            var localization = DB.OutstaffItemGradeLocalizations.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryUpdateOutstaffLocalizationModel(DB.OutstaffItemGradeLocalizations, model, localization);
        }




        [HttpDelete, Route("DeleteOutstaffItemGrade")]
        public async Task<RequestResult> DeleteOutstaffItemGrade(int id)
        {
            var grade = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryDeleteOutstaffModel(DB.OutstaffItemGrades, grade);
        }

        [HttpDelete, Route("DeleteOutstaffItemGradeLocalization")]
        public async Task<RequestResult> DeleteOutstaffItemGradeLocalization(int id)
        {
            var localization = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades)
                                                           .Where(o => !o.IsDeleted)
                                                           .SelectMany(o => o.Localizations)
                                                           .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryDeleteOutstaffModel(DB.OutstaffItemGradeLocalizations, localization, false);
        }


        #endregion

        #region Колонки пунктов услуг сетки аутстафф

        [HttpGet, Route("GetOutstaffItemGradeColumn")]
        public async Task<RequestResult<OutstaffItemGradeColumn>> GetOutstaffItemGradeColumn(int id)
        {
            var column = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades)
                                                     .SelectMany(o => o.Prices)
                                                     .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryGetOutstaffModel(column);
        }





        [HttpPost, Route("CreateOutstaffItemGradeColumn")]
        public async Task<RequestResult<OutstaffItemGrade>> CreateOutstaffItemGradeColumn(int gradeId, OutstaffItemGradeColumn item)
        {
            var grade = DB.OutstaffItemGrades.FirstOrDefault(o => o.Id == gradeId && !o.IsDeleted);
            return TryFinishAllRequestes<OutstaffItemGrade>(new[]
            {
                () => CheckAccess(5),
                () => RequestResult.FromBoolean(item.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => RequestResult.FromBoolean(grade != null, 404, "Сущность с данным id не найдена"),
                () =>
                {
                    grade.Prices.Add(item);
                    return UpdateModel(DB.OutstaffItemGrades, grade);
                }
           });
        }



        [HttpPut, Route("UpdateOutstaffItemGradeColumn")]
        public async Task<RequestResult<OutstaffItemGradeColumn>> UpdateOutstaffItemGradeColumn(OutstaffItemGradeColumnEditModel model)
        {
            var column = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades)
                                                  .SelectMany(o => o.Prices)
                                                  .FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return TryUpdateOutstaffModel(DB.OutstaffItemGradeColumns, model, column);
        }



        [HttpDelete, Route("DeleteOutstaffItemGradeColumn")]
        public async Task<RequestResult> DeleteOutstaffItemGradeColumn(int id)
        {
            var column = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades)
                                                     .SelectMany(o => o.Prices)
                                                     .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryDeleteOutstaffModel(DB.OutstaffItemGradeColumns, column);
        }



        #endregion



        #region Матрицы цен

        [HttpPut, Route("UpdatePricingMatrix")]
        public async Task<RequestResult<PricingMatrix>> UpdatePricingMatrix(PricingMatrixEditModel model)
        {
            var matrix = DB.GetIncludedPricingMatrix(model.Id);

            return TryFinishAllRequestes<PricingMatrix>(new[]
            {
                () => CheckAccess(7),
                () => RequestResult.FromBoolean(matrix != null, 404, "Запись по данному id не найдена"),
                () => RequestResult.FromBoolean(matrix.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () => UpdateModel(DB.PricingMatrices, model, matrix)
            });
        }

        [HttpPut, Route("SetDefaultCellPricingMatrix")]
        public async Task<RequestResult<PricingMatrix>> SetDefaultProductPricingMatrix(int cellId)
        {
            var column = DB.GetOutstaffMatrix().Items.SelectMany(o => o.Grades)
                                               .SelectMany(o => o.Prices)
                                               .FirstOrDefault(o => o.Id == cellId && !o.IsDeleted);

            return TryFinishAllRequestes<PricingMatrix>(new[]
            {
                () => CheckAccess(4),
                () => RequestResult.FromBoolean(column != null, 404, "Сущность по данному id не найдена"),
                () =>
                {
                    column.CostPerHour = CreateDefaultPricingMatrix();
                    return UpdateModel(DB.OutstaffItemGradeColumns,column);
                }
            });
        }

        #endregion



        #region Private check access methods

        private RequestResult CheckAccess(int requiredLevel)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(session.User.RoleModel.Role != UserRole.User,
                        403, "У данного пользователя нет доступа в администраторскую панель"),
                () => CheckSession(session),
                () => RequestResult.FromBoolean(session.User.RoleModel.OutstaffAccess.AccessLevel >= requiredLevel || session.User.RoleModel.Role == UserRole.Owner,
                       403, "У данного пользователя нет прав на выполнение данного действия")
             });
        }

        private RequestResult<T> TryGetOutstaffModel<T>(T item)
        {
            return TryFinishAllRequestes<T>(new[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult<T>.AsSuccess(item)
            });
        }
        private RequestResult<T> TryDeleteOutstaffModel<T>(DbSet<T> dbSet,T item,bool softDelete = true) where T: AbsModel
        {
            return TryFinishAllRequestes<T>(new[]
            {
                 () => CheckAccess(6),
                 () => RequestResult.FromBoolean(item != null,404, "Сущность с данным id не найдена"),
                 () => DeleteModel(dbSet, item, softDelete)
            });
        }


        private RequestResult<T> TryUpdateOutstaffModel<T>(DbSet<T> dbSet, EditModel<T> model, T localization) where T : AbsModel
        {
            return TryFinishAllRequestes<T>(new[]
            {
                 () => CheckAccess(2),
                 () => RequestResult.FromBoolean(localization != null, 404, "Локализация с данным id не найдена"),
                 () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения данных"),
                 () => UpdateModel(dbSet, model, localization)
            });
        }
        private RequestResult<T> TryUpdateOutstaffLocalizationModel<T>(DbSet<T> dbSet, LocalizationEditModel<T> model, T localization) where T : AbsModel
        {
            return TryFinishAllRequestes<T>(new[]
            {
                 () => CheckAccess(3),
                 () => RequestResult.FromBoolean(localization != null, 404, "Локализация с данным id не найдена"),
                 () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения данных"),
                 () => UpdateModel(dbSet, model, localization)
            });
        }

        #endregion


    }
}
