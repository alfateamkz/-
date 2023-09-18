using Alfateam.CRM2_0.Models.Roles.Marketing.Referral;
using Alfateam.CRM2_0.Models.Roles.Marketing.Referral.Programs;
using Alfateam.CRM2_0.Models.Roles.Marketing.Tasks;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing
{


    [JsonConverter(typeof(JsonKnownTypesConverter<BaseReferralProgram>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(MultiLevelReferralProgram), "MultiLevelReferralProgram")]
    [JsonKnownType(typeof(SimpleReferralProgram), "SimpleReferralProgram")]
    /// <summary>
    /// Базовая модель реферальной программы
    /// </summary>
    public class BaseReferralProgram : AbsModel
    {
  
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Минимальный лимит на вывод средств
        /// </summary>
        public double MinLimit { get; set; }






        /// <summary>
        /// Участники реферальной программы
        /// </summary>
        public List<Referral> Referrals { get; set; } = new List<Referral>();

		/// <summary>
		/// Чисто инкремент для того, чтобы каждый раз не вычислять кол-во
		/// </summary>
		public int ReferralsCount { get; set; }


		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int MarketingDepartmentId { get; set; }
	}
}
