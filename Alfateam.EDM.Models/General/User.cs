using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General
{
    public class User : AbsModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }


        public string Position { get; set; }

        public string Email { get; set; }   
        public string Phone { get; set; }



        public UserPermissions Permissions { get; set; }
        public List<TrustedUserIPAddress> TrustedUserIPs { get; set; } = new List<TrustedUserIPAddress>();
    }
}
