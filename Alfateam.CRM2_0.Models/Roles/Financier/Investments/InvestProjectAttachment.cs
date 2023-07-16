using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Financier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Investments
{
    /// <summary>
    /// Сущность вложения к инвест проекту
    /// </summary>
    public class InvestProjectAttachment : AbsModel
    {
        public string Title { get; set; }
        public string Filepath { get; set; }

        public InvestProjectAttachmentType Type { get; set; } = InvestProjectAttachmentType.BusinessPlan;
    }
}
