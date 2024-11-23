using Alfateam.Core;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.BusinessProposals
{
    public class BusinessProposal : AbsModel
    {
        public string UniqueURL { get; set; } = $"{DateTime.UtcNow.ToString("dd-MM-yyyy")}-{System.Guid.NewGuid().ToString()}";


        public PersonContact? PersonContact { get; set; }
        public int? PersonContactId { get; set; }



        public Company? Company { get; set; }
        public int? CompanyId { get; set; }





        public string Title { get; set; }
        public string? HTMLContent { get; set; }
        public CurrencyAndValue Sum { get; set; }



        public DateTime? ExpiresAt { get; set; }





        /// <summary>
        /// Информация о канбане, в котором находится КП
        /// </summary>
        public BusinessProposalsKanbanData KanbanData { get; set; }
        public int KanbanDataId { get; set; }






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
