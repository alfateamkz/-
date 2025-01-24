using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO
{
    public class TicketCategoryDTO : DTOModelAbs<TicketCategory>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public List<TicketCategoryDTO> Subcategories { get; set; } = new List<TicketCategoryDTO>();




        [HiddenFromClient, Description("ID родителя")]
        public int? TicketCategoryId { get; set; }
    }
}
