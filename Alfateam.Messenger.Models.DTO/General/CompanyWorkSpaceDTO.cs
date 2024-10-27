using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General
{
    public class CompanyWorkSpaceDTO : DTOModelAbs<CompanyWorkSpace>
    {
        public string Title { get; set; }


        public string? BusinessNumber { get; set; }
        public string CountryCode { get; set; }


        [ForClientOnly]
        public string? LogoPath { get; set; }
        public string? Description { get; set; }




        [ForClientOnly]
        public List<UserDTO> Users { get; set; } = new List<UserDTO>();
    }
}
