using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Lib.Extensions;
using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.Chats;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenQA.Selenium.BiDi.Modules.Script.RemoteValue;

namespace Alfateam.Messenger.Lib.Modules.Viber
{
    public class ViberChatsModule : ChatsModule
    {
        //TODO: chat admin id


        private ViberMessenger Messenger;
        public ViberChatsModule(ViberMessenger messenger)
        {
            Messenger = messenger;
        }



        public override async Task<Chat> CreateChat(Chat chat)
        {     
            await Messenger.ThrowIfNotAuthorized();

            throw new NotImplementedException();
        }

        public override async Task<ChatDeletionResult> DeleteChat(string id)
        {
            await Messenger.ThrowIfNotAuthorized();

            throw new NotImplementedException();
        }

        public override async Task<Chat> EditChat(Chat chat)
        {
            await Messenger.ThrowIfNotAuthorized();

            throw new NotImplementedException();
        }

        public override async Task<Chat> GetChat(string id)
        {
            await Messenger.ThrowIfNotAuthorized();

            Messenger.Driver.Deeplink($"viber://chat?number={id}", ViberMessenger.APP_BUNDLE_ID);

            var elems = Messenger.Driver.FindElements(By.XPath("//*")).ToList();
            var resourceIds = elems.Select(o => o.GetResourceId()).ToList();
            var resourceIds2 = elems.Select(o => o.GetElementType()).ToList();

            
            int toolbarIndex = elems.IndexOf(elems.FirstOrDefault(o => o.GetResourceId() == "com.viber.voip:id/toolbar"));
            string chatName = elems[toolbarIndex + 2].Text;
            string textUnderChatName = elems[toolbarIndex + 3].Text;


            if (textUnderChatName.Contains("participant"))
            {
                int participantsCount = 0;

                for(int i=0;i<textUnderChatName.Length; i++)
                {
                    if (!char.IsDigit(textUnderChatName[i]))
                    {
                        participantsCount = Convert.ToInt32(textUnderChatName.Substring(0, i + 1));
                    }
                }

                return new ExternalGroupChat
                {
                    Title = chatName,
                    ParticipantsCount = participantsCount
                };
            }

            return new ExternalPrivateChat
            {
                Title = chatName,
                OurUserId = this.Messenger.Account.Login,
                PeerId = id,
                OnlineStatusLabel = textUnderChatName,
            };
        }

        public override async Task<IEnumerable<Chat>> GetChats(int offset, int count)
        {
            await Messenger.ThrowIfNotAuthorized();

            throw new NotImplementedException();
        }
    }
}
