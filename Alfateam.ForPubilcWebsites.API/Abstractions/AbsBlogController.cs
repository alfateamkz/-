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



        public int? BlogId => AdmininstrationDb.Blogs.Include(o => o.Product)
                                                     .FirstOrDefault(o => o.Product.Identifier == ProductIdentifier)
                                                     ?.Id;
    }
}
