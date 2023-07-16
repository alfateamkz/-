using Alfateam.Database.Enums.CRM;
using Alfateam.Database.Models.CRM;

namespace Alfateam.CRM.ViewModels.Resources {
    public class ResourcesPageVM {

        public List<Resource> Resources { get; set; } = new List<Resource>();
        public IEnumerable<Resource> OurResources => Resources.Where(o => o.ResourceOwnership == ResourceOwnership.Alfateam);
        public IEnumerable<Resource> OtherResources => Resources.Where(o => o.ResourceOwnership != ResourceOwnership.Alfateam);
    }
}
