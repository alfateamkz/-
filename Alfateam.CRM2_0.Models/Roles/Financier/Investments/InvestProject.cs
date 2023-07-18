using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Financier;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using Alfateam.CRM2_0.Models.Enums.Roles.Financier;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Accountance;
using Alfateam.CRM2_0.Models.Roles.Financier.Investments.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Investments
{
    /// <summary>
    /// Сущность нашего инвест проекта
    /// </summary>
    public class InvestProject : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public InvestProjectStatus Status { get; set; } = InvestProjectStatus.Research;


        public Currency Currency { get; set; }
        public decimal RequiredSum { get; set; }

        /// <summary>
        /// Условия по инвестиции. Депозитарная или долевая
        /// </summary>
        public InvestmentCondition InvestmentCondition { get; set; }


        
        /// <summary>
        /// Вложения к инвест проекту
        /// </summary>
        public List<InvestProjectAttachment> Attachments { get; set; } = new List<InvestProjectAttachment>();






        /// <summary>
        /// Счет инвест проекта
        /// Значение может быть равно null, если проект еще не начат
        /// При старте проекта необходимо создать счет проекта, если он не создан
        /// Account.Type обязательно должен быть равен InvestProject
        /// </summary>
        public Account? Account { get; set; }

        /// <summary>
        /// Учет инвестиций в нас
        /// </summary>
        public List<InvestProjectDeposit> Deposits { get; set; } = new List<InvestProjectDeposit>();
    }
}
