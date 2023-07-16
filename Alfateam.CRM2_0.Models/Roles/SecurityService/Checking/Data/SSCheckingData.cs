using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Data
{
    /// <summary>
    /// Данные для проверки сотрудником СБ
    /// </summary>
    public class SSCheckingData : AbsModel
    {
        public string Data { get; set; }
        public List<SSCheckingDataAttachment> Attachments { get; set; } = new List<SSCheckingDataAttachment>();
    }
}
