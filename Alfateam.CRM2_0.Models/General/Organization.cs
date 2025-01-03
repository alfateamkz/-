﻿using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Departments;
using Alfateam.CRM2_0.Models.Gamification;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель филиала компании
    /// </summary>
    public class Organization : AbsModel
    {
        public string Title { get; set; }
        public Address LegalAddress { get; set; }
        public string LegalInfo { get; set; }



        public TimeZone TimeZone { get; set; }


        public Country Country { get; set; }
        public LegalForm LegalForm { get; set; }
        public TaxSystem TaxSystem { get; set; }



        public GamificationModel Gamification { get; set; }

   
        public List<OrganizationOffice> Offices { get; set; } = new List<OrganizationOffice>();


        /// <summary>
        /// Отделы организации
        /// </summary>
        public DepartmentsGrouping Departments { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// Указывает на бизнес, которому принадлежит организация
        /// </summary>
        public int BusinessId { get; set; }



    }
}
