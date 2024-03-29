﻿using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Departments;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Staff;
using Newtonsoft.Json;
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



        /// <summary>
        /// Офисы, находящиеся в подчинении у данного офиса
        /// Структура офисов в целом: штаб-квартира -> главные офисы по странам -> региональные офисы -> офисы
        /// Структура офисов данного списка: главные офисы по странам -> региональные офисы -> офисы.
        /// Так потому-что штаб-квартира одновременно является главным офисом по стране, в которой находится
        /// </summary>
        public List<OrganizationOffice> SubOffices { get; set; } = new List<OrganizationOffice>();

     



        /// <summary>
        /// Отделы офиса/филиала. 
        /// Значение обязательно не должно быть равным null, 
        /// но если в офисе/филиале нет отдельных отделов(используются вышестоящие), 
        /// то все отделы внутри могут быть равны null
        /// </summary>
        public DepartmentsGrouping Departments { get; set; }


        /// <summary>
        /// Сотрудники офиса/филиала
        /// </summary>
        public OrganizationOfficeStaff Staff { get; set; }




        /// <summary>
        /// Бизнес, в котором находится офис. 
        /// Обязательное поле, нужно, чтобы навигацию было удобно делать
        /// </summary>
        [JsonIgnore]
        public Business Business { get; set; }
        [JsonIgnore]
        public int BusinessId { get; set; }

        /// <summary>
        /// Автоматическое поле
        /// Идентификатор родительского офиса, если он есть
        /// </summary>
        [JsonIgnore]
        public int? OrganizationOfficeId { get; set; }

        /// <summary>
        /// Автоматическое поле
        /// Идентификатор организации, если вышестоящих офисов нет
        /// </summary>
        [JsonIgnore]
        public int? OrganizationId { get; set; }

    }
}
