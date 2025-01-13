using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Abstractions
{
    public abstract class AbsModule
    {
        protected readonly YandexDirectClient Client;
        public AbsModule(YandexDirectClient client)
        {
            Client = client;
        }
    }
}
