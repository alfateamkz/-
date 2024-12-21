using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport
{
    public class DataImportCallsModule : AbsModule
    {
        public DataImportCallsModule(YandexMetrikaClient client) : base(client)
        {
        }
    }
}
