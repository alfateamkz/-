using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.General.Security
{
    public class TrustedUserIPAddress : AbsModel
    {
        public string IPAddress { get; set; }
    }
}
