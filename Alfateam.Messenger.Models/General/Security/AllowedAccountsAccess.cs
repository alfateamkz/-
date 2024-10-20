using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Security
{
    public class AllowedAccountsAccess : AbsModel
    {
        public bool IsAllAccountsAccess { get; set; } = true;
        public List<Account> AllowedAccounts { get; set; } = new List<Account>();
    }
}
