using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Models;

namespace Alfateam.EDM.API.Controllers.Documents
{
    public class DocumentsController : AbsAuthorizedController
    {
        public DocumentsController(ControllerParams @params) : base(@params)
        {
        }
    }
}
