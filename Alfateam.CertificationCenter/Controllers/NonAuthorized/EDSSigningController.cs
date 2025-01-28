using Alfateam.CertGenerators;
using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.API.Models.EDSSigning;
using Alfateam.CertificationCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CertificationCenter.API.Controllers.NonAuthorized
{
    public class EDSSigningController : AbsController
    {
        public EDSSigningController(ControllerParams @params) : base(@params)
        {
        }

        [HttpPost, Route("Sign")]
        public async Task<byte[]> SignStringData(SignStringData model)
        {
            return AlfateamEDSGenerator.SignData(model.Data, model.Certificate, model.Password);
        }

        [HttpPost, Route("SignBytesArrayData")]
        public async Task<byte[]> SignBytesArrayData(SignBytesArrayData model)
        {
            return AlfateamEDSGenerator.SignData(model.Data, model.Certificate, model.Password);
        }
    }
}
