using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Gamification;

namespace Alfateam.CRM2_0.Abstractions
{
    public abstract class AbsGamificationController : AbsController
    {
        public AbsGamificationController(ControllerParams @params) : base(@params)
        {
        }

        protected int? GetGamificationId()
        {
            return DB.GamificationModels.FirstOrDefault(o => o.OrganizationId == this.OrganizationId)?.Id;
        }
    }
}
