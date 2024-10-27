using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions
{
    public class AccountDTO : DTOModelAbs<Account>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
