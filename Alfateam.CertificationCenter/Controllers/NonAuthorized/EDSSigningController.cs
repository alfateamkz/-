using Alfateam.CertGenerators;
using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.API.Models.EDSSigning;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.DTO;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CertificationCenter.API.Controllers.NonAuthorized
{
    public class EDSSigningController : AbsController
    {
        public EDSSigningController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetDigitalPOA")]
        public async Task<AlfateamDigitalPOADTO> GetDigitalPOA(string serialNumber)
        {
            var eds = DB.AlfateamDigitalPOA.FirstOrDefault(o => o.SerialNumber == serialNumber);
            if (eds == null)
            {
                throw new Exception404("Доверенность с данным серийным номером не выпускалась");
            }
            return (AlfateamDigitalPOADTO)new AlfateamDigitalPOADTO().CreateDTO(eds);
        }

        [HttpGet, Route("GetAlfateamEDS")]
        public async Task<AlfateamEDSDTO> GetAlfateamEDS(string serialNumber)
        {
            var eds = DB.AlfateamEDSs.FirstOrDefault(o => o.EDSSerialNumber == serialNumber);
            if(eds == null)
            {
                throw new Exception404("ЭЦП с данным серийным номером не выпускалась");
            }
            return (AlfateamEDSDTO)new AlfateamEDSDTO().CreateDTO(eds);
        }

        [HttpPost, Route("SendSignature")]
        public async Task SendSignature(string returnParameter, string publicKey, EDSSignedType edsType, byte[] signature)
        {
            DBService.CreateEntity(DB.SentSignaturesFromApp, new SentSignatureFromApp
            {
                EDSType = edsType,
                Signature = signature,
                ReturnParameter = returnParameter,
                PublicKey = publicKey,
            });
        }



        //[HttpPost, Route("Sign")]
        //public async Task<byte[]> SignStringData(SignStringData model)
        //{
        //    return AlfateamEDSGenerator.SignData(model.Data, model.Certificate, model.Password);
        //}

        //[HttpPost, Route("SignBytesArrayData")]
        //public async Task<byte[]> SignBytesArrayData(SignBytesArrayData model)
        //{
        //    return AlfateamEDSGenerator.SignData(model.Data, model.Certificate, model.Password);
        //}
    }
}
