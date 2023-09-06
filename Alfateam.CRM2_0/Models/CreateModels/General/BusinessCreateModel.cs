using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.General;

namespace Alfateam.CRM2_0.Models.CreateModels.General
{
    public class BusinessCreateModel : CreateModel<Business>
    {
        public string Title { get; set; }
    }
}
