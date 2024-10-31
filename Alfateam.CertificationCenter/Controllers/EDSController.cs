using Alfateam.CertificationCenter.Abstractions;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.Models.DTO;
using Alfateam.CertificationCenter.Models.DTO.IssueRequests;
using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.Core.Enums;
using Alfateam.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.CertificationCenter.Controllers
{
    public class EDSController : AbsController
    {
        public EDSController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetEDSList")]
        public async Task<IEnumerable<AlfateamEDSDTO>> GetEDSList()
        {
            var payments = DB.AlfateamEDSs.Where(o => o.OwnerAlfateamID == this.AlfateamSession.User.Guid && !o.IsDeleted);
            return new AlfateamEDSDTO().CreateDTOs(payments).Cast<AlfateamEDSDTO>();
        }


        [HttpPost, Route("SendIssueRequest")]
        [SwaggerOperation(Description = "Надо обязательно залить следующие файлы: \r\n" +
            "1. список фото документа лица, кто подает заявление, список файлов по имени PersonalDocumentImages_{номер} \r\n" +
            "2. видеозапись документа - видео по имени PersonalDocumentVideo \r\n" +
            "3. биометрия (видеозапись ебала) - видео по имени PersonalBiometryVideo \r\n" +
            "4. Если ЭЦП для компании, то список фото по имени CompanyDocumentImages_{номер} \r\n" +
            "5. Если ЭЦП для компании, то видеозапись документа - видео по имени CompanyDocumentVideo \r\n")]
        public async Task SendIssueRequest([FromForm(Name = "model")]EDSIssueRequestDTO model)
        {
            DBService.TryCreateEntity(DB.IssueRequests, model, async (entity) =>
            {
                var issueRequest = entity as EDSIssueRequest;

                if (model.LatitudeFrom < -180 || model.LatitudeFrom > 180)
                {
                    throw new Exception400("Поле Latitude должно быть в диапазоне от -180 до 180");
                }
                else if (model.LongitudeFrom < -180 || model.LongitudeFrom > 180)
                {
                    throw new Exception400("Поле Latitude должно быть в диапазоне от -180 до 180");
                }
                else if(!Request.Form.Files.Any(o => o.Name.StartsWith("PersonalDocumentImages_")))
                {
                    throw new Exception400("Не прикреплено ни одно фото документа заявителя");
                }
                else if (!Request.Form.Files.Any(o => o.Name == "PersonalDocumentVideo"))
                {
                    throw new Exception400("Не прикреплено видео документа заявителя");
                }
                else if (!Request.Form.Files.Any(o => o.Name == "PersonalBiometryVideo"))
                {
                    throw new Exception400("Не прикреплено видео биометрии (видеозаписи ебала) заявителя");
                }
                else if (!Request.Form.Files.Any(o => o.Name.StartsWith("CompanyDocumentImages_"))
                           && model.EDSFor == EDSFor.Business)
                {
                    throw new Exception400("Не прикреплено ни одно фото документа компании");
                }
                else if (!Request.Form.Files.Any(o => o.Name == "CompanyDocumentVideo")
                          && model.EDSFor == EDSFor.Business)
                {
                    throw new Exception400("Не прикреплено видео документа компании");
                }






                foreach(var file in Request.Form.Files.Where(o => o.Name.StartsWith("PersonalDocumentImages_")))
                {
                    issueRequest.PersonalDocumentImages.Add(new Models.Files.AttachedImage
                    {
                        FilePath = FilesService.TryUploadFile(file, FileType.Image)
                    });
                }
                issueRequest.PersonalDocumentVideo = new Models.Files.AttachedVideo
                {
                    FilePath = FilesService.TryUploadFile("PersonalDocumentVideo", FileType.Video)
                };
                issueRequest.PersonalBiometryVideo = new Models.Files.AttachedVideo
                {
                    FilePath = FilesService.TryUploadFile("PersonalBiometryVideo", FileType.Video)
                };



                if(model.EDSFor == EDSFor.Business)
                {
                    foreach (var file in Request.Form.Files.Where(o => o.Name.StartsWith("CompanyDocumentImages_")))
                    {
                        issueRequest.CompanyDocumentImages.Add(new Models.Files.AttachedImage
                        {
                            FilePath = FilesService.TryUploadFile(file, FileType.Image)
                        });
                    }

                    issueRequest.CompanyDocumentVideo = new Models.Files.AttachedVideo
                    {
                        FilePath = FilesService.TryUploadFile("CompanyDocumentVideo", FileType.Video)
                    };
                }




                entity.AlfateamIDFrom = this.AlfateamSession.User.Guid;
                entity.StatusInfo = new IssueRequestInfo
                {
                    Status = Models.Enums.IssueRequestStatus.Waiting
                };




            });
        }



    }
}
