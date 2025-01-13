using Alfateam.Marketing.YandexDirectRestClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Modules
{
    public class CampaignsModule : AbsModule
    {
        public CampaignsModule(YandexDirectClient client) : base(client)
        {
        }
    }
}
