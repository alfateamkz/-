using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.ClientModels.General
{
    public class BusinessClientModel : ClientModel<Business>
    {
        public string Title { get; set; }
        public string? LogoPath { get; set; }


        public List<User> Owners { get; set; } = new List<User>();
        public List<User> TopManagers { get; set; } = new List<User>();


        public BusinessType Type { get; set; } = BusinessType.Our;
        public List<OrganizationClientModel> Organizations { get; set; } = new List<OrganizationClientModel>();

    }
}
