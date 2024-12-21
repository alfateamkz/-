using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementClientsModule : AbsModule
    {
        public ManagementClientsModule(YandexMetrikaClient client) : base(client)
        {
        }
    }
}
