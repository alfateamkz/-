using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Conversation;
using Alfateam.Sales.API.Models.DTO.Orders;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.Orders;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<CustomerConversationDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CustomerCallDTO), "CustomerCall")]
    [JsonKnownType(typeof(CustomerConferenceDTO), "CustomerConference")]
    [JsonKnownType(typeof(CustomerMeetingDTO), "CustomerMeeting")]
    public class CustomerConversationDTO : DTOModelAbs<CustomerConversation>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        [HiddenFromClient]
        public int CustomerId { get; set; }
        public CustomerCommunicationStatus Status { get; set; } 



        public DateTime PlannedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }



        [ForClientOnly]
        [Description("Заказы, которые планируются обсуждаться на встрече")]
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();


        [HiddenFromClient]
        [DTOFieldBindWith("Orders", typeof(Order))]
        public List<int> OrdersIds { get; set; } = new List<int>();



        public string? Comment { get; set; }
        [ForClientOnly]
        public string? CommunicationRecordPath { get; set; }

    }
}
