using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General
{
    public class CompanyWorkSpace : AbsModel
    {
        public string Title { get; set; }


        public string? BusinessNumber { get; set; }
        public string CountryCode { get; set; }


        public string? LogoPath { get; set; }
        public string? Description { get; set; }





        public List<User> Users { get; set; } = new List<User>();

    }
}
