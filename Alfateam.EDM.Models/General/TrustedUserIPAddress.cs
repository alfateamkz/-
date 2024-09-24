using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General
{
    public class TrustedUserIPAddress : AbsModel
    {
        public string IPAddress { get; set; }
    }
}
