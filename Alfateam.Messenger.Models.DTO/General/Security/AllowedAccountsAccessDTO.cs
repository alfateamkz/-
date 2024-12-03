using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.General.Security;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Security
{
    public class AllowedAccountsAccessDTO : DTOModelAbs<AllowedAccountsAccess>
    {
        public bool IsAllAccountsAccess { get; set; }

        [ForClientOnly]
        public List<AccountDTO> AllowedAccounts { get; set; } = new List<AccountDTO>();

        [HiddenFromClient]
        [DTOFieldBindWith("AllowedAccounts", typeof(MessengerMailingAccount))]
        public List<int> AllowedAccountsIds { get; set; } = new List<int>();
    }
}
