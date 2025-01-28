using Alfateam.Core.Exceptions;
using Alfateam.ID.Models.Security;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.API.Models.TicketHub;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.General;
using Alfateam.TicketSystem.Models.Tickets;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Alfateam.TicketSystem.Models.Tickets.Messages;
using Alfateam.TicketSystem.API.Enums;
using Alfateam.TicketSystem.Models.Tickets.Creators;
using Alfateam.TicketSystem.Models.Tickets.Senders;
using Telegram.Bot.Requests.Abstractions;
using Alfateam.TicketSystem.Models.Abstractions;
using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;

namespace Alfateam.TicketSystem.API.Hubs
{
    public class TicketHub : AbsHub
    {
        public TicketHub(ControllerParams @params) : base(@params)
        {
         
        }




        public async Task SendMessageAsNotAdmin(SendMessageAsNotAdminParameters parameters)
        {
            var ticket = DBService.TryGetOne(GetAvailableTickets(parameters.CompanyId, parameters.SenderType, parameters.Identifier), parameters.TicketId);
            if(ticket.Status == TicketStatus.Closed)
            {
                throw new Exception400("Тикет закрыт, отправка сообщений невозможна");
            }

            if (!parameters.Message.IsValid())
            {
                throw new Exception400("Проверьте правильность заполнения полей");
            }

            var message = parameters.Message.CreateDBModelFromDTO();
            HandleMessageBase(parameters.TicketId, message);

            if (parameters.SenderType == ClientSenderType.Anonym)
            {
                message.Sender = new TicketMessageAnonymSender
                {
                    IP = Context.Features.Get<IHttpConnectionFeature>().RemoteIpAddress?.ToString(),
                    Fingerprint = parameters.Identifier,
                    UserAgent = parameters.UserAgent
                };
            }
            else if (parameters.SenderType == ClientSenderType.AuthorizedCustomer)
            {
                message.Sender = new TicketMessageCustomerSender
                {
                    Identifier = parameters.Identifier,
                };
            }

            ticket.Status = TicketStatus.Open;
            DBService.UpdateEntity(DB.Tickets, ticket);

            DBService.CreateEntity(DB.TicketMessages, message);
            HandleMessageFilesSuccess(message);

            await SendCommandToTicketMembersOnly(ticket,"Receive", parameters.Message.CreateDTO(message));
        }
        public async Task SendMessageAsAdmin(SendMessageAsAdminParameters parameters)
        {
            var session = GetSessionIfActive(parameters.SessionGuid);
            var adminUser = GetAuthorizedUserIfActive(parameters.CompanyId, session);
            var ticket = DBService.TryGetOne(GetAvailableTicketsForAdmin(parameters.CompanyId, adminUser), parameters.TicketId);

            if (ticket.Status == TicketStatus.Closed)
            {
                throw new Exception400("Тикет закрыт, отправка сообщений невозможна");
            }
            else if (!parameters.Message.IsValid())
            {
                throw new Exception400("Проверьте правильность заполнения полей");
            }

            var message = parameters.Message.CreateDBModelFromDTO();
            HandleMessageBase(parameters.TicketId, message);
            message.Sender = new TicketMessageAdminSender
            {
                UserId = adminUser.Id,
            };

            ticket.Status = TicketStatus.Answered;
            DBService.UpdateEntity(DB.Tickets, ticket);

            DBService.CreateEntity(DB.TicketMessages, message);
            HandleMessageFilesSuccess(message);

            await SendCommandToTicketMembersOnly(ticket, "Receive", parameters.Message.CreateDTO(message));
        }





        #region Отправка WebSocket уведомления только тем, кто причастен к тикету

        private async Task SendCommandToTicketMembersOnly(Ticket ticket, string commandName, object parameter)
        {
            var connectionIds = new List<string>();
            foreach(var admin in ticket.ResponsibleUsers.Where(o => !o.IsDeleted && !o.IsBlocked))
            {
                connectionIds.AddRange(GetAdminWSConnectionIds(admin));
            }
            connectionIds.Add(GetTicketCreatorWSConnectionId(ticket.CreatedBy));

            await this.Clients.Users(connectionIds).SendAsync(commandName, parameter);
        }
        private IEnumerable<string> GetAdminWSConnectionIds(User adminUser)
        {
            var alfateamIdUser = IDDB.Users.FirstOrDefault(o => o.Guid == adminUser.AlfateamID);
            var alfateamIdSessions = IDDB.Sessions.Where(o => o.UserId == alfateamIdUser.Id && o.IsActive);

            return alfateamIdSessions.Select(o => o.SessID);
        }
        private string GetTicketCreatorWSConnectionId(TicketCreator creator)
        {
            if (creator is TicketAnonymCreator anonymCreator)
            {
                return $"Anonym|{anonymCreator.Fingerprint}";
            }
            else if (creator is TicketCustomerCreator customerCreator)
            {
                return $"Customer|{customerCreator.Identifier}";
            }
            throw new NotImplementedException("Не реализовано, баг бэкэнда");
        }

        #endregion

        #region Проверка сессии
        private Session GetSessionIfActive(string sessionGuid)
        {
            var session = IDDB.Sessions.Include(o => o.User)
                                       .FirstOrDefault(o => o.SessID == sessionGuid);
            if (session == null)
            {
                throw new Exception401("Сессия не найдена");
            }
            else if (session.IsDeactivated)
            {
                throw new Exception401("Сессия деактивирована");
            }
            else if (session.IsExpired)
            {
                throw new Exception401("Сессия истекла");
            }

            return session;
        }
        private User GetAuthorizedUserIfActive(int companyId, Session session)
        {
            var authorizedUser = DB.Users.FirstOrDefault(o => o.BusinessCompanyId == companyId && o.AlfateamID == session.User.Guid && !o.IsDeleted);
            if(authorizedUser == null)
            {
                throw new Exception400("Пользователь не найден");
            }
            else if (authorizedUser.IsBlocked)
            {
                throw new Exception403("Пользователь заблокирован");
            }
            return authorizedUser;
        }

        #endregion

        #region Получение доступных тикетов
        private IEnumerable<Ticket> GetAvailableTicketsForAdmin(int companyId, User authorizedUser)
        {
            var tickets = DB.Tickets.Include(o => o.CreatedBy)
                                    .Include(o => o.Category)
                                    .Include(o => o.Priority)
                                    .Include(o => o.ResponsibleUsers)
                                    .Where(o => !o.IsDeleted && o.BusinessCompanyId == companyId);

            if (authorizedUser.Role == UserRole.Operator)
            {
                tickets = tickets.Where(o => o.ResponsibleUsers.Any(o => o.Id == authorizedUser.Id));
            }
            if (authorizedUser.Role == UserRole.Administrator)
            {
                //TODO: GetAvailableTickets for UserRole.Administrator
            }
            return tickets;
        }
        private IEnumerable<Ticket> GetAvailableTickets(int companyId, ClientSenderType senderType, string identifier)
        {
            var tickets = DB.Tickets.Include(o => o.CreatedBy)
                                    .Include(o => o.Category)
                                    .Include(o => o.Priority)
                                    .Include(o => o.ResponsibleUsers)
                                    .Where(o => !o.IsDeleted && o.BusinessCompanyId == companyId);

            if (senderType == ClientSenderType.Anonym)
            {
                tickets = tickets.Where(o => o.CreatedBy is TicketAnonymCreator)
                                 .Where(o => ((TicketAnonymCreator)o.CreatedBy).Fingerprint == identifier);
            }
            else if (senderType == ClientSenderType.AuthorizedCustomer)
            {
                tickets = tickets.Where(o => o.CreatedBy is TicketCustomerCreator)
                                 .Where(o => ((TicketCustomerCreator)o.CreatedBy).Identifier == identifier);
            }

            return tickets;
        }

        #endregion

        #region Обработка сообщения
        private void HandleMessageBase(int ticketId, TicketMessage message)
        {
            if (message is TextTicketMessage textTicketMessage)
            {
                UploadedFilesService.ThrowIfAnyFileNotAvailable(textTicketMessage.Attachments.Select(o => o.FileId));
            }
            message.TicketId = ticketId;
        }

        private void HandleMessageFilesSuccess(TicketMessage message)
        {
            if (message is TextTicketMessage textTicketMessage)
            {
                foreach (var attachment in textTicketMessage.Attachments)
                {
                    UploadedFilesService.TryBindFileWithEntity(attachment.FileId, UploadedFileRelatedEntity.MessageAttachment, attachment.Id);
                }
            }
        }

        #endregion
    }
}
