using Alfateam.Sales.API.Enums.Analytics;

namespace Alfateam.Sales.API.Models.Analytics.Clients.BaseAndChannels
{
    public class ClientsBaseAndChannelsStats
    {
        public ClientsBaseAndChannelsClientType ClientType { get; set; } 
        public List<ClientsBaseChartPoint> ClientsBaseChart { get; set; } = new List<ClientsBaseChartPoint>();
        public List<ClientsChannelItem> Channels { get; set; } = new List<ClientsChannelItem>();

    }
}
