using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Orders.Milestones
{
    /// <summary>
    /// Модель вложения для пункта отчета по этапу заказа
    /// </summary>
    public class OrderMilestoneReportItemAttachment : AbsModel
    {
        public string? Comment { get; set; }
        public string AttachmentPath { get; set; }
    }
}
