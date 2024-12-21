using Alfateam.Marketing.YandexMetrikaRestClient.APIs;

namespace Alfateam.Marketing.YandexMetrikaRestClient
{
    public class YandexMetrikaClient
    {
        public YandexMetrikaClient()
        {
            DataImportAPI = new DataImportAPI(this);
            LogsAPI = new LogsAPI(this);
            ManagementAPI = new ManagementAPI(this);
            StatAPI = new StatAPI(this);
        }

        public DataImportAPI DataImportAPI { get; private set; }
        public LogsAPI LogsAPI { get; private set; }
        public ManagementAPI ManagementAPI { get; private set; }
        public StatAPI StatAPI { get; private set; }
    }
}
