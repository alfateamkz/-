using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.EDM
{
    [Route("Products/EDM/[controller]")]
    public class EDMPOAVerificationRequestsController : AbsController
    {
        public EDMPOAVerificationRequestsController(ControllerParams @params) : base(@params)
        {
        }


        #region Доверенности на верификации

        [HttpGet, Route("GetPOAList")]
        public async Task<ItemsWithTotalCount<PowerOfAttorneyDTO>> GetPOAList([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<PowerOfAttorney, PowerOfAttorneyDTO>(GetAvailablePOAList(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.PrincipalBusinessNumber.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetPOA")]
        public async Task<PowerOfAttorneyDTO> GetPOA(int id)
        {
            return (PowerOfAttorneyDTO)DBService.TryGetOne(GetAvailablePOAList(), id, new PowerOfAttorneyDTO());
        }

        [HttpPut, Route("SetVerificationStatus")]
        public async Task SetVerificationStatus(int poaId, PowerOfAttorneyVerificationInfoDTO model)
        {
            var poa = DBService.TryGetOne(GetAvailablePOAList(), poaId);
            if(poa.VerificationInfo.Status != PowerOfAttorneyVerificationStatus.Waiting)
            {
                throw new Exception400("Уже был ранее установлен статус верификации доверенности");
            }

            poa.VerificationInfo.Status = model.Status;
            poa.VerificationInfo.Comment = model.Comment;
            DBService.UpdateEntity(EDMDb.PowersOfAttorney, poa);
        }


        #endregion









        #region Private methods
        private IEnumerable<PowerOfAttorney> GetAvailablePOAList()
        {
            return EDMDb.PowersOfAttorney.Include(o => o.VerificationInfo)
                                         .Where(o => !o.IsDeleted && o.VerificationInfo.Status == PowerOfAttorneyVerificationStatus.Waiting);
        }


        #endregion
    }
}
