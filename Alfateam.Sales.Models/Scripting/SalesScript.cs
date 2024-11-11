using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Scripting
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
        public SalesScriptBlock StartBlock { get; set; }
		public int StartBlockId { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }

    }
}
