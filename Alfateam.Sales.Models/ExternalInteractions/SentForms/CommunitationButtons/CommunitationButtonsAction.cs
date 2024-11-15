using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.SentForms.CommunitationButtons
{
    public class CommunitationButtonsAction : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int CommunitationButtonsActionsSessionId { get; set; }
    }
}
