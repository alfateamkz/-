using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.SentForms.CommunitationButtons
{
    public class CommunitationButtonsActionsSession : AbsModel
    {
        public string UserAgent { get; set; }
        public string IP { get; set; }


        public List<CommunitationButtonsAction> Actions { get; set; } = new List<CommunitationButtonsAction>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int CommunitationButtonsExtInterationId { get; set; }
    }
}
