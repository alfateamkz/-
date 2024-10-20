using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Security
{
    public class UserPermissions : AbsModel
    {
        public bool CanCreateGroups { get; set; } = true;


        public bool CanDeleteMessages { get; set; } = true;
        public bool CanDeleteChats { get; set; } = true;
    }
}
