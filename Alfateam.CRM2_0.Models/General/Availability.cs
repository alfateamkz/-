using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Сущность доступности по странам
    /// Если AvailableForAllOrganization == true, то показывается во всех странах, кроме списка DisallowedOrganizations
    /// Если AvailableForAllOrganization == false, то показывается только в странах, которые в списке AllowedOrganizations
    /// Примечание. Подофисы офиса автоматически получают доступ к контенту
    /// </summary>
    public class Availability : AbsModel
    {
        /// <summary>
        /// Глобальный ли контент
        /// Может ставить только владелец CRM
        /// </summary>
        public bool AvailableForAllBusinesses { get; set; } = true;


        /// <summary>
        /// Будет ли контент отображаться во всех организациях владельца
        /// Если AvailableForAllBusinesses == true, то это поле вне зависимости от его значения тоже считается true
        /// </summary>
        public bool AvailableForAllOrganization { get; set; } = true;


        /// <summary>
        /// Будет ли контент отображаться во всех офисах какой-либо организации владельца
        /// Если AvailableForAllOrganization == true, то это поле вне зависимости от его значения тоже считается true
        /// </summary>
        public bool AvailableForAllOrganizationOffices { get; set; } = true;



        public List<Organization> AllowedOrganizations { get; set; } = new List<Organization>();
        public List<Organization> DisallowedOrganizations { get; set; } = new List<Organization>();


        public List<OrganizationOffice> AllowedOffices { get; set; } = new List<OrganizationOffice>();
        public List<OrganizationOffice> DisallowedOffices { get; set; } = new List<OrganizationOffice>();



    }
}
