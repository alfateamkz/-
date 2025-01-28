using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.APIs
{
    public class ManagementAPI : AbsAPI
    {
        public ManagementAPI(YandexMetrikaClient client) : base(client)
        {
            AccessFilters = new ManagementAccessFiltersModule(this.Client);
            Accounts = new ManagementAccountsModule(this.Client);
            ChartAnnotations = new ManagementChartAnnotationsModule(this.Client);
            Clients = new ManagementClientsModule(this.Client);
            Cloud = new ManagementCloudModule(this.Client);
            CounterLabels = new ManagementCounterLabelsModule(this.Client);
            Counters = new ManagementCountersModule(this.Client);   
            Delegates = new ManagementDelegatesModule(this.Client);
            Filters = new ManagementFiltersModule(this.Client);
            Goals = new ManagementGoalsModule(this.Client);
            Grants = new ManagementGrantsModule(this.Client);
            Labels = new ManagementLabelsModule(this.Client);
            Operations = new ManagementOperationsModule(this.Client);
            Segments = new ManagementSegmentsModule(this.Client);
        }

        public ManagementAccessFiltersModule AccessFilters { get; private set; }
        public ManagementAccountsModule Accounts { get; private set; }
        public ManagementChartAnnotationsModule ChartAnnotations { get; private set; }
        public ManagementClientsModule Clients { get; private set; }
        public ManagementCloudModule Cloud { get; private set; }
        public ManagementCounterLabelsModule CounterLabels { get; private set; }
        public ManagementCountersModule Counters { get; private set; }
        public ManagementDelegatesModule Delegates { get; private set; }
        public ManagementFiltersModule Filters { get; private set; }
        public ManagementGoalsModule Goals { get; private set; }
        public ManagementGrantsModule Grants { get; private set; }
        public ManagementLabelsModule Labels { get; private set; }
        public ManagementOperationsModule Operations { get; private set; }
        public ManagementSegmentsModule Segments { get; private set; }
    }
}
