using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport;
using Alfateam.Marketing.YandexMetrikaRestClient.Modules.Stat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.APIs
{
    public class DataImportAPI : AbsAPI
    {
        public DataImportAPI(YandexMetrikaClient client) : base(client)
        {
            Calls = new DataImportCallsModule(this.Client);
            Conversions = new DataImportConversionsModule(this.Client);
            Expenses = new DataImportExpensesModule(this.Client);
            ImportFromCRM = new DataImportImportFromCRMModule(this.Client);
            MeasurementProtocol = new DataImportMeasurementProtocolModule(this.Client);
            UserParams = new DataImportUserParamsModule(this.Client);
        }

        public DataImportCallsModule Calls { get; private set; }
        public DataImportConversionsModule Conversions { get; private set; }
        public DataImportExpensesModule Expenses { get; private set; }
        public DataImportImportFromCRMModule ImportFromCRM { get; private set; }
        public DataImportMeasurementProtocolModule MeasurementProtocol { get; private set; }
        public DataImportUserParamsModule UserParams { get; private set; }
    }
}
