using Alfateam.Core;
using Alfateam.Sales.Models.BusinessProposals.Placeholders;
using Alfateam.Sales.Models.Conversation;
using Alfateam.Sales.Models.Enums;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<CustomerConversation>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CustomerCall), "CustomerCall")]
    [JsonKnownType(typeof(CustomerConference), "CustomerConference")]
    [JsonKnownType(typeof(CustomerMeeting), "CustomerMeeting")]
    public class CustomerConversation : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public int CustomerId { get; set; }
        public CustomerCommunicationStatus Status { get; set; } = CustomerCommunicationStatus.Planned;



        public DateTime PlannedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }



        /// <summary>
        /// Заказы, которые планируются обсуждаться на встрече
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();



        public string? Comment { get; set; }
        public string? CommunicationRecordPath { get; set; }
    }
}
