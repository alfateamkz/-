using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Chats
{
    public class ChatNotificationSettingsDTO : DTOModelAbs<ChatNotificationSettings>
    {
        [ForClientOnly]
        [Description("Звук уведомления. Если пусто, то звук проигрывается по умолчанию")]
        public string? SoundFilepath { get; set; }



        [ForClientOnly]
        public bool IsMuted => MutedBefore == null;

        [ForClientOnly]
        public DateTime? MutedBefore { get; set; }
    }
}
