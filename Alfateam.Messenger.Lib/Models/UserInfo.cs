using Alfateam.Messenger.Lib.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Models
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public AbsImageFile? Avatar { get; set; }
    }
}
