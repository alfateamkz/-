using Alfateam.Messenger.API.Enums;

namespace Alfateam.Messenger.API.Models
{
    public class MessengerWSConnectedUser
    {
        public string ConnectionId { get; set; }
        public int Id { get; set; }
        public MessengerType Type { get; set; }
    }
}
