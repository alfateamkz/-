using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.Integrations.API;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.EDM.API.Models.DTO.Integrations.API
{
    public class AlfateamAPIKeyDTO : DTOModelAbs<AlfateamAPIKey>
    {
        public string Title { get; set; }

        [ForClientOnly]
        public string Key { get; set; }
        public bool IsEnabled { get; set; }





        [ForClientOnly]
        [Description("Если IsDefault == true, то этот API ключ используется на сайте и по нему ограничен CORS\r\n" +
                     "Нельзя будет по этому ключу отправлять запросы с других клиентов")]
        public bool IsDefault { get; set; }

        [ForClientOnly]
        public DateTime? PaidBefore { get; set; }
    }
}
