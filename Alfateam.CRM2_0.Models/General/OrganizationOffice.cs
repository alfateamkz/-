using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{

    public class OrganizationOffice : AbsModel
    {
        /// <summary>
        /// Реальный ли офис или виртуальный
        /// </summary>
        public bool IsReal { get; set; } = true;
        public OrganizationOfficeType Type { get; set; } = OrganizationOfficeType.Headquarters;


        /// <summary>
        /// Адрес офиса. Равен null, если IsReal == false
        /// </summary>
        public Address? Address { get; set; }
        public TimeZone TimeZone { get; set; }


        public List<Employee> Employees { get; set; } = new List<Employee>();


        /// <summary>
        /// Офисы, находящиеся в подчинении у данного офиса
        /// Структура офисов в целом: штаб-квартира -> главные офисы по странам -> региональные офисы -> офисы
        /// Структура офисов данного списка: главные офисы по странам -> региональные офисы -> офисы.
        /// Так потому-что штаб-квартира одновременно является главным офисом по стране, в которой находится
        /// </summary>
        public List<OrganizationOffice> SubOffices { get; set; } = new List<OrganizationOffice>();

        /// <summary>
        /// Счета филиала
        /// Если список пуст, то используются счета вышестоящего филиала или огранизации в целом
        /// </summary>
        public List<Account> Accounts { get; set; } = new List<Account>();




    }
}
