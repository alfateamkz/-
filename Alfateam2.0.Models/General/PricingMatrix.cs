using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Матрица цен по странам
    /// </summary>
    public class PricingMatrix : AbsModel
    {
        public List<PricingMatrixItem> Costs { get; set; } = new List<PricingMatrixItem>();
    }
}
