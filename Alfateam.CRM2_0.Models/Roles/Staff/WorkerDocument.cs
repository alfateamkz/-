using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff
{
    /// <summary>
    /// Модель документа сотрудника
    /// </summary>
    public class WorkerDocument : AbsModel
    {
        public WorkerDocumentType Type { get; set; }
        public string AttachmentPath { get; set; }
    }
}
