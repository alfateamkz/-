using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CertificationCenter.Controllers
{
    public class DigitalPOAController : AbsController
    {
        public DigitalPOAController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetPOAList")]
        public async Task<IEnumerable<AlfateamDigitalPOADTO>> GetPOAList()
        {
            var payments = DB.AlfateamDigitalPOA.Where(o => o.OwnerAlfateamID == this.AlfateamSession.User.Guid && !o.IsDeleted);
            return new AlfateamDigitalPOADTO().CreateDTOs(payments).Cast<AlfateamDigitalPOADTO>();
        }


    }
}
