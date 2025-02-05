using Alfateam.Core.Attributes.DTO;
using Alfateam.ID.Models.Security;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.ID.Models.DTO.Security
{
    public class SessionDTO : DTOModelAbs<Session>
    {
        [ForClientOnly]
        public string IP { get; set; }

        [ForClientOnly]
        public string UserAgent { get; set; }

        [ForClientOnly]
        public string Fingerprint { get; set; }
    }
}
