using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO
{
    public class ChatBackgroundDTO : DTOModelAbs<ChatBackground>
    {
        [ForClientOnly]
        public string Filepath { get; set; }

        [ForClientOnly]
        [Description("Если AccountId == null, то фон встроенный\r\n Если AccountId != null, то фон загружен пользователем")]
        public int? AccountId { get; set; }
    }
}
