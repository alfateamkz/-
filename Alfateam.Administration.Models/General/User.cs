using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.General
{
    public class User : AbsModel
    {
        public string AlfateamID { get; set; }



        public UserRoleModel RoleModel { get; set; }
        public bool IsBlocked { get; set; }
    }
}
