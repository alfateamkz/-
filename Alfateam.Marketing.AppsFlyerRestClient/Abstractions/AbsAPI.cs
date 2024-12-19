using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Abstractions
{
    public abstract class AbsAPI
    {
        protected readonly AppsFlyerClient Client;
        public AbsAPI(AppsFlyerClient client)
        {
            Client = client;
        }
    }
}
