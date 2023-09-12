using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption.Participants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Corruprtion
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.Compliance)]
    public class ComplianceCorruptionCaseParticipantsController : AbsController
    {
        public ComplianceCorruptionCaseParticipantsController(ControllerParams @params) : base(@params)
        {
        }


        #region Участники сторон коррупционного инцидента
    
        [HttpGet, Route("GetParticipants")]
        public async Task<RequestResult> GetParticipants(int caseId, int sideId)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

            var side = DB.CorruptionCaseSides.Include(o => o.Participants)
                                             .FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndSide(item,side),
                () =>
                {
                    side.Participants = side.Participants.Where(o => !o.IsDeleted).ToList();
                    IncludeParticipantsFields(side.Participants);

                    var clientModels = CorruptionCaseParticipantClientModel.CreateItems(side.Participants);
                    return RequestResult<IEnumerable<CorruptionCaseParticipantClientModel>>.AsSuccess(clientModels);
                }
            });
        }

        [HttpGet, Route("GetParticipant")]
        public async Task<RequestResult> GetParticipant(int caseId, int sideId, int participantId)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            var side = DB.CorruptionCaseSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);
            var participant = DB.CorruptionCaseParticipants.FirstOrDefault(o => o.Id == participantId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndParticipant(item,side,participant),
                () =>
                {
                    IncludeParticipantFields(participant);
                    return RequestResult<CorruptionCaseParticipant>.AsSuccess(participant);
                }
            });
        }



        [HttpPost, Route("CreateParticipant")]
        public async Task<RequestResult> CreateParticipant(int caseId, int sideId, CorruptionCaseParticipantCreateModel model)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            var side = DB.CorruptionCaseSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndSideToEdit(item,side),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    var participant = model.Create();
                    side.Participants.Add(participant);

                    var validateResult = ValidateParticipant(participant);
                    if (!validateResult.Success)
                    {
                        return validateResult;
                    }

                    UpdateModel(DB.CorruptionCaseSides, side);
                    return RequestResult<CorruptionCaseParticipant>.AsSuccess(participant);
                }
            });
        }

        [HttpPut, Route("UpdateParticipant")]
        public async Task<RequestResult> UpdateParticipant(int caseId, int sideId, CorruptionCaseParticipantEditModel model)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            var side = DB.CorruptionCaseSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);
            var participant = DB.CorruptionCaseParticipants.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndParticipantToEdit(item,side,participant),
                () => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
                () =>
                {
                    model.Fill(participant);

                    var validateResult = ValidateParticipant(participant);
                    if (!validateResult.Success)
                    {
                        return validateResult;
                    }

                    return UpdateModel(DB.CorruptionCaseParticipants, participant);
                }
            });
        }

        [HttpDelete, Route("DeleteParticipant")]
        public async Task<RequestResult> DeleteParticipant(int caseId, int sideId, int participantId)
        {
            var item = DB.CorruptionCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
            var side = DB.CorruptionCaseSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);
            var participant = DB.CorruptionCaseParticipants.FirstOrDefault(o => o.Id == participantId && !o.IsDeleted);

            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndParticipantToEdit(item,side,participant),
                () => DeleteModel(DB.CorruptionCaseParticipants, participant),
            });
        }


        #endregion







        #region Private check methods

        private RequestResult CheckBaseCorruptionCase(CorruptionCase item)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(item != null,404,"Инцидент с данным id не найден"),
                () => RequestResult.FromBoolean(item.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данному инциденту"),
            });
        }
        private RequestResult CheckBaseCorruptionCaseToEdit(CorruptionCase item)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCase(item),
                () => RequestResult.FromBoolean(item.ResultId == null,403,"Инцидент уже закрыт. Редактирование невозможно"),
            });
        }


        private RequestResult CheckBaseCorruptionCaseAndSide(CorruptionCase item, CorruptionCaseSide side)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCase(item),
                () => CheckBaseCorruptionCaseSide(side),
            });
        }
        private RequestResult CheckBaseCorruptionCaseAndSideToEdit(CorruptionCase item, CorruptionCaseSide side)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseToEdit(item),
                () => CheckBaseCorruptionCaseSide(side),
            });
        }


        private RequestResult CheckBaseCorruptionCaseAndParticipant(CorruptionCase item, CorruptionCaseSide side, CorruptionCaseParticipant participant)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndSide(item,side),
                () => CheckBaseCorruptionCaseParticipant(side,participant),
            });
        }
        private RequestResult CheckBaseCorruptionCaseAndParticipantToEdit(CorruptionCase item, CorruptionCaseSide side, CorruptionCaseParticipant participant)
        {
            return TryFinishAllRequestes(new[]
            {
                () => CheckBaseCorruptionCaseAndSideToEdit(item,side),
                () => CheckBaseCorruptionCaseParticipant(side,participant),
            });
        }



        private RequestResult CheckBaseCorruptionCaseSide(CorruptionCaseSide side)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(side != null,404,"Сторона с данным id не найдена"),
                () => RequestResult.FromBoolean(side.CorruptionCaseId == item.Id,403,"Сторона не принадлежит данному инциденту"),
            });
        }
        private RequestResult CheckBaseCorruptionCaseParticipant(CorruptionCaseSide side, CorruptionCaseParticipant participant)
        {
            return TryFinishAllRequestes(new[]
            {
                () => RequestResult.FromBoolean(participant != null,404,"Участник с данным id не найден"),
                () => RequestResult.FromBoolean(participant.CorruptionCaseSideId == side.Id,403,"Участник не принадлежит данной стороне"),
            });
        }



        private RequestResult ValidateParticipant(CorruptionCaseParticipant participant)
        {
            if (participant is CRMBindedCorruptionCaseParticipant crmBindedParticipant)
            {
                var user = DB.Users.FirstOrDefault(o => o.Id == crmBindedParticipant.PersonId && !o.IsDeleted);
                if (user == null)
                {
                    return RequestResult.AsError(404, "Пользователь с таким id не найден");
                }
                else if(user.BusinessId != this.BusinessId)
                {
                    return RequestResult.AsError(403, "Нет доступа к данному пользователю");
                }
            }
            else if (participant is InfoCorruptionCaseParticipant infoParticipant)
            {
                if(!DB.Countries.Any(o => o.Id == infoParticipant.CountryId && !o.IsDeleted))
                {
                    return RequestResult.AsError(404, "Страна с таким id не найдена");
                }
            }
            else
            {
                throw new NotImplementedException("Check for new types of CorruptionCaseParticipant");
            }

            return RequestResult.AsSuccess();
        }

        #endregion

        #region Private include methods

        private void IncludeParticipantsFields(IEnumerable<CorruptionCaseParticipant> participants)
        {
            foreach (var participant in participants)
            {
                IncludeParticipantFields(participant);
            }
        }
        private void IncludeParticipantFields(CorruptionCaseParticipant participant)
        {
            if(participant is CRMBindedCorruptionCaseParticipant crmBindedParticipant)
            {
                crmBindedParticipant.Person = DB.Users.Include(o => o.Country)
                                                      .FirstOrDefault(o => o.Id = crmBindedParticipant.PersonId);
            }
            else if (participant is InfoCorruptionCaseParticipant infoParticipant)
            {
                infoParticipant.Country = DB.Countries.FirstOrDefault(o => o.Id == infoParticipant.CountryId);
            }
            else
            {
                throw new NotImplementedException("Check for new types of CorruptionCaseParticipant");
            }
        }

        #endregion


    }
}
