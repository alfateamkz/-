using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.API.Abstractions;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.DTO;
using Alfateam.CertificationCenter.Models.DTO.General.Biometric;
using Alfateam.CertificationCenter.Models.General.Biometric;
using Alfateam.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.CertificationCenter.API.Controllers
{
    public class CommonController : AbsAuthorizedController
    {
        public CommonController(ControllerParams @params) : base(@params)
        {
        }

        [HttpPost, Route("UploadFile")]
        public async Task<UploadedFileDTO> UploadFile([FromQuery] FileType fileType, IFormFile file)
        {
            var uploadedFile = new UploadedFile
            {
                RelativePath = FilesService.TryUploadFile(file, fileType)
            };
            DBService.CreateEntity(DB.UploadedFiles, uploadedFile);
            return (UploadedFileDTO)new UploadedFileDTO().CreateDTO(uploadedFile);
        }

        [HttpPost, Route("StartBiometricIdentification")]
        public async Task<BiometricIdentificationRequestDTO> StartBiometricIdentification()
        {
            var actions = DB.BiometricIdentificationActions.Where(o => !o.IsDeleted).ToList();
            var actionsCount = actions.Count;
            if(actionsCount > 2)
            {
                actionsCount = 2;
            }

            var identificationRequest = new BiometricIdentificationRequest();
            while(identificationRequest.RandomActions.Count < actionsCount)
            {
                var randomAction = actions[Random.Shared.Next(0, actions.Count - 1)];
                if(!identificationRequest.RandomActions.Any(o => o.ActionId == randomAction.Id))
                {
                    identificationRequest.RandomActions.Add(new BiometricIdentificationRequestAction
                    {
                        Action = randomAction,
                        DurationInSeconds = 8
                    });
                }
            }

            DBService.CreateEntity(DB.BiometricIdentificationRequests, identificationRequest);
            return (BiometricIdentificationRequestDTO)new BiometricIdentificationRequestDTO().CreateDTO(identificationRequest);
        }

    }
}
