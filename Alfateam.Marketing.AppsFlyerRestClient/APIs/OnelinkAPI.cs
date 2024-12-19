using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Onelink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class OnelinkAPI : AbsAPI
    {
        public OnelinkAPI(AppsFlyerClient client) : base(client)
        {
            DeepLinkingAPI = new DeepLinkingAPI(this.Client);
            OnelinkModuleAPI = new OnelinkModuleAPI(this.Client);
        }

        public DeepLinkingAPI DeepLinkingAPI { get; private set; }
        public OnelinkModuleAPI OnelinkModuleAPI { get; private set; }
    }
}
