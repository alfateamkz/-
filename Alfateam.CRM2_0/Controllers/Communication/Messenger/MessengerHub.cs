using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Helpers;
using Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.Communication.Messenger.Chats;
using Alfateam.CRM2_0.Models.Communication.Messenger.Messages;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Communication.Messenger;
using Alfateam.CRM2_0.Models.CreateModels.Communication.Messenger.Messages;
using Alfateam.CRM2_0.Models.General;
using Alfateam.DB;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Alfateam.CRM2_0.Controllers.Communication.Messenger
{

	
	public class MessengerHub : AbsHub
	{
		public MessengerHub(ControllerParams @params) : base(@params)
		{
		}


		public async Task SendMessage(int chatId, MessageCreateModel model)
		{
			var authorizedUser = SessionUserHelper.GetAuthorizedUser(DB, SessID);
			var chat = DB.Chats.FirstOrDefault(o => o.Id == chatId && !o.IsDeleted);

			await TryFinishAllRequestes("ReceiveMessage", new[]
			{
				() => BaseCheckSession(),
				() => CheckChatAccess(authorizedUser, chat),
                () => RequestResult.FromBoolean(model.IsValid(),400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var message = model.Create();
					message.SentById = authorizedUser.Id;

					foreach (var repliedMsgId in model.RepliedMessagesIds)
					{
						var repliedMsg = DB.Messages.FirstOrDefault(o => o.Id == repliedMsgId && !o.IsDeleted);
						if(repliedMsg == null)
						{
							return RequestResult.AsError(404, $"Отвеченное сообщение с id={repliedMsgId} не найдено");
						}
						else if(repliedMsg.ChatId != chatId)
						{
							return RequestResult.AsError(404, $"Отвеченное сообщение не принадлежит текущему чату");
						}

						message.RepliedMessages.Add(repliedMsg);
					}

					if(message is CommonMessage commonMsg)
					{

					}

					//TODO: проверка пересланных сообщений на доступ к ним

					chat.Messages.Add(message);
					DB.Chats.Update(chat);
					DB.SaveChanges();

					return RequestResult<Message>.AsSuccess(message);
				}
			});
		}
		public async Task ReadMessage(int chatId, int messageId)
		{
            var authorizedUser = SessionUserHelper.GetAuthorizedUser(DB, SessID);
            var chat = DB.Chats.FirstOrDefault(o => o.Id == chatId && !o.IsDeleted);
			var message = DB.Messages.FirstOrDefault(o => o.Id == messageId && !o.IsDeleted);

            await TryFinishAllRequestes("ReceiveMessage", new[]
            {
                () => BaseCheckSession(),
				() => CheckChatAndMessage(authorizedUser,chat, message),
                () => RequestResult.FromBoolean(!message.IsRead, 400,"Сообщение уже прочитано"),
                () => RequestResult.FromBoolean(message.SentById != authorizedUser.Id, 403,"Нельзя прочитать свое сообщение"),
				() =>
				{
					message.IsRead = true;

                    DB.Messages.Update(message);
                    DB.SaveChanges();

                    return RequestResult<int>.AsSuccess(message.Id);
                }
            });
        }





        #region Private check methods

        private RequestResult CheckChatAccess(User authorizedUser, Chat chat)
		{
			return TryFinishAllRequestes(new[]
			{
                () => RequestResult.FromBoolean(chat != null, 404,"Чат с данным id не найден"),
                () =>
                {
                    IncludeChatMembersIds(chat);
                    return RequestResult.AsSuccess();
                },
                () => RequestResult.FromBoolean(chat.HasUserAccess(authorizedUser.Id),403,"Нет доступа к чату"),
            });
        }

		private RequestResult CheckChatAndMessage(User authorizedUser, Chat chat, Message message)
		{
            return TryFinishAllRequestes(new[]
            {
				() => CheckChatAccess(authorizedUser, chat),
                () => RequestResult.FromBoolean(message != null, 404,"Сообщение с данным id не найдено"),
                () => RequestResult.FromBoolean(message.ChatId == chat.Id, 403,"Нет доступа к данному сообщению"),
            });
        }

        #endregion


        #region Private includes methods

        private void IncludeChatMembersIds(Chat chat)
		{
			 if (chat is GroupChat groupChat)
			{
				groupChat.Members = DB.GroupChatUserInfos.Where(o => o.GroupChatId == groupChat.Id).ToList();
			}
		}
		private void FullIncludeChatFields(Chat chat)
		{
			if(chat is PrivateChat privateChat)
			{
				privateChat.CreatedBy = DB.Users.FirstOrDefault(o => o.Id == privateChat.CreatedById);
				privateChat.CreatedWith = DB.Users.FirstOrDefault(o => o.Id == privateChat.CreatedWithId);
			}
			else if(chat is GroupChat groupChat)
			{
				groupChat.CreatedBy = DB.Users.FirstOrDefault(o => o.Id == groupChat.CreatedById);
				groupChat.Members = DB.GroupChatUserInfos.Include(o => o.User)
														 .Where(o => o.GroupChatId == groupChat.Id).ToList();
			}
			else
			{
				throw new NotImplementedException("Check for new types of Chat entity");
			}
		}

		#endregion




	}
}
