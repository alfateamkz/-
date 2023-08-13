using Alfateam.CRM2_0.Models.Departments;
using Alfateam.CRM2_0.Models.Roles.Staff.Employess;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions
{


    [JsonConverter(typeof(JsonKnownTypesConverter<Department>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(AccountanceDepartment), "AccountanceDepartment")]
    [JsonKnownType(typeof(ComplianceDepartment), "ComplianceDepartment")]
    [JsonKnownType(typeof(FinanceDepartment), "FinanceDepartment")]
    [JsonKnownType(typeof(HRDepartment), "HRDepartment")]
    [JsonKnownType(typeof(LawDepartment), "LawDepartment")]
    [JsonKnownType(typeof(MarketingDepartment), "MarketingDepartment")]
    [JsonKnownType(typeof(SalesDepartment), "SalesDepartment")]
    [JsonKnownType(typeof(SecurityServiceDepartment), "SecurityServiceDepartment")]
    /// <summary>
    /// Базовая сущность отдела
    /// </summary>
    public abstract class Department : AbsModel
    {
        /// <summary>
        /// Руководитель отдела. В разных отделах имеет разные названия, но суть одна
        /// Например: в бухгалтерии Head - главбух
        /// Если нет отдельного руководителя, то руководителем является директор организации/филиала
        /// </summary>
        public Employee Head { get; set; }
    }
}
