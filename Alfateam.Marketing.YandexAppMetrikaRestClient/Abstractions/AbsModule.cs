using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions
{
    public abstract class AbsModule
    {
        protected readonly YandexAppMetrikaClient Client;
        public AbsModule(YandexAppMetrikaClient client)
        {
            Client = client;
        }
    }
}
