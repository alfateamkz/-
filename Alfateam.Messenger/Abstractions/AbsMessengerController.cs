using Alfateam.Core.Exceptions;
using Alfateam.Messenger.API.Helpers;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.Peers;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Alfateam.Messenger.API.Abstractions
{
    public abstract class AbsMessengerController : AbsController
    {
        public AbsMessengerController(ControllerParams @params) : base(@params)
        {
        }


        public int? AccountId => ParseIntValueFromHeader("AccountId");
        public Account? Account => DB.Accounts.FirstOrDefault(o => o.Id == AccountId && !o.IsDeleted && o.CompanyWorkSpaceId == this.WorkspaceID);
        public AbsMessenger? Messenger => AccountsPool.GetOrCreateMessenger(Account);




        protected void ThrowIfNull(object val, string message = "Сущность с данным id не найдена")
        {
            if(val == null)
            {
                throw new Exception404(message);
            }
        }

        protected IEnumerable<ChatBase> GetAvailableAlfateamChats()
        {
            var authorizedUserId = this.AuthorizedUser.Id;
            var myPeers = DB.Peers.Cast<AlfateamMessengerPeer>().Where(o => o.Id == authorizedUserId);

            List<ChatBase> chats = new List<ChatBase>();
            AddPrivateChats(chats, myPeers);
            AddGroupChats(chats, myPeers);

            return chats;
        }

        protected void ThrowIfAlfateamChatNotExistOrAvailable(int chatId)
        {
            DBService.TryGetOne(GetAvailableAlfateamChats(), chatId);
        }



        #region Private get alfateam messenger get chats methods

        private void AddPrivateChats(List<ChatBase> chats, IQueryable<AlfateamMessengerPeer> myPeers)
        {

            var privateChatIds = myPeers.Where(o => o.PrivateChatId != null)
                                        .Select(o => o.PrivateChatId)
                                        .Distinct();
            foreach (var chatId in privateChatIds)
            {
                var chat = DB.Chats.Cast<PrivateChat>()
                                   .Include(o => o.Receiver)
                                   .Include(o => o.CreatedBy)
                                   .FirstOrDefault(o => o.Id == chatId);
                chats.Add(chat);
            }
        }
        private void AddGroupChats(List<ChatBase> chats, IQueryable<AlfateamMessengerPeer> myPeers)
        {
            var groupChatMemberIds = myPeers.Where(o => o.AlfateamGroupChatMemberId != null)
                                            .Select(o => o.AlfateamGroupChatMemberId)
                                            .Distinct();
            foreach (int memberId in groupChatMemberIds)
            {
                int groupChatId = DB.GroupChatMembers.FirstOrDefault(o => o.Id == memberId).GroupChatId;
                var chat = DB.Chats.Cast<GroupChat>().FirstOrDefault(o => o.Id == groupChatId);
                chats.Add(chat);
            }
        }

        #endregion
    }
}
