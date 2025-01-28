using Alfateam.CertificationCenter.API.Filters;
using Alfateam.CertificationCenter.API.Services;
using Alfateam.CertificationCenter.Models;
using Alfateam.Core.Exceptions;
using Alfateam.Core.Filters;
using Alfateam.Core.Helpers;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models.Enums;
using Alfateam.ID.Models.Security;
using Alfateam.ID.Models.Security.Verifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CertificationCenter.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [ErrorsFilter]
    [APIExceptionFilter]
    public abstract class AbsController : ControllerBase
    {
        public readonly CertCenterDbContext DB;
        public readonly IDDbContext IDDB;
        public readonly AlfateamIDCodesService CodesService;
        public readonly CancellationRequestsService CancellationRequestsService;

        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;

        public readonly UploadedFilesService UploadedFilesService;
        public AbsController(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.IDDB = @params.IDDB;
            this.CodesService = @params.CodesService;
            this.CancellationRequestsService = @params.CancellationRequestsService;

            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;

            this.UploadedFilesService = @params.UploadedFilesService;
        }











        protected void ThrowIfGeoCoordinateNotCorrect(string fieldName, double value)
        {
            if (value < -180 || value > 180)
            {
                throw new Exception400($"Поле {fieldName} должно быть в диапазоне от -180 до 180");
            }
        }
    }
}
