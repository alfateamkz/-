using Alfateam.Core;
using Alfateam.Core.Enums;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Enums;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models;
using Alfateam.TicketSystem.Models.DTO;
using Alfateam.TicketSystem.Models.DTO.General;
using Alfateam.TicketSystem.Models.General;
using Alfateam.TicketSystem.Models.Tickets.Creators;
using Alfateam.TicketSystem.Models.Tickets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.General.Notifications;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.API.Models.Filters;
using Alfateam.Core.Exceptions;
using Alfateam.SharedModels.DTO;
using Alfateam.SharedModels;

namespace Alfateam.TicketSystem.API.Controllers
{
    public class CommonController : AbsAuthorizedController
    {
        public CommonController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetMyUser")]
        public async Task<UserDTO> GetMyUser()
        {
            return new UserDTO().CreateDTO(this.AuthorizedUser, this.AlfateamSession.User);
        }

        [HttpGet, Route("GetMyAvailableCompanies")]
        public async Task<IEnumerable<BusinessCompanyDTO>> GetMyAvailableCompanies()
        {
            var alfateamIDUser = this.AlfateamSession.User;

            var availableCompanies = new List<BusinessCompany>();

            foreach (var company in DB.BusinessCompanies)
            {
                var users = DB.Users.Where(o => o.BusinessCompanyId == company.Id && !o.IsDeleted);
                if (users.Any(a => a.AlfateamID == alfateamIDUser.Guid && !a.IsDeleted && !a.IsBlocked))
                {
                    availableCompanies.Add(company);
                }
            }

            return new BusinessCompanyDTO().CreateDTOs(availableCompanies).Cast<BusinessCompanyDTO>();
        }





        [HttpGet, Route("GetMyNotifications")]
        public async Task<ItemsWithTotalCount<UserNotificationDTO>> GetMyNotifications(UserNotificationsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<UserNotification, UserNotificationDTO>(GetAvailableNotifications(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    if(entity is SimpleUserNotification simpleNotification)
                    {
                        condition &= simpleNotification.Text.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                    }
                }
                if(filter.IsRead != null)
                {
                    condition &= entity.ReadAt.HasValue == filter.IsRead;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetMyNotificationsCount")]
        public async Task<int> GetMyNotificationsCount(UserNotificationsSearchFilter filter)
        {
            return (await GetMyNotifications(filter)).TotalCount;
        }

        [HttpPut, Route("SetNotificationsRead")]
        public async Task SetNotificationsRead(List<int> ids)
        {
            if(ids == null || !ids.Any())
            {
                throw new Exception400("Необходимо добавить как минимум 1 id уведомления");
            }

            foreach (int id in ids)
            {
                var notification = DBService.TryGetOne(GetAvailableNotifications(), id);
                notification.ReadAt = DateTime.UtcNow;
                DB.UserNotifications.Update(notification);
            }

            DB.SaveChanges();      
        }






        [HttpPost, Route("UploadFile")]
        public async Task<UploadedFileDTO> UploadFile([FromQuery]FileType fileType, IFormFile file)
        {
            var uploadedFile = new UploadedFile
            {
                RelativePath = FilesService.TryUploadFile(file, fileType)
            };
            DBService.CreateEntity(DB.UploadedFiles, uploadedFile);
            return (UploadedFileDTO)new UploadedFileDTO().CreateDTO(uploadedFile);
        }







        #region Private methods

        private IEnumerable<UserNotification> GetAvailableNotifications()
        {
            var tickets = DB.UserNotifications.Where(o => !o.IsDeleted && o.UserId == this.AuthorizedUser.Id);
            foreach(var ticket in  tickets)
            {
                if(ticket is NewTicketUserNotification newTicket)
                {
                    newTicket.Ticket = DB.Tickets.FirstOrDefault(o => o.Id == newTicket.TicketId);
                }
            }

            return tickets;
        }

        #endregion


    }
}
