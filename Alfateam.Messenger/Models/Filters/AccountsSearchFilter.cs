using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Enums;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;

namespace Alfateam.Messenger.API.Models.Filters
{
    public class AccountsSearchFilter : SearchFilter
    {
        public AccountSocialNetworkType SocialNetworkType { get; set; }

        public IEnumerable<Account> Filter(IEnumerable<Account> items, Func<Account, string> queryPredicate)
        {
            IEnumerable<Account> filtered = new List<Account>(items);

            switch (SocialNetworkType)
            {
                case AccountSocialNetworkType.Vk:
                    filtered = filtered.Where(o => o is VKAccount);
                    break;
                case AccountSocialNetworkType.Telegram:
                    filtered = filtered.Where(o => o is TelegramAccount);
                    break;
                case AccountSocialNetworkType.Viber:
                    filtered = filtered.Where(o => o is ViberAccount);
                    break;
                case AccountSocialNetworkType.Instagram:
                    filtered = filtered.Where(o => o is InstagramAccount);
                    break;
                case AccountSocialNetworkType.Facebook:
                    filtered = filtered.Where(o => o is FacebookAccount);
                    break;
                case AccountSocialNetworkType.WhatsApp:
                    filtered = filtered.Where(o => o is WhatsAppAccount);
                    break;
                case AccountSocialNetworkType.Email:
                    filtered = filtered.Where(o => o is EmailAccount);
                    break;
                case AccountSocialNetworkType.Alfateam:
                    filtered = filtered.Where(o => o is AlfateamMessengerAccount);
                    break;
            }


            return this.FilterBase(filtered, queryPredicate);
        }
    }
}
