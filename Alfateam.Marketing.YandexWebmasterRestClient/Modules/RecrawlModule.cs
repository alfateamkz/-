using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class RecrawlModule : AbsModule
    {
        public RecrawlModule(YandexWebmasterClient client) : base(client)
        {
        }
    }
}
