using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger
{
    /// <summary>
    /// Базовая модель сообщения в чате
    /// </summary>
    public abstract class Message : AbsModel
    {
        /// <summary>
        /// Пользователь, который отправил сообщение
        /// Если SentBy == null, то системное уведомление в чате(например, кто-то кого-то добавил)
        /// </summary>
        public User? SentBy { get; set; }


        /// <summary>
        /// Список сообщений, на которые дан ответ
        /// </summary>
        public List<Message> RepliedMessages { get; set; } = new List<Message>();
        /// <summary>
        /// Список пересланных сообщений
        /// </summary>
        public List<Message> ForwardedMessages { get; set; } = new List<Message>();

    }
}
