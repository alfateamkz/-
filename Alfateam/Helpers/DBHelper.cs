using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Database.Models.General;
using Alfateam.Database.Models.SitePagesTexts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Alfateam.Helpers
{
    public class DBHelper
    {
        public static HttpContext Context { get; set; }

        public static GeneralTexts GetGeneralTexts()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.GeneralTexts
                    .Include(o => o.Main).ThenInclude(o => o.Language)
                    .Include(o => o.ServicesPrice).ThenInclude(o => o.Language)
                    .Include(o => o.OurWorks).ThenInclude(o => o.Language)
                    .Include(o => o.Partners).ThenInclude(o => o.Language)
                    .Include(o => o.Team).ThenInclude(o => o.Language)
                    .Include(o => o.News).ThenInclude(o => o.Language)

                    .Include(o => o.Navigation).ThenInclude(o => o.Language)
                    .Include(o => o.Contacts).ThenInclude(o => o.Language)

                    .Include(o => o.SocialNetworks).ThenInclude(o => o.Language)
                    .Include(o => o.AllRightsReserved).ThenInclude(o => o.Language)

                    .Include(o => o.PublishedAt).ThenInclude(o => o.Language)
                    .Include(o => o.AllPortfolios).ThenInclude(o => o.Language)
                    .Include(o => o.Watches).ThenInclude(o => o.Language)
                    .Include(o => o.AddedAt).ThenInclude(o => o.Language)
                    .Include(o => o.Categories).ThenInclude(o => o.Language)
                    .Include(o => o.Close).ThenInclude(o => o.Language)
                    .Include(o => o.NewPortfolioLabel).ThenInclude(o => o.Language)
                    .AsSplitQuery()
                    .FirstOrDefault();
            }
        }
        public static LandingTexts GetLangingTexts()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.LandingTexts
                         .Include(o => o.StartBusiness).ThenInclude(o => o.Language)
                         .Include(o => o.StartBusinessDescriptions).ThenInclude(o => o.Language)
                         .Include(o => o.OrderNow).ThenInclude(o => o.Language)

                         .Include(o => o.WeAcceptPayments).ThenInclude(o => o.Language)

                         .Include(o => o.OurPortfolios).ThenInclude(o => o.Language)
                         .Include(o => o.OurLastPortfolios).ThenInclude(o => o.Language)
                         .Include(o => o.MorePortfolios).ThenInclude(o => o.Language)

                         .Include(o => o.News).ThenInclude(o => o.Language)
                         .Include(o => o.DiscoverNews).ThenInclude(o => o.Language)
                         .Include(o => o.NewsDetails).ThenInclude(o => o.Language)
                         .Include(o => o.NewsMore).ThenInclude(o => o.Language)

                         .Include(o => o.Order).ThenInclude(o => o.Language)
                         .Include(o => o.MakeOrder).ThenInclude(o => o.Language)
                         .Include(o => o.YourName).ThenInclude(o => o.Language)
                         .Include(o => o.CompanyName).ThenInclude(o => o.Language)
                         .Include(o => o.DescribeJob).ThenInclude(o => o.Language)
                         .Include(o => o.DescribeJobPlaceholder).ThenInclude(o => o.Language)
                         .Include(o => o.YourBudget).ThenInclude(o => o.Language)
                         .Include(o => o.Contacts).ThenInclude(o => o.Language)
                         .Include(o => o.ContactsPlaceholder).ThenInclude(o => o.Language)
                         .Include(o => o.Send).ThenInclude(o => o.Language)

                         .Include(o => o.OrderCompleted).ThenInclude(o => o.Language)
                         .AsSplitQuery()
                         .FirstOrDefault();
            }
        }

        public static List<Language> GetLanguages()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                 return db.Languages.Where(o => o.IsShown).ToList();
            }
        }
        public static Language GetCurrentLanguage(ClaimsPrincipal user)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Language lang = null;
                try
                {
                    if (Context.Request.Cookies.ContainsKey("Language"))
                    {
                        int id = Convert.ToInt32(Context.Request.Cookies["Language"]);
                        lang = db.Languages.FirstOrDefault(o => o.Id == id);
                    }
                    else
                    {
                        lang = db.Languages.FirstOrDefault(o => o.Code == "RU");
                    }
                }
                catch { }

                return lang;
            }
        }

        public static UserModel GetUser(ClaimsPrincipal principal)
        {
            int id = Convert.ToInt32(principal.Identity.Name);
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Users.FirstOrDefault(o => o.Id == id);
            }
        }
    }
}
