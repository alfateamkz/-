using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.API.Services;
using Microsoft.AspNetCore.SignalR;

namespace Alfateam.TicketSystem.API.Abstractions
{
    public abstract class AbsHub : Hub
    {
        public readonly TicketSystemDbContext DB;
        public readonly IDDbContext IDDB;

        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;

        public readonly UploadedFilesService UploadedFilesService;
        public AbsHub(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.IDDB = @params.IDDB;

            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;

            this.UploadedFilesService = @params.UploadedFilesService;
        }
    }
}
