using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using System.ComponentModel.DataAnnotations.Schema;
using Alfateam.EDM.Models.Enums;

namespace Alfateam.EDM.Models.General
{
    public class Company : AbsModel
    {
        public string CountryCode { get; set; }


        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }

        /// <summary>
        /// ИНН (в РФ), БИН\ИИН (в КЗ), в других странах может быть другое
        /// </summary>
        public string BusinessNumber { get; set; }

 

     
        public string? LogoPath { get; set; }
        public string? Description { get; set; }


        public Department Department { get; set; }
        public List<User> Users { get; set; } = new List<User>();



        [NotMapped]
        public bool AreWeWorkWithCustomerDocuments => WorksWithCustomerDocuments != null;
        [NotMapped]
        public bool AreWeWorkWithCounterpartiesDocuments => WorksWithCounterpartiesDocuments != null;

        public WorkWithCompanyDocuments? WorksWithCustomerDocuments { get; set; }
        public WorkWithCompanyDocuments? WorksWithCounterpartiesDocuments { get; set; }


        public WhoCanSendDocumentsToUs WhoCanSendDocumentsToUs { get; set; } = WhoCanSendDocumentsToUs.AllExceptingBlocked;





        public List<Counterparty> Counterparties { get; set; } = new List<Counterparty>();
        public List<CounterpartyGroup> CounterpartyGroups { get; set; } = new List<CounterpartyGroup>();
        public List<BannedCounterparty> BannedCounterparties { get; set; } = new List<BannedCounterparty>();




        /// <summary>
        /// Подтверждена ли компания. Если нет, то она не сможет принимать участие в документообороте. 
        /// Чтобы смогла, нужно подтвердить владение компанией
        /// </summary>
        public bool IsVerified { get; set; }

        /// <summary>
        /// Автоматическое поле, указывающее на сущность Business, в которой находятся сущности компаний
        /// </summary>
        public int BusinessId  { get; set; }

    }
}
