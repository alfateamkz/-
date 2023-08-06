using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Gateways.Models.Credentials
{
    public class EmailCredentials
    {

        public EmailCredentials(string email, string password, string displayName)
        {
            Email = email;
            Password = password;
            DisplayName = displayName;
        }


        public string Email { get; set; }
        public string Password { get; set; }


        public string DisplayName { get; set; }
    }
}
