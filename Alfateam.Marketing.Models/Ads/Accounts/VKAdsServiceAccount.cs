using Alfateam.Marketing.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Ads.Accounts
{
    public class VKAdsServiceAccount : AdsServiceAccount
    {
        public string Login { get; set; }
        public string Password { get; set; }




        public string AccessToken { get; set; }
    }
}
