using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.Models.Enums;

namespace Alfateam.EDM.API.Controllers
{
    
    public class CounterpartiesController : AbsAuthorizedController
    {
        public CounterpartiesController(ControllerParams @params) : base(@params)
        {
        }
    }
}
