using Alfateam.Marketing.API.Models.Pools;
using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Messengers;
using Alfateam.Marketing.Autoposting.Lib.Models;
using Alfateam.Marketing.Autoposting.Lib.Resources;
using Alfateam.Marketing.Autoposting.Lib.Social;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Autoposting.Accounts.Messengers;
using Alfateam.Marketing.Models.Autoposting.Accounts.Resources;
using Alfateam.Marketing.Models.Autoposting.Accounts.Social;

namespace Alfateam.Marketing.API.Helpers.Pools
{
    public static class AutopostingAccountsPool
    {
        private static List<AutoposterAccountsPoolItem> Autoposters { get; set; } = new List<AutoposterAccountsPoolItem>();



        public static AutoposterAccountsPoolItem GetOrCreateItem(AutopostingAccount account)
        {
            var found = Autoposters.FirstOrDefault(o => o.Account.Id == account.Id);
            if (found == null)
            {
                found = new AutoposterAccountsPoolItem
                {
                    Account = account,
                    Autoposter = CreateAutoposter(account)
                };
                Autoposters.Add(found);
            }
            return found;
        }
        public static bool RemoveItem(int id)
        {
            var found = Autoposters.FirstOrDefault(o => o.Account.Id == id);
            if (found != null)
            {
                Autoposters.Remove(found);
                return true;
            }
            return false;
        }








        private static AbsAutoposter CreateAutoposter(AutopostingAccount account)
        {
            switch (account)
            {
                case TelegramAutopostingAccount:
                    return new TelegramAutoposter();
                case PikabuAutopostingAccount:
                    return new PikabuAutoposter();
                case VC_RUAutopostingAccount vcRuAccount:
                    return new VC_RUAutoposter(vcRuAccount.Email, vcRuAccount.Password);
                case YandexZenAutopostingAccount:
                    return new YandexZenAutoposter();
                case FacebookAutopostingAccount:
                    return new FacebookAutoposter();
                case InstagramAutopostingAccount:
                    return new InstagramAutoposter();
                case VKAutopostingAccount:
                    return new VKAutoposter();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
