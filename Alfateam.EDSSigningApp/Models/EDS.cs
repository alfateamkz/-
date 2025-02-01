using Alfateam.EDSSigningApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDSSigningApp.Models
{
    public class EDS
    {
        public string Owner { get; set; }
        public string? OwnerOrganization { get; set; }
        public string? OwnerOrganizationNumber { get; set; }
        public string OwnerCountry { get; set; }
        public string OwnerType { get; set; }


        public EDSType Type { get; set; }
        public DateTime NotBefore { get; set; }
        public DateTime NotAfter { get; set; }


        public string ValidityPeriodString => $"{NotBefore.ToString("dd MMMM yyyy")} - {NotAfter.ToString("dd MMMM yyyy")}";



        public string CA_Info { get; set; }


        public bool IsNotInDateOfValidity => NotBefore > DateTime.UtcNow || NotAfter < DateTime.UtcNow;
        public bool HasOrganizationInfo => !string.IsNullOrEmpty(OwnerOrganization) && !string.IsNullOrEmpty(OwnerOrganizationNumber);
    }
}
