using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class CompanyDTO : DTOModelAbs<Company>
    {
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string CountryCode { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string Title { get; set; }

        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        /// <summary>
        /// ИНН (в РФ), БИН\ИИН (в КЗ), в других странах может быть другое
        /// </summary>
        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string BusinessNumber { get; set; }



        [ForClientOnly]
        public string? LogoPath { get; set; }
        public string? Description { get; set; }


        public bool AreWeWorkWithCustomerDocuments => WorksWithCustomerDocuments != null;
        public bool AreWeWorkWithCounterpartiesDocuments => WorksWithCounterpartiesDocuments != null;

        public WorkWithCompanyDocumentsDTO? WorksWithCustomerDocuments { get; set; }
        public WorkWithCompanyDocumentsDTO? WorksWithCounterpartiesDocuments { get; set; }


        public WhoCanSendDocumentsToUs WhoCanSendDocumentsToUs { get; set; }



        /// <summary>
        /// Подтверждена ли компания. Если нет, то она не сможет принимать участие в документообороте. 
        /// Чтобы смогла, нужно подтвердить владение компанией
        /// </summary>
        [ForClientOnly]
        public bool IsVerified { get; set; }
    }
}
