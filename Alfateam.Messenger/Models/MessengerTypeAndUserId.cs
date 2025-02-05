using Alfateam.Messenger.API.Enums;

namespace Alfateam.Messenger.API.Models
{
    public class MessengerTypeAndUserId
    {
        public MessengerTypeAndUserId(AlfateamMessengerType type, int userId)
        {
            Type = type;
            UserId = userId;
        }

        public AlfateamMessengerType Type { get; set; }
        public int UserId { get; set; }
    }
}
