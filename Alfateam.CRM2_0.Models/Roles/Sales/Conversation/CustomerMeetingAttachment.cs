using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Conversation
{
    public class CustomerMeetingAttachment : AbsModel
    {
        public string Filepath { get; set; }
        public string? Comment { get; set; }
    }
}
