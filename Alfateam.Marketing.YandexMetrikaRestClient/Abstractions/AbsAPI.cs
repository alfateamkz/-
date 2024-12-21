using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Abstractions
{
    public abstract class AbsAPI
    {
        protected readonly YandexMetrikaClient Client;
        public AbsAPI(YandexMetrikaClient client)
        {
            Client = client;
        }
    }
}
