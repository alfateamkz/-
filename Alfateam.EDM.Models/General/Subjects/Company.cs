using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using System.ComponentModel.DataAnnotations.Schema;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.ApprovalRoutes;

namespace Alfateam.EDM.Models.General.Subjects
{
    public class Company : EDMSubject
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }





        public List<User> Users { get; set; } = new List<User>();



        [NotMapped]
        public bool AreWeWorkWithCustomerDocuments => WorksWithCustomerDocuments != null;
        [NotMapped]
        public bool AreWeWorkWithCounterpartiesDocuments => WorksWithCounterpartiesDocuments != null;

        public WorkWithCompanyDocuments? WorksWithCustomerDocuments { get; set; }
        public WorkWithCompanyDocuments? WorksWithCounterpartiesDocuments { get; set; }



        public List<ApprovalRoute> ApprovalRoutes { get; set; } = new List<ApprovalRoute>();


        public override string ToString()
        {
            return Title;
        }
    }
}
