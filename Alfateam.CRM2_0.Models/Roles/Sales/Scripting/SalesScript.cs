using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Scripting
{
    /// <summary>
    /// Модель сущности скрипта продаж
    /// </summary>
    public class SalesScript : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        /// <summary>
        /// Начало скрипта
        /// </summary>
        public SalesScriptBlock Start { get; set; }
    }
}
