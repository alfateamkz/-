using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Enums;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Abstractions
{
    public abstract class AbsDocumentsController : AbsAuthorizedController
    {
        //TODO: includes of derived types
        public AbsDocumentsController(ControllerParams @params) : base(@params)
        {
        }




        protected EDMSubjectSigningAccessType CanSignWith(string countryCode, string number)
        {
            var subject = DB.EDMSubjects.FirstOrDefault(o => o.CountryCode == countryCode && o.BusinessNumber == number && !o.IsDeleted && o.IsVerified);
            if (subject == null)
            {
                throw new Exception404("Субъект ЭДО с данными данными не найден");
            }

            switch (subject.WhoCanSendDocumentsToUs)
            {
                case WhoCanSendDocumentsToUs.AllExceptingBlocked:

                    var banned = DB.BannedCounterparties.Include(o => o.Counterparty)
                                                        .Where(o => o.EDMSubjectId == subject.Id && !o.IsDeleted);
                    var bannedOurSubject = banned.FirstOrDefault(o => o.Counterparty.IsThisSubject(this.EDMSubject));
                    if (bannedOurSubject != null)
                    {
                        return EDMSubjectSigningAccessType.SubjectBannedUs;
                    }
                    break;
                case WhoCanSendDocumentsToUs.OnlyOurCounterparties:

                    var counterparties = DB.Counterparties.Where(o => o.EDMSubjectId == subject.Id && !o.IsDeleted);
                    var counterpartyOurSubject = counterparties.FirstOrDefault(o => o.IsThisSubject(this.EDMSubject));
                    if (counterpartyOurSubject == null)
                    {
                        return EDMSubjectSigningAccessType.NeedToAddSubjectToCounterparties;
                    }
                    break;
            }
            return EDMSubjectSigningAccessType.CanSign;
        }



        #region Private methods
        protected IEnumerable<Document> GetAvailableDocuments(bool drafts = false)
        {
            return DocService.GetAvailableDocuments(EDMSubject, AuthorizedUser, drafts);
        }

        #endregion
    }
}
