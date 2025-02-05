using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.CertificationCenter.Models.DTO.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.Core;
using Alfateam.Sales.Models.Customers.Categories;
using Alfateam.Sales.Models.Customers.Other;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.CertCenter.Owner
{
    [Route("CertCenter/Owner/[controller]")]
    public class CertCenterBiometricActionsController : AbsCertCenterController
    {
        public CertCenterBiometricActionsController(ControllerParams @params) : base(@params)
        {
        }

        #region Биометрические действия


        [HttpGet, Route("GetActions")]
        public async Task<ItemsWithTotalCount<BiometricIdentificationActionDTO>> GetActions(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BiometricIdentificationAction, BiometricIdentificationActionDTO>(GetAvailableActions(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<BiometricIdentificationActionDTO> GetCategory(int id)
        {
            return (BiometricIdentificationActionDTO)DBService.TryGetOne(GetAvailableActions(), id, new BiometricIdentificationActionDTO());
        }





        [HttpPost, Route("CreateAction")]
        public async Task<BiometricIdentificationActionDTO> CreateAction(BiometricIdentificationActionDTO model)
        {
            return (BiometricIdentificationActionDTO)DBService.TryCreateEntity(CertCenterDb.BiometricIdentificationActions, model, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление биометрического действия", $"Добавлено биометрическое действие {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateAction")]
        public async Task<BiometricIdentificationActionDTO> UpdateAction(BiometricIdentificationActionDTO model)
        {
            var item = GetAvailableActions().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BiometricIdentificationActionDTO)DBService.TryUpdateEntity(CertCenterDb.BiometricIdentificationActions, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование биометрического действия", $"Отредактировано биометрическое действие с id={item.Id}");
            });
        }


        [HttpDelete, Route("DeleteAction")]
        public async Task DeleteAction(int id)
        {
            var item = GetAvailableActions().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(CertCenterDb.BiometricIdentificationActions, item);

            this.AddHistoryAction("Удаление биометрического действия", $"Удалено биометрическое действие  {item.Title} с id={id}");
        }

        #endregion





        #region Private methods
        private IEnumerable<BiometricIdentificationAction> GetAvailableActions()
        {
            return CertCenterDb.BiometricIdentificationActions.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
