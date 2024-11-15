using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Orders
{
    public class OrderStatus : AbsModel
    {
        public string Title { get; set; }
        public OrderStatusType Type { get; set; }



        [NotMapped]
        public bool IsDefault => BusinessCompanyId == null;


        /// <summary>
        /// Автоматическое поле, не равно null, если статус создан пользователем (кастомный).
        /// В таком случае Type будет равен OrderStatusType.Custom
        /// </summary>
        public int? BusinessCompanyId { get; set; }
    }
}
