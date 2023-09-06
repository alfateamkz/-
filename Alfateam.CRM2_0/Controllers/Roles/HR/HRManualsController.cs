using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Content.Videos;
using Alfateam.CRM2_0.Models.ClientModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.Content.Videos;
using Alfateam.CRM2_0.Models.CreateModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.EditModels.Content.Videos;
using Alfateam.CRM2_0.Models.EditModels.Roles.HR.Manuals;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.HR.Manuals;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CRM2_0.Controllers.Roles.HR
{

    [AccessActionFilter(roles: UserRole.HR)]
    [DepartmentFilter]
    public class HRManualsController : AbsController
    {
        public HRManualsController(ControllerParams @params) : base(@params)
        {
        }

        //TODO: добавить методы получения по цепочке вверх

        #region Методички для HR

        [HttpGet, Route("GetHRManuals")]
        public async Task<RequestResult> GetHRManuals(int offset, int count = 20)
        {
            return GetMany<HRManual, HRManualClientModel>(DB.HRManuals.Where(o => o.HRDepartmentId == this.DepartmentId), offset, count);
        }


        [HttpGet, Route("GetHRManual")]
        public async Task<RequestResult> GetHRManual(int id)
        {
            return TryGetModel(DB.HRManuals.Where(o => o.HRDepartmentId == this.DepartmentId), id);
        }




        [HttpPost, Route("CreateHRManual")]
        public async Task<RequestResult> CreateHRManual(HRManualCreateModel model)
        {         
            return TryCreateModel(DB.HRManuals, model, (item) =>
            {
                item.HRDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }



        [HttpPut, Route("UpdateHRManual")]
        public async Task<RequestResult> UpdateHRManual(HRManualEditModel model)
        {
            return TryUpdateModel(DB.HRManuals, model);
        }


        [HttpDelete, Route("DeleteHRManual")]
        public async Task<RequestResult> DeleteHRManual(int id)
        {
            return TryDeleteModel(DB.HRManuals, id);
        }

        #endregion

        #region Категории методичек для HR

        [HttpGet, Route("GetHRManualCategories")]
        public async Task<RequestResult> GetHRManualCategories(int offset, int count = 20)
        {
            return GetMany<HRManualCategory, HRManualCategoryClientModel>(DB.HRManualCategories.Where(o => o.HRDepartmentId == this.DepartmentId), offset, count);
        }


        [HttpGet, Route("GetHRManualCategory")]
        public async Task<RequestResult> GetHRManualCategory(int id)
        {
            return TryGetModel(DB.HRManualCategories.Where(o => o.HRDepartmentId == this.DepartmentId), id);
        }




        [HttpPost, Route("CreateHRManualCategory")]
        public async Task<RequestResult> CreateHRManualCategory(HRManualCategoryCreateModel model)
        {
            return TryCreateModel(DB.HRManualCategories, model, (item) =>
            {
                item.HRDepartmentId = (int)this.DepartmentId;
                return RequestResult.AsSuccess();
            });
        }



        [HttpPut, Route("UpdateHRManualCategory")]
        public async Task<RequestResult> UpdateHRManualCategory(HRManualCategoryEditModel model)
        {
            return TryUpdateModel(DB.HRManualCategories, model);
        }


        [HttpDelete, Route("DeleteHRManualCategory")]
        public async Task<RequestResult> DeleteHRManualCategory(int id)
        {
            return TryDeleteModel(DB.HRManualCategories, id);
        }

        #endregion

        
    }
}
