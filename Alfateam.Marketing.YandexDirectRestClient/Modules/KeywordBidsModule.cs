using Alfateam.Marketing.YandexDirectRestClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Modules
{
    public class KeywordBidsModule : AbsModule
    {
        public KeywordBidsModule(YandexDirectClient client) : base(client)
        {
        }
    }
}
