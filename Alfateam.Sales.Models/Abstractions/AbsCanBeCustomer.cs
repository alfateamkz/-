using Alfateam.Core;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.BusinessProposals.Placeholders;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Orders;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<AbsCanBeCustomer>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(Company), "Company")]
    [JsonKnownType(typeof(PersonContact), "PersonContact")]
    public class AbsCanBeCustomer : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public List<ContactInfo> Contacts { get; set; } = new List<ContactInfo>();
        public string? Comment { get; set; }



        public List<Order> Orders { get; set; } = new List<Order>();
        public List<CustomerConversation> Conversations { get; set; } = new List<CustomerConversation>();
        public List<BusinessProposal> Proposals { get; set; } = new List<BusinessProposal>();





        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
