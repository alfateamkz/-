using Alfateam.Administration.Models.Enums;
using Alfateam.ForPubilcWebsites.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.ForPubilcWebsites.API.Abstractions
{
    public abstract class AbsBlogController : AbsController
    {
        public AbsBlogController(ControllerParams @params) : base(@params)
        {
        }



        public string? ProductIdentifier => Request.Headers["ProductIdentifier"];
        public BlogType? BlogType => (BlogType)Convert.ToInt32(Request.Headers["BlogType"]);
        public int? LanguageId => ParseIntValueFromHeader("LanguageId");








        public int? BlogId => AdmininstrationDb.Blogs.Include(o => o.Product)
                                                     .FirstOrDefault(o => o.Product.Identifier == ProductIdentifier)
                                                     ?.Id;
        public int? BlogLanguageZoneId => AdmininstrationDb.BlogLanguageZones.FirstOrDefault(o => o.LanguageId == LanguageId && o.BlogId == BlogId)?.Id;






        protected int? ParseIntValueFromHeader(string key)
        {
            int? id = null;

            if (Request.Headers.ContainsKey(key))
            {
                var str = Request.Headers[key].ToString();
                if (str != null)
                {
                    int val = 0;
                    int.TryParse(str, out val);

                    if (val != 0)
                    {
                        id = val;
                    }
                }
            }

            return id;
        }
    }
}
