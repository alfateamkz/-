using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Элемент матрицы цен по странам
    /// </summary>
    public class PricingMatrixItem : AbsModel
    {
        /// <summary>
        /// Страна, для которой применяются стоимость 
        /// Если Country == null, то эти стоимости применяются для прочих стран(которые не указаны в матрице цен)
        /// </summary>
        public Country? Country { get; set; }
        public int? CountryId { get; set; }


        /// <summary>
        /// Стоимости. Например, в Польше может быть две цены(в евро и в злотых)
        /// </summary>
        public List<Cost> Costs { get; set; } = new List<Cost>(); 
      
    }
}
