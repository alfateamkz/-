using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.ClientModels.General;

namespace Alfateam.CRM2_0.Models.ClientModels.Abstractions.Communication.Messenger
{
	public class MessageClientModel : ClientModel<Message>
	{
		/// <summary>
		/// Пользователь, который отправил сообщение
		/// Если SentBy == null, то системное уведомление в чате(например, кто-то кого-то добавил)
		/// </summary>
		public UserClientModel? SentBy { get; set; }



		/// <summary>
		/// Список сообщений, на которые дан ответ
		/// </summary>
		public List<MessageClientModel> RepliedMessages { get; set; } = new List<MessageClientModel>();
		/// <summary>
		/// Список пересланных сообщений
		/// </summary>
		public List<MessageClientModel> ForwardedMessages { get; set; } = new List<MessageClientModel>();
	}
}
