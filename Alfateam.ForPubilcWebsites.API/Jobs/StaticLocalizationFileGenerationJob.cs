using Alfateam.DB;

namespace Alfateam.ForPubilcWebsites.API.Jobs
{
    public static class StaticLocalizationFileGenerationJob
    {
        public static void Start()
        {
            Task.Run(async() =>
            {
                while(true)
                {
                    using (AdmininstrationDbContext db = new AdmininstrationDbContext())
                    {
                        foreach (var product in db.Products.Where(o => !o.IsDeleted))
                        {
                            foreach (var category in db.TextCategories.Where(o => o.ProductIdentifier == product.Identifier && o.ParentCategoryId == null))
                            {
                                //TODO: language entity????
                            }
                        }
                    }

                    await Task.Delay(TimeSpan.FromHours(1));
                }
            });
        }
    }
}
