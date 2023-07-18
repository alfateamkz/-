using Alfateam.CRM2_0.Models.Abstractions.Roles.Sales;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Franchising.Conditions
{
    /// <summary>
    /// Модель договоренности по франшизе, где ее владелец получает ЗП и процент
    /// </summary>
    public class DirectorFranchiseSaleConditions : FranchiseSaleConditions
    {
        public Cost Salary { get; set; }
        public double Percent { get; set; }
    }
}
