using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.Models.Conversation;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Conversation
{
    public class CustomerMeetingAttachmentDTO : DTOModelAbs<CustomerMeetingAttachment>
    {
        [ForClientOnly]
        public string Filepath { get; set; }
        public string? Comment { get; set; }
    }
}
