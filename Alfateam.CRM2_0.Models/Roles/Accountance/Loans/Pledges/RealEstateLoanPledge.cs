﻿using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Loans.Pledges
{
    /// <summary>
    /// Модель залога недвижимого имущества
    /// </summary>
    public class RealEstateLoanPledge : LoanObligationPledge
    {
        public Currency Currency { get; set; }
        [JsonIgnore]
        public int CurrencyId { get; set; }

        public double EstimatedCost { get; set; }


        public RealEstate RealEstate { get; set; }
        [JsonIgnore]
        public int RealEstateId { get; set; }

    }
}
