using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters.CertCenter;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DTO;
using Alfateam.CertificationCenter.Models.DTO.Abstractions;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.CertCenter
{
    [Route("CertCenter/[controller]")]
    public class CertCenterCertificatesController : AbsCertCenterController
    {
        public CertCenterCertificatesController(ControllerParams @params) : base(@params)
        {
        }

        #region Выпущенные ЭЦП

        [HttpGet, Route("GetEDSList")]
        public async Task<ItemsWithTotalCount<AlfateamEDSDTO>> GetIssueRequests(CertCenterEDSSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<AlfateamEDS, AlfateamEDSDTO>(GetAvailableEDSList(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.OwnerStringInfo.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (!string.IsNullOrEmpty(filter.AlfateamId))
                {
                    condition &= entity.OwnerAlfateamID == filter.AlfateamId;
                }
                if(filter.ValidFromPeriod != null)
                {
                    var period = filter.ValidFromPeriod.GetPeriod();
                    condition &= entity.ValidFrom >= period.From && entity.ValidFrom <= period.To;
                }
                if (filter.ValidBeforePeriod != null)
                {
                    var period = filter.ValidBeforePeriod.GetPeriod();
                    condition &= entity.ValidBefore >= period.From && entity.ValidBefore <= period.To;
                }
                if (filter.RevokedAtPeriod != null)
                {
                    var period = filter.RevokedAtPeriod.GetPeriod();
                    condition &= entity.RevokedAt >= period.From && entity.RevokedAt <= period.To;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetEDS")]
        public async Task<AlfateamEDSDTO> GetIssueRequest(int id)
        {
            return (AlfateamEDSDTO)DBService.TryGetOne(GetAvailableEDSList(), id, new AlfateamEDSDTO());
        }

        #endregion

        #region Выпущенные электронные доверенности

        [HttpGet, Route("GetPOAList")]
        public async Task<ItemsWithTotalCount<AlfateamDigitalPOADTO>> GetPOAList(CertCenterPOASearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<AlfateamDigitalPOA, AlfateamDigitalPOADTO>(GetAvailablePOAList(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.OwnerStringInfo.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (!string.IsNullOrEmpty(filter.AlfateamId))
                {
                    condition &= entity.OwnerAlfateamID == filter.AlfateamId;
                }
                if (filter.IssuedAtPeriod != null)
                {
                    var period = filter.IssuedAtPeriod.GetPeriod();
                    condition &= entity.IssuedAt >= period.From && entity.IssuedAt <= period.To;
                }
                if (filter.ValidBeforePeriod != null)
                {
                    var period = filter.ValidBeforePeriod.GetPeriod();
                    condition &= entity.ValidBefore >= period.From && entity.ValidBefore <= period.To;
                }
                if (filter.RevokedAtPeriod != null)
                {
                    var period = filter.RevokedAtPeriod.GetPeriod();
                    condition &= entity.RevokedAt >= period.From && entity.RevokedAt <= period.To;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetPOA")]
        public async Task<AlfateamDigitalPOADTO> GetPOA(int id)
        {
            return (AlfateamDigitalPOADTO)DBService.TryGetOne(GetAvailablePOAList(), id, new AlfateamDigitalPOADTO());
        }

        #endregion








        #region Private methods
        private IEnumerable<AlfateamEDS> GetAvailableEDSList()
        {
            return CertCenterDb.AlfateamEDSs.Where(o => !o.IsDeleted);
        }

        private IEnumerable<AlfateamDigitalPOA> GetAvailablePOAList()
        {
            return CertCenterDb.AlfateamDigitalPOA.Where(o => !o.IsDeleted);
        }

        #endregion

    }
}
