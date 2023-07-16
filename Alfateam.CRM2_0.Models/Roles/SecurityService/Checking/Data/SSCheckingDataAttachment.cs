using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.SecurityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Data
{
    /// <summary>
    /// Модель вложения к информации для проверки (SSCheckingData)
    /// </summary>
    public class SSCheckingDataAttachment : AbsModel
    {
        public SSCheckingDataAttachmentType AttachmentType { get; set; }
        public string AttachmentPath { get; set; }


    }
}
