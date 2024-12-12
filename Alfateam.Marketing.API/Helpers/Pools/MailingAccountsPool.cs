using Alfateam.Marketing.API.Models.Pools;
using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Autoposting.Lib.Messengers;
using Alfateam.Marketing.Autoposting.Lib.Resources;
using Alfateam.Marketing.Autoposting.Lib.Social;
using Alfateam.Marketing.Lettering.Lib.Abstractions;
using Alfateam.Marketing.Lettering.Lib.Mailers;
using Alfateam.Marketing.Lettering.Lib.Mailers.Messengers;
using Alfateam.Marketing.Lettering.Lib.Mailers.Social;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Abstractions.MailingAccounts;
using Alfateam.Marketing.Models.Autoposting.Accounts.Messengers;
using Alfateam.Marketing.Models.Autoposting.Accounts.Resources;
using Alfateam.Marketing.Models.Autoposting.Accounts.Social;
using Alfateam.Marketing.Models.MailingAccounts;
using Alfateam.Marketing.Models.MailingAccounts.Messengers;
using Alfateam.Marketing.Models.MailingAccounts.Social;

namespace Alfateam.Marketing.API.Helpers.Pools
{
    public static class MailingAccountsPool
    {
        private static List<MailingAccountsPoolItem> Mailers { get; set; } = new List<MailingAccountsPoolItem>();


        public static MailingAccountsPoolItem GetOrCreateItem(MailingAccount account)
        {
            var found = Mailers.FirstOrDefault(o => o.Account.Id == account.Id);
            if (found == null)
            {
                found = new MailingAccountsPoolItem
                {
                    Account = account,
                    Mailer = CreateMailer(account)
                };
                Mailers.Add(found);
            }
            return found;
        }
        public static bool RemoveItem(int id)
        {
            var found = Mailers.FirstOrDefault(o => o.Account.Id == id);
            if (found != null)
            {
                Mailers.Remove(found);
                return true;
            }
            return false;
        }





        private static AbsMailer CreateMailer(MailingAccount account)
        {
            switch (account)
            {
                case TelegramMailingAccount:
                    return new TelegramMailer();
                case ViberMailingAccount:
                    return new ViberMailer();
                case WhatsAppMailingAccount:
                    return new WhatsAppMailer();
                case FacebookMailingAccount:
                    return new FacebookMailer();
                case InstagramMailingAccount:
                    return new InstagramMailer();
                case VKMailingAccount:
                    return new VKMailer();
                case EmailMailingAccount:
                    return new EmailMailer();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
