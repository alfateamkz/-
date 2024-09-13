using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.CRM2_0.Models.Communication.Messenger.Chats;
using Alfateam.CRM2_0.Models.Communication.Messenger.Messages;
using Alfateam.CRM2_0.Models.General;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger
{

    [JsonConverter(typeof(JsonKnownTypesConverter<Message>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(CommonMessage), "CommonMessage")]
    [JsonKnownType(typeof(VoiceMessage), "VoiceMessage")]
    /// <summary>
    /// Базовая модель сообщения в чате
    /// </summary>
    public class Message : AbsModel
    {
        /// <summary>
        /// Пользователь, который отправил сообщение
        /// Если SentBy == null, то системное уведомление в чате(например, кто-то кого-то добавил)
        /// </summary>
        public User? SentBy { get; set; }
		public int? SentById { get; set; }



        public bool IsRead { get; set; }


		/// <summary>
		/// Список сообщений, на которые дан ответ
		/// </summary>
		public List<Message> RepliedMessages { get; set; } = new List<Message>();
        /// <summary>
        /// Список пересланных сообщений
        /// </summary>
        public List<Message> ForwardedMessages { get; set; } = new List<Message>();




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ChatId { get; set; }
	}
}
