using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models.Counterparties;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.EDM.API.Controllers.Counterparties
{
    public class CounterpartiesInvitationsController : AbsAuthorizedController
    {
        public CounterpartiesInvitationsController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetOutgoingInvitations")]
        public async Task<IEnumerable<CounterpartyInvitationDTO>> GetOutgoingInvitations()
        {
            var invitations = DB.CounterpartyInvitations.Include(o => o.From)
                                                        .Include(o => o.To)                         
                                                        .Where(o => !o.IsDeleted && o.FromId == this.EDMSubjectId);
            return new CounterpartyInvitationDTO().CreateDTOs(invitations).Cast<CounterpartyInvitationDTO>();
        }

        [HttpGet, Route("GetIncomingInvitations")]
        public async Task<IEnumerable<CounterpartyInvitationDTO>> GetIncomingInvitations()
        {
            var invitations = DB.CounterpartyInvitations.Include(o => o.From)
                                                        .Include(o => o.To)
                                                        .Where(o => !o.IsDeleted && o.ToId == this.EDMSubjectId);
            return new CounterpartyInvitationDTO().CreateDTOs(invitations).Cast<CounterpartyInvitationDTO>();
        }


        [HttpPost, Route("SendInvitation")]
        public async Task<CounterpartyInvitationDTO> SendInvitation(CounterpartyInvitationDTO model)
        {
            var myCounterparties = DB.Counterparties.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId && o is EDMCounterparty).Cast<EDMCounterparty>();
            if(myCounterparties.Any(o => o.SubjectId == model.ToId))
            {
                throw new Exception400("Контрагент уже есть в списке контрагентов");
            }

            return (CounterpartyInvitationDTO)DBService.TryCreateEntity(DB.CounterpartyInvitations, model, (entity) =>
            {
                entity.FromId = (int)this.EDMSubjectId;
            });
        }

        [HttpPost, Route("SendInvitations")]
        public async Task<CounterpartyInvitationDTO> SendInvitations([FromBody]List<CounterpartyInvitationDTO> models)
        {
            var myCounterparties = DB.Counterparties.Where(o => !o.IsDeleted && o.EDMSubjectId == this.EDMSubjectId && o is EDMCounterparty).Cast<EDMCounterparty>();
            for(int i = models.Count -1; i >= 0; i--)
            {
                var model = models[i];
                if(myCounterparties.Any(o => o.SubjectId == model.ToId))
                {
                    models.Remove(model);
                    continue;
                }
            }

            return (CounterpartyInvitationDTO)DBService.TryCreateEntities(DB.CounterpartyInvitations, models, (entities) =>
            {
                foreach(var entity in entities)
                {
                    entity.FromId = (int)this.EDMSubjectId;
                }
            });
        }




        [HttpPut, Route("AnswerInvitation")]
        public async Task AnswerInvitation(int invitationId, bool approve)
        {
            var invitation = DB.CounterpartyInvitations.FirstOrDefault(o => o.Id == invitationId
                                                                        && !o.IsDeleted
                                                                        && (o.FromId == this.EDMSubjectId || o.ToId == this.EDMSubjectId));
            if(invitation == null)
            {
                throw new Exception404("Приглашение с данным id не найдено");
            }
            else if(invitation.Status != CounterpartyInvitationStatus.Waiting)
            {
                throw new Exception400("Приглашение уже обработано, нельзя изменить статус");
            }

            if (approve)
            {
                invitation.Status = CounterpartyInvitationStatus.Approved;

                var secondSideId = 0;
                if (this.EDMSubjectId != invitation.ToId)
                {
                    secondSideId = invitation.ToId;
                }
                else
                {
                    secondSideId = invitation.FromId;
                }


                var myCounterparty = new EDMCounterparty()
                {
                    EDMSubjectId = (int)this.EDMSubjectId,
                    SubjectId = secondSideId,
                };
                //Добавляем себя в список контрагентов у другого контрагента
                var meInMyCounterparty = new EDMCounterparty()
                {
                    EDMSubjectId = secondSideId,
                    SubjectId = (int)this.EDMSubjectId,
                };

                DB.Counterparties.Add(myCounterparty);
                DB.Counterparties.Add(meInMyCounterparty);
       
            }
            else
            {
                invitation.Status = CounterpartyInvitationStatus.Rejected;
            }

            DB.CounterpartyInvitations.Update(invitation);
            DB.SaveChanges();
        }







        [SwaggerResponse(200, description: "Возвращает субъект ЭДО", typeof(EDMSubjectDTO))]
        [SwaggerResponse(403, description: "Возвращает строку с описанием причины бана", typeof(string))]
        [HttpGet, Route("GetEDMSubjectToInviteAsCounterparty")]
        public async Task<EDMSubjectDTO> GetEDMSubjectToInviteAsCounterparty(string countryCode, string number)
        {
            var subject = DB.EDMSubjects.FirstOrDefault(o => o.CountryCode == countryCode && o.BusinessNumber == number && !o.IsDeleted && o.IsVerified);
            if (subject == null)
            {
                throw new Exception404("Субъект ЭДО с данными данными не найден");
            }

            var banned = DB.BannedCounterparties.Include(o => o.Counterparty)
                                                .Where(o => o.EDMSubjectId == subject.Id && !o.IsDeleted);
            var bannedOurSubject = banned.FirstOrDefault(o => o.Counterparty.IsThisSubject(this.EDMSubject));
            if (bannedOurSubject != null)
            {
                throw new Exception403($"Контрагент вас заблокировал. Комментарий к блокировке: {bannedOurSubject.BanReason}");
            }

            return (EDMSubjectDTO)new EDMSubjectDTO().CreateDTO(subject);
        }
    }
}
