using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Enums;

namespace Alfateam.CRM2_0.Controllers.Content
{
    [AccessActionFilter(roles: UserRole.ContentMaker)]
    public class ContentPostsController : AbsController
    {
        public ContentPostsController(ControllerParams @params) : base(@params)
        {
        }
    }
}
