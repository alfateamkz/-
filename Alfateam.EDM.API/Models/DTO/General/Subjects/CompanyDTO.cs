using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General.Subjects;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.EDM.API.Models.DTO.General.Subjects
{
    public class CompanyDTO : EDMSubjectDTO
    {
    


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string Title { get; set; }

        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


 



    


        public bool AreWeWorkWithCustomerDocuments => WorksWithCustomerDocuments != null;
        public bool AreWeWorkWithCounterpartiesDocuments => WorksWithCounterpartiesDocuments != null;

        public WorkWithCompanyDocumentsDTO? WorksWithCustomerDocuments { get; set; }
        public WorkWithCompanyDocumentsDTO? WorksWithCounterpartiesDocuments { get; set; }


        public WhoCanSendDocumentsToUs WhoCanSendDocumentsToUs { get; set; }



    
    }
}
