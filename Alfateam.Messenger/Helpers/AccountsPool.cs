using Alfateam.Messenger.Lib;
using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;

namespace Alfateam.Messenger.API.Helpers
{
    public static class AccountsPool
    {
        private static List<AbsMessenger> Messengers { get; set; } = new List<AbsMessenger>();


        public static List<AbsMessenger> GetAllMessengers()
        {
            return Messengers;
        }
        public static AbsMessenger? GetMessenger(Account account)
        {
            return Messengers.FirstOrDefault(o => o.Account.Id == account.Id);
        }



        public static bool TryAddAccount(Account account)
        {
            if(GetMessenger(account) != null)
            {
                switch (account)
                {
                    case TelegramAccount:
                        Messengers.Add(new TelegramMessenger(account as TelegramAccount));
                        break;
                    case WhatsAppAccount:
                        Messengers.Add(new WhatsAppMessenger(account as WhatsAppAccount));
                        break;
                    case ViberAccount:
                        Messengers.Add(new ViberMessenger(account as ViberAccount));
                        break;
                    case InstagramAccount:
                        Messengers.Add(new InstagramMessenger(account as InstagramAccount));
                        break;
                    case VKAccount:
                        Messengers.Add(new VkMessenger(account as VKAccount));
                        break;
                    case FacebookAccount:
                        Messengers.Add(new FacebookMessenger(account as FacebookAccount));
                        break;
                    case EmailAccount:
                        Messengers.Add(new EmailMessenger(account as EmailAccount));
                        break;
                    default:
                        throw new NotImplementedException("Еще данный тип аккаунта не реализован");
                }
                return true;
            }
            return false;
        }
        public static bool TryRemoveAccount(Account account)
        {
            var messenger = GetMessenger(account);
            if (messenger != null)
            {
                Messengers.Remove(messenger);
            }
            return false;
        }
    }
}
