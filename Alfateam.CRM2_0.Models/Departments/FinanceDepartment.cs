﻿using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Financier.Investments;
using Alfateam.CRM2_0.Models.Roles.Financier.Planning;
using Alfateam.CRM2_0.Models.Roles.Financier.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    /// <summary>
    /// Отдел финансов
    /// </summary>
    public class FinanceDepartment : AbsModel
    {

        #region Investments
        public List<Investment> Investments { get; set; } = new List<Investment>();
        public List<InvestProject> InvestProjects { get; set; } = new List<InvestProject>();
        #endregion 

        #region Planning
        public List<FinanicialPlan> FinanicialPlans { get; set; } = new List<FinanicialPlan>();

        #endregion

        #region Pricing
        public List<PricingModel> PricingModels { get; set; } = new List<PricingModel>();
        public List<Service> Services { get; set; } = new List<Service>();

        #endregion

        ///TODO: проверить и доработать финансовый отдел и роль
    }
}
