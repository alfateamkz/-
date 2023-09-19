using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger;

namespace Alfateam.CRM2_0.Models.CreateModels.Abstractions.Communication.Messenger
{
	public abstract class MessageCreateModel : CreateModel<Message>
	{
		public int? SentById { get; set; }


		/// <summary>
		/// Список сообщений, на которые дан ответ
		/// </summary>
		public List<int> RepliedMessagesIds { get; set; } = new List<int>();
	
		/// <summary>
		/// Список пересланных сообщений
		/// </summary>
		public List<int> ForwardedMessagesIds { get; set; } = new List<int>();
	}
}
