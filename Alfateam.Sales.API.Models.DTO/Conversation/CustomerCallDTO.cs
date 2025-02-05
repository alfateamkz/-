using Alfateam.Sales.API.Models.DTO.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Conversation
{
    public class CustomerCallDTO : CustomerConversationDTO
    {
        public string Phone { get; set; }
    }
}
