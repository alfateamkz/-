using Alfateam.Core.Attributes.DTO;
using Alfateam.TicketSystem.Models.DTO.General.WorkingDays;
using Alfateam.TicketSystem.Models.General;
using Alfateam.TicketSystem.Models.General.WorkingDays;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.DTO.General
{
    public class BusinessCompanyDTO : DTOModelAbs<BusinessCompany>
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }



        public string? Description { get; set; }
        public string? CountryCode { get; set; }
        public string? BusinessNumber { get; set; }


        [ForClientOnly]
        public string? LogoPath { get; set; }



        public BusinessCompanyTicketSettingsDTO TicketSettings { get; set; }
        public CompanyWorkingDaysDTO WorkingDays { get; set; }
    }
}
