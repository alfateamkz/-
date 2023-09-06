using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.EditModels.General
{
    public class BusinessEditModel : EditModel<Business>
    {
        public string Title { get; set; }
    }
}
