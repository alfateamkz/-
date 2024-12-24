using Alfateam.Marketing.YandexWebmasterRestClient.Enums.InSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsSearchEventsHistory
{
    public class HostsSearchEventsHistoryResponse
    {
        public Dictionary<ApiSearchEventEnum, HostsSearchEventsHistoryIndicatorValue> Indicators { get; set; } = new Dictionary<ApiSearchEventEnum, HostsSearchEventsHistoryIndicatorValue>();
    }
}
