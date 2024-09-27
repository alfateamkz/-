using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General
{
    public class WorkWithCompanyDocuments : AbsModel
    {
        public string FIO { get; set; }
        public string? Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? OtherInfo { get; set; }

    }
}
