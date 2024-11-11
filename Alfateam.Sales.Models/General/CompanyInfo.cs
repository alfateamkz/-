using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class CompanyInfo : AbsModel
    {
        public string CountryCode { get; set; }


        public string LegalName { get; set; }
        public string LegalInfo { get; set; }



        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }

    }
}
