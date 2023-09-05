using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
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
        public int? AccountanceId { get; set; }

        public ComplianceDepartment? Compliance { get; set; }
        public int? ComplianceId { get; set; }

        public FinanceDepartment? Finance { get; set; }
        public int? FinanceId { get; set; }


        public HRDepartment? HR { get; set; }
        public int? HRId { get; set; }


        public LawDepartment? Law { get; set; }
        public int? LawId { get; set; }

        public MarketingDepartment? Marketing { get; set; }
        public int? MarketingId { get; set; }

        public SalesDepartment? Sales { get; set; }
        public int? SalesId { get; set; }

        public SecurityServiceDepartment? SecurityService { get; set; }
        public int? SecurityServiceId { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? OrganizationId { get; set; }
        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? OrganizationOfficeId { get; set; }



        public Department GetDepartment(Type type)
        {
            var props = this.GetType().GetProperties();
            var prop = props.FirstOrDefault(o => o.PropertyType == type);

            return prop.GetValue(this) as Department;
        }
    }
}
