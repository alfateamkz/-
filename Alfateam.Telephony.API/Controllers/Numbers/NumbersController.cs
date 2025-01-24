using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Telephony.API.Abstractions;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.API.Models.DTO;
using Alfateam.Telephony.API.Models.DTO.Abstractions;
using Alfateam.Telephony.API.Models.SearchFilters.Numbers;
using Alfateam.Telephony.Models;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.Calls.Types;
using Alfateam.Telephony.Models.SMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Telephony.API.Controllers.Numbers
{
    public class NumbersController : AbsController
    {
        public NumbersController(ControllerParams @params) : base(@params)
        {
        }


        #region CRUD с номерами

        [HttpGet, Route("GetNumbers")]
        public async Task<ItemsWithTotalCount<TelephonyNumberDTO>> GetNumbers(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<TelephonyNumber, TelephonyNumberDTO>(GetAvailableNumbers(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.PhoneNumber.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetNumber")]
        public async Task<TelephonyNumberDTO> GetNumber(int id)
        {
            return (TelephonyNumberDTO)DBService.TryGetOne(GetAvailableNumbers(), id, new TelephonyNumberDTO());
        }



        #endregion

        #region Управление звонками

        [HttpGet, Route("GetNumberCalls")]
        public async Task<ItemsWithTotalCount<BaseCallDTO>> GetNumberCalls(NumberCallsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BaseCall, BaseCallDTO>(GetAvailableNumberCalls(filter.NumberId), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    if(entity is IncomingCall incomingCall)
                    {
                        condition &= incomingCall.From.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                    }
                    else if (entity is OutgoingCall outgoingCall)
                    {
                        condition &= outgoingCall.To.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                    }
                }
                if(filter.CallType != null)
                {
                    if (filter.CallType == Enums.NumberCallType.Incoming)
                    {
                        condition &= entity is IncomingCall;
                    }
                    else if (filter.CallType == Enums.NumberCallType.Outgoing)
                    {
                        condition &= entity is OutgoingCall;
                    }
                }
                if(filter.CallCreatedAtDateFilter != null)
                {
                    var period = filter.CallCreatedAtDateFilter.GetPeriod();
                    condition &= entity.CreatedAt >= period.From && entity.CreatedAt <= period.To;
                }
                if (filter.CallStartedAtDateFilter != null)
                {
                    var period = filter.CallStartedAtDateFilter.GetPeriod();
                    condition &= entity.StartedAt >= period.From && entity.StartedAt <= period.To;
                }
                if (filter.CallEndedAtDateFilter != null)
                {
                    var period = filter.CallEndedAtDateFilter.GetPeriod();
                    condition &= entity.EndedAt >= period.From && entity.EndedAt <= period.To;
                }
                if (filter.Status != null)
                {
                    condition &= entity.Status == filter.Status;
                }
                if (filter.HasRecord != null)
                {
                    condition &= entity.RecordId != null == filter.HasRecord;
                }
                if (!string.IsNullOrEmpty(filter.Comment))
                {
                    condition &= entity.Comment.Contains(filter.Comment, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetNumberCall")]
        public async Task<BaseCallDTO> GetNumberCall(int numberId, int callId)
        {
            return (BaseCallDTO)DBService.TryGetOne(GetAvailableNumberCalls(numberId), callId, new BaseCallDTO());
        }

        [HttpPost, Route("Call")]
        public async Task SendSMS(int numberId, string phone)
        {
            //TODO: фактический звонок с номера
        }

        #endregion

        #region Управление SMS

        [HttpGet, Route("GetNumberSMSList")]
        public async Task<ItemsWithTotalCount<BaseSMSDTO>> GetNumberSMSList(NumberSMSSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BaseSMS, BaseSMSDTO>(GetAvailableSMS(filter.NumberId), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Text.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (!string.IsNullOrEmpty(filter.Phone))
                {
                    if (entity is ReceivedSMS receivedSMS)
                    {
                        condition &= receivedSMS.From.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                    }
                    else if (entity is SentSMS sentSMS)
                    {
                        condition &= sentSMS.To.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                    }
                }
                if (filter.SMSType != null)
                {
                    if (filter.SMSType == Enums.NumberSMSType.Received)
                    {
                        condition &= entity is ReceivedSMS;
                    }
                    else if (filter.SMSType == Enums.NumberSMSType.Sent)
                    {
                        condition &= entity is SentSMS;
                    }
                }
                if (filter.ReceivedOrSentAtDateFilter != null)
                {
                    var period = filter.ReceivedOrSentAtDateFilter.GetPeriod();

                    if (entity is ReceivedSMS receivedSMS)
                    {
                        condition &= receivedSMS.ReceivedAt >= period.From && receivedSMS.ReceivedAt <= period.To;
                    }
                    else if (entity is SentSMS sentSMS)
                    {
                        condition &= sentSMS.SentAt >= period.From && sentSMS.SentAt <= period.To;
                    }
                }

                return condition;
            });
        }

        [HttpGet, Route("GetNumberSMS")]
        public async Task<BaseSMSDTO> GetNumberSMS(int numberId, int smsId)
        {
            return (BaseSMSDTO)DBService.TryGetOne(GetAvailableSMS(numberId), smsId, new BaseSMSDTO());
        }

        [HttpPost, Route("SendSMS")]
        public async Task SendSMS(int numberId, string phone, string text)
        {
            //TODO: фактическая отправка SMS с номера
        }

        #endregion







        #region Private methods
        private IEnumerable<TelephonyNumber> GetAvailableNumbers()
        {
            return DB.TelephonyNumbers.Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<BaseCall> GetAvailableNumberCalls(int numberId)
        {
            var number = DB.TelephonyNumbers.Include(o => o.Calls).ThenInclude(o => o.Record).ThenInclude(o => o.Transcription).ThenInclude(o => o.Companions)
                                            .Include(o => o.Calls).ThenInclude(o => o.Record).ThenInclude(o => o.Transcription).ThenInclude(o => o.Texts).ThenInclude(o => o.Companion)
                                            .FirstOrDefault(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId && o.Id == numberId);
            if (number == null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }


            foreach (var call in number.Calls)
            {
                if(call is OutgoingCall outgoingCall)
                {
                    outgoingCall.CallMadeBy = DB.Users.FirstOrDefault(o => o.Id == outgoingCall.CallMadeById);
                }
            }

            return number.Calls;
        }
        private IEnumerable<BaseSMS> GetAvailableSMS(int numberId)
        {
            var number = DB.TelephonyNumbers.Include(o => o.SMSList)
                                            .FirstOrDefault(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId && o.Id == numberId);
            if(number == null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }


            foreach (var call in number.SMSList)
            {
                if (call is SentSMS sentSMS)
                {
                    sentSMS.SentBy = DB.Users.FirstOrDefault(o => o.Id == sentSMS.SentById);
                }
            }

            return number.SMSList;
        }

        #endregion
    }
}
