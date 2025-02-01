using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.Integrations.ExtMessenger;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Integrations.ExtMessenger
{
    public class ExtMessengerIntegrationDTO : DTOModelAbs<ExtMessengerIntegration>
    {
        public string Title { get; set; }
        public string UniqueIdentifier { get; set; }
        public bool IsEnabled { get; set; }

        [ForClientOnly]
        public string SecretToken { get; set; }

        [ForClientOnly]
        public DateTime? PaidBefore { get; set; }
    }
}
