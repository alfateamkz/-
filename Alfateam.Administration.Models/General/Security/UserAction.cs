using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.General.Security
{
    public class UserAction : AbsModel
    {
        public User User { get; set; }
        public int UserId { get; set; }



        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
