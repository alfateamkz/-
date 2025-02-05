using Alfateam.Core;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Enums;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models.DTO;
using Alfateam.TicketSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Alfateam.TicketSystem.Models.Tickets;
using Microsoft.EntityFrameworkCore;
using Alfateam.TicketSystem.Models.Tickets.Creators;
using Alfateam.TicketSystem.Models.DTO.Tickets;
using Alfateam.TicketSystem.API.Models.Filters;
using Alfateam.TicketSystem.Models.DTO.Abstractions;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.Tickets.Messages;
using Alfateam.Core.Exceptions;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.Models.General;
using Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies;
using Alfateam.TicketSystem.Models.General.Notifications;
using Alfateam.TicketSystem.Models.Tickets.Senders;

namespace Alfateam.TicketSystem.API.Controllers.Tickets
{
    public class TicketsPublicController : AbsController
    {
        public string Identifier => Request.Headers["Identifier"];
        public ClientSenderType SenderType => (ClientSenderType)Convert.ToInt32(Request.Headers["SenderType"]);

        public TicketsPublicController(ControllerParams @params) : base(@params)
        {
        }



        [HttpGet, Route("GetTickets")]
        public async Task<ItemsWithTotalCount<TicketDTO>> GetTickets(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Ticket, TicketDTO>(GetAvailableTickets(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Category.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
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
                    if(entity is TextTicketMessage textMessage)
                    {
                        return textMessage.Text.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                    }
                }
                return true;
            });
        }







        [HttpPost, Route("CreateTicket")]
        public async Task<TicketDTO> CreateTicket(int categoryId, TicketMessageDTO messageModel)
        {
            if (!messageModel.IsValid())
            {
                throw new Exception400("Проверьте правильность заполнения полей");
            }

            var company = DB.BusinessCompanies.Include(o => o.TicketSettings)
                                              .FirstOrDefault(o => o.Id == this.CompanyId);

            var message = messageModel.CreateDBModelFromDTO();
            var newTicket = new Ticket
            {
                Status = TicketStatus.New,
                Category = DBService.TryGetOne(GetAvailableTicketCategories(), categoryId),
                Messages = new List<TicketMessage> { message },
                PriorityId = company.TicketSettings.DefaultPriorityId,
            };

            if (this.SenderType == ClientSenderType.Anonym)
            {
                newTicket.CreatedBy = new TicketAnonymCreator
                {
                    IP = "", //TODO: get anonym ip
                    Fingerprint = this.Identifier,
                    UserAgent = Request.Headers["UserAgent"]
                };
                message.Sender = new TicketMessageAnonymSender
                {
                    IP = "", //TODO: get anonym ip
                    Fingerprint = this.Identifier,
                    UserAgent = Request.Headers["UserAgent"]
                };
            }
            else if (this.SenderType == ClientSenderType.AuthorizedCustomer)
            {
                newTicket.CreatedBy = new TicketCustomerCreator
                {
                    Identifier = this.Identifier,
                };
                message.Sender = new TicketMessageCustomerSender
                {
                    Identifier = this.Identifier,
                };
            }



            if (message is TextTicketMessage textTicketMessage)
            {
                UploadedFilesService.ThrowIfAnyFileNotAvailable(textTicketMessage.Attachments.Select(o => o.FileId));
            }

            DBService.CreateEntity(DB.Tickets, newTicket);
            UseTicketDistributionStrategy(newTicket);


            if (message is TextTicketMessage textTicketMessage2)
            {
                foreach (var attachment in textTicketMessage2.Attachments)
                {
                    UploadedFilesService.TryBindFileWithEntity(attachment.FileId);
                }
            }

            return (TicketDTO)new TicketDTO().CreateDTO(newTicket);
        }








        #region Private methods
        private IEnumerable<Ticket> GetAvailableTickets()
        {
            var tickets = DB.Tickets.Include(o => o.CreatedBy)
                                    .Include(o => o.Category)
                                    .Include(o => o.Priority)
                                    .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);

            if(this.SenderType == ClientSenderType.Anonym)
            {
                tickets = tickets.Where(o => o.CreatedBy is TicketAnonymCreator)
                                 .Where(o => ((TicketAnonymCreator)o.CreatedBy).Fingerprint == this.Identifier);
            }
            else if (this.SenderType == ClientSenderType.AuthorizedCustomer)
            {
                tickets = tickets.Where(o => o.CreatedBy is TicketCustomerCreator)
                                 .Where(o => ((TicketCustomerCreator)o.CreatedBy).Identifier == this.Identifier);
            }

            return tickets;
        }
        private IEnumerable<TicketCategory> GetAvailableTicketCategories()
        {
            return DB.TicketCategories.Where(o => o.BusinessCompanyId == this.CompanyId);
        }



        private IEnumerable<User> GetAvailableOperators()
        {
            var users = DB.Users.Include(o => o.ResponsibleInTickets)
                                .Where(o => o.BusinessCompanyId == this.CompanyId && o.Role == UserRole.Operator && !o.IsBlocked && !o.IsDeleted);
            if (!users.Any())
            {
                users = DB.Users.Include(o => o.ResponsibleInTickets)
                                .Where(o => o.BusinessCompanyId == this.CompanyId && o.Role == UserRole.Administrator && !o.IsBlocked && !o.IsDeleted);
            }
            if (!users.Any())
            {
                users = DB.Users.Include(o => o.ResponsibleInTickets)
                                .Where(o => o.BusinessCompanyId == this.CompanyId && o.Role == UserRole.Owner && !o.IsBlocked && !o.IsDeleted);
            }
            return users;
        }


        private void ThrowIfTicketNotExistOrAvailable(int ticketId)
        {
            DBService.TryGetOne(GetAvailableTickets(), ticketId);
        }

        #endregion

        #region Assign to manager 

        private void UseTicketDistributionStrategy(Ticket ticket)
        {
            var company = DB.BusinessCompanies.Include(o => o.TicketSettings).ThenInclude(o => o.TicketDistributionStrategy)
                                              .FirstOrDefault(o => o.Id == this.CompanyId);

            if (company.TicketSettings.TicketDistributionStrategy is RandomTicketDistributionStrategy randomStrategy)
            {
                UseRandomTicketDistributionStrategy(ticket);
            }
            else if (company.TicketSettings.TicketDistributionStrategy is MaxLoadingTicketDistributionStrategy maxLoadingStrategy)
            {
                UseMaxLoadingTicketDistributionStrategy(ticket, maxLoadingStrategy);
            }
            else if (company.TicketSettings.TicketDistributionStrategy is AverageLoadingTicketDistributionStrategy averageLoadingStrategy)
            {
                UseAverageLoadingTicketDistributionStrategy(ticket);
            }
            else if (company.TicketSettings.TicketDistributionStrategy is ByOperatorPriorityTicketDistributionStrategy byOperatorPriorityStrategy)
            {
                UseByOperatorPriorityTicketDistributionStrategy(ticket, byOperatorPriorityStrategy);
            }
            else if (company.TicketSettings.TicketDistributionStrategy is NotifyAllTicketDistributionStrategy notifyAllStrategy)
            {
                UseNotifyAllTicketDistributionStrategy(ticket);
            }
            else throw new NotImplementedException("Данная стратегия не реализована, это баг");

            DBService.UpdateEntity(DB.Tickets, ticket);
        }

        private void UseRandomTicketDistributionStrategy(Ticket ticket)
        {
            var operators = GetAvailableOperators().ToList();
            ticket.ResponsibleUsers.Add(operators[Random.Shared.Next(0, operators.Count - 1)]);
        }
        private void UseMaxLoadingTicketDistributionStrategy(Ticket ticket, MaxLoadingTicketDistributionStrategy strategy)
        {
            var operators = GetAvailableOperators().ToList();

            if(operators.Any(o => o.ResponsibleInTickets.Count(o => o.Status == TicketStatus.New) < strategy.MaxTicketsCountForOperator))
            {
                var freeOperators = operators.Where(o => o.ResponsibleInTickets.Count(o => o.Status == TicketStatus.New) < strategy.MaxTicketsCountForOperator);
                var mostLoadedOperator = freeOperators.OrderByDescending(o => o.ResponsibleInTickets.Count(o => o.Status == TicketStatus.New)).FirstOrDefault();

                ticket.ResponsibleUsers.Add(mostLoadedOperator);
            }
            else
            {
                ticket.ResponsibleUsers.Add(operators[Random.Shared.Next(0, operators.Count - 1)]);
            }
        }
        private void UseAverageLoadingTicketDistributionStrategy(Ticket ticket)
        {
            var operators = GetAvailableOperators().ToList();

            var mostFreeOperator = operators.OrderByDescending(o => o.ResponsibleInTickets.Count(o => o.Status == TicketStatus.New)).FirstOrDefault();
            ticket.ResponsibleUsers.Add(mostFreeOperator);
        }
        private void UseByOperatorPriorityTicketDistributionStrategy(Ticket ticket, ByOperatorPriorityTicketDistributionStrategy strategy)
        {
            var operators = GetAvailableOperators().ToList();

            if (operators.Any(o => o.ResponsibleInTickets.Count(o => o.Status == TicketStatus.New) < strategy.MaxTicketsCountForOperator))
            {
                var freeOperators = operators.Where(o => o.ResponsibleInTickets.Count(o => o.Status == TicketStatus.New) < strategy.MaxTicketsCountForOperator).ToList();
                
                foreach(var priority in strategy.OperatorPriorities.OrderByDescending(o => o.Priority))
                {
                    var freeOperator = freeOperators.FirstOrDefault(o => o.Id == priority.UserId);
                    if(freeOperator != null)
                    {
                        ticket.ResponsibleUsers.Add(freeOperator);
                        return;
                    }
                }

                ticket.ResponsibleUsers.Add(freeOperators[Random.Shared.Next(0, operators.Count - 1)]);
            }
            else
            {
                ticket.ResponsibleUsers.Add(operators[Random.Shared.Next(0, operators.Count - 1)]);
            }
        }
        private void UseNotifyAllTicketDistributionStrategy(Ticket ticket)
        {
            var operators = GetAvailableOperators();
            foreach(var user in operators)
            {
                user.Notifications.Add(new NewTicketUserNotification()
                {
                    Ticket = ticket,
                });
            }
            DBService.UpdateEntities(DB.Users, operators);
        }

        #endregion
    }
}
