using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Conversation
{
    public class CustomerMeetingAttachment : AbsModel
    {
        public string Filepath { get; set; }
        public string? Comment { get; set; }
    }
}
