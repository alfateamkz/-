using Alfateam.Core;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Enums;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models.DTO;
using Alfateam.TicketSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Alfateam.TicketSystem.Models.Tickets.Creators;
using Alfateam.TicketSystem.Models.Tickets;
using Microsoft.EntityFrameworkCore;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.Models.DTO.Tickets;
using Alfateam.TicketSystem.API.Models.Filters;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.Tickets.Messages;
using Alfateam.Core.Exceptions;
using Alfateam.TicketSystem.Models.General;

namespace Alfateam.TicketSystem.API.Controllers.Tickets
{
    public class TicketsAdminController : AbsAuthorizedController
    {
        public TicketsAdminController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetTickets")]
        public async Task<ItemsWithTotalCount<TicketDTO>> GetTickets(AdminTicketsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Ticket, TicketDTO>(GetAvailableTickets(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Category.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.TicketStatus != null)
                {
                    condition &= entity.Status == filter.TicketStatus;
                }
                if (filter.CategoryId != null)
                {
                    condition &= entity.CategoryId == filter.CategoryId;
                }
                if (filter.PriorityId != null)
                {
                    condition &= entity.PriorityId == filter.PriorityId;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetTicket")]
        public async Task<TicketDTO> GetTicket(int id)
        {
            return (TicketDTO)DBService.TryGetOne(GetAvailableTickets(), id, new TicketDTO());
        }

        [HttpGet, Route("GetTicketMessages")]
        public async Task<ItemsWithTotalCount<TicketMessageDTO>> GetTicketMessages(TicketMessageSearchFilter filter)
        {
            ThrowIfTicketNotExistOrAvailable(filter.TicketId);
            var messages = DB.TicketMessages.Where(o => o.TicketId == filter.TicketId);

            return DBService.GetManyWithTotalCount<TicketMessage, TicketMessageDTO>(messages, filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    if (entity is TextTicketMessage textMessage)
                    {
                        return textMessage.Text.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                    }
                }
                return true;
            });
        }





        [HttpPut, Route("AddResponsibleUser")]
        public async Task AddResponsibleUser(int ticketId, int userId)
        {
            var ticket = DBService.TryGetOne(GetAvailableTickets(), ticketId);

            var user = DBService.TryGetOne(GetAvailableUsers(), userId);
            if(ticket.ResponsibleUsers.Any(o => o.Id == userId))
            {
                throw new Exception400("Данный пользователь уже добавлен в качестве ответственного");
            }

            ticket.ResponsibleUsers.Add(user);
            DBService.UpdateEntity(DB.Tickets, ticket);
        }

        [HttpDelete, Route("RemoveResponsibleUser")]
        public async Task RemoveResponsibleUser(int ticketId, int userId)
        {
            var ticket = DBService.TryGetOne(GetAvailableTickets(), ticketId);

            if(this.AuthorizedUser.Id == userId)
            {
                throw new Exception403("Нельзя удалить себя из отвественных тикета");
            }

            var user = DBService.TryGetOne(ticket.ResponsibleUsers, userId);
            if (!ticket.ResponsibleUsers.Any(o => o.Id == userId))
            {
                throw new Exception400("Данного пользователя нет в качестве ответсвенного");
            }

            ticket.ResponsibleUsers.Remove(user);
            DBService.UpdateEntity(DB.Tickets, ticket);
        }







        [HttpPut, Route("CloseTicket")]
        public async Task CloseTicket(int ticketId)
        {
            var ticket = DBService.TryGetOne(GetAvailableTickets(), ticketId);
            if(ticket.Status == TicketStatus.Closed)
            {
                throw new Exception400("Тикет уже был ранее закрыт");
            }

            ticket.Status = TicketStatus.Closed;
            DBService.UpdateEntity(DB.Tickets, ticket);
        }

        [HttpPut, Route("PostponeTicket")]
        public async Task PostponeTicket(int ticketId)
        {
            var ticket = DBService.TryGetOne(GetAvailableTickets(), ticketId);
            if (ticket.Status == TicketStatus.Closed)
            {
                throw new Exception400("Тикет уже был ранее закрыт");
            }

            ticket.Status = TicketStatus.Postponed;
            DBService.UpdateEntity(DB.Tickets, ticket);
        }











        #region Private methods

        private IEnumerable<User> GetAvailableUsers()
        {
            return DB.Users.Include(o => o.Permissions)
                           .Include(o => o.Department)
                           .Where(o => o.BusinessCompanyId == this.CompanyId && !o.IsDeleted);
        }
        private IEnumerable<Ticket> GetAvailableTickets()
        {
            var tickets = DB.Tickets.Include(o => o.CreatedBy)
                                    .Include(o => o.Category)
                                    .Include(o => o.Priority)
                                    .Include(o => o.ResponsibleUsers)
                                    .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);

            var authorizedUser = this.AuthorizedUser;
            if(authorizedUser.Role == UserRole.Operator)
            {
                tickets = tickets.Where(o => o.ResponsibleUsers.Any(o => o.Id == authorizedUser.Id));   
            }
            if (authorizedUser.Role == UserRole.Administrator)
            {
                //TODO: GetAvailableTickets for UserRole.Administrator
            }
            return tickets;
        }




        private void ThrowIfTicketNotExistOrAvailable(int ticketId)
        {
            DBService.TryGetOne(GetAvailableTickets(), ticketId);
        }

        #endregion
    }
}
