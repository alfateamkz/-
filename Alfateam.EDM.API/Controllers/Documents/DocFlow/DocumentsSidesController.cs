using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Enums;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.EDM.API.Controllers.Documents.DocFlow
{
    public class DocumentsSidesController : AbsDocumentsController
    {
        public DocumentsSidesController(ControllerParams @params) : base(@params)
        {
        }



        [SwaggerResponse(200, description: "Возвращает субъект ЭДО", typeof(EDMSubjectDTO))]
        [SwaggerResponse(403, description: "Возвращает строку с описанием причины бана или с предложением добавить сначала субъект в контрагенты (если ему присылать могут только контрагенты)", typeof(string))]
        [HttpGet, Route("GetEDMSubjectForSigning")]
        public async Task<EDMSubjectDTO> GetEDMSubjectForSigning(string countryCode, string number)
        {
            var subject = DB.EDMSubjects.FirstOrDefault(o => o.CountryCode == countryCode && o.BusinessNumber == number && !o.IsDeleted && o.IsVerified);
            if (subject == null)
            {
                throw new Exception404("Субъект ЭДО с данными данными не найден");
            }

            switch (CanSignWith(countryCode, number))
            {
                case EDMSubjectSigningAccessType.SubjectBannedUs:

                    var bannedOurSubject = DB.BannedCounterparties.Include(o => o.Counterparty)
                                                        .ToList()
                                                        .FirstOrDefault(o => o.EDMSubjectId == subject.Id && !o.IsDeleted && o.Counterparty.IsThisSubject(EDMSubject));
                    throw new Exception403($"Контрагент вас заблокировал. Комментарий к блокировке: {bannedOurSubject.BanReason}");
                case EDMSubjectSigningAccessType.NeedToAddSubjectToCounterparties:
                    throw new Exception403($"Нельзя подписаться с данным контрагентом. Сначала пригласите контрагента к ЭДО и получите согласие, прежде чем продолжить");
            }
            return (EDMSubjectDTO)new EDMSubjectDTO().CreateDTO(subject);
        }

        [HttpGet, Route("CanSignWithEDMSubject")]
        public async Task<EDMSubjectSigningAccessType> CanSignWithEDMSubject(string countryCode, string number)
        {
            return CanSignWith(countryCode, number);
        }
    }
}
