using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    /// <summary>
    /// Группирование отделов
    /// Некоторые поля могут пустыми по причине отсутствия отдела
    /// Например: есть организация, у нее есть бухгалтерия. 
    /// У организации есть несколько офисов/филиалов, но бухгалтерия на всех одна
    /// </summary>
    public class DepartmentsGrouping : AbsModel
    {
        public AccountanceDepartment? Accountance { get; set; }
        public ComplianceDepartment? Compliance { get; set; }
        public FinanceDepartment? Finance { get; set; }
        public HRDepartment? HR { get; set; }
        public LawDepartment? Law { get; set; }
        public MarketingDepartment? Marketing { get; set; }
        public SalesDepartment? Sales { get; set; }
        public SecurityServiceDepartment? SecurityService { get; set; }
    }
}
