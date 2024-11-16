using Alfateam.Core;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
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


        public string Title { get; set; }
        public string HTMLContent { get; set; }


        public DateTime? ExpiresAt { get; set; }




        public Customer Customer { get; set; }
        public int CustomerId { get; set; }



        /// <summary>
        /// Информация о канбане, в котором находится КП, если не равно null
        /// </summary>
        public BusinessProposalsKanbanData? KanbanData { get; set; }
        public int? KanbanDataId { get; set; }
    }
}
