using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Причина, по которой был сорван срок по этапу заказа
    /// </summary>
    public class DeadlineFailedReason : AbsModel
    {
        public string Title { get; set; }
    }
}
