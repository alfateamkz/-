using Alfateam.CertificationCenter.Models.Enums;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.General
{
    public class IssueRequestInfo : AbsModel
    {
        public IssueRequestStatus Status { get; set; } = IssueRequestStatus.Waiting;
        public string? Comment { get; set; }
    }
}
