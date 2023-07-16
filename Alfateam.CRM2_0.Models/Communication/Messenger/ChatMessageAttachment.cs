using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Messenger
{
    /// <summary>
    /// Модель вложения к сообщению
    /// </summary>
    public class ChatMessageAttachment : AbsModel
    {
        public string AttachmentPath { get; set; }
    }
}
