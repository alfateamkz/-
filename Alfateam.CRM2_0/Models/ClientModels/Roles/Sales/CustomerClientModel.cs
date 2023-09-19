using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Sales;
using Alfateam.CRM2_0.Models.Roles.Sales.Conversation;

namespace Alfateam.CRM2_0.Models.ClientModels.Roles.Sales
{
	public class CustomerClientModel : UserClientModel
	{
		/// <summary>
		/// Юридическая форма
		/// Если Company != null, то формы компании и клиента должны совпадать
		/// </summary>
		public LegalFormClientModel Form { get; set; }
		public CompanyClientModel? Company { get; set; }



		


		/// <summary>
		/// Продажник, который привлек данного клиента 
		/// </summary>
		public UserClientModel FoundBy { get; set; }


	    
	}
}
