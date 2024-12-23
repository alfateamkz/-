using Alfateam.Marketing.YandexWebmasterRestClient.Modules;

namespace Alfateam.Marketing.YandexWebmasterRestClient
{
    public class YandexWebmasterClient
    {
        public YandexWebmasterClient()
        {
            ExternalLinks = new ExternalLinksModule(this);
            Feeds = new FeedsModule(this);
            HostSearchQueries = new HostSearchQueriesModule(this);
            Hosts = new HostsModule(this);
            Indexing = new IndexingModule(this);
            InSearch = new InSearchModule(this);
            InternalLinks = new InternalLinksModule(this);
            Recrawl = new RecrawlModule(this);
            Sitemaps = new SitemapsModule(this);
            SiteQuality = new SiteQualityModule(this);
            Verification = new VerificationModule(this);
        }


        public ExternalLinksModule ExternalLinks { get; private set; }
        public FeedsModule Feeds { get; private set; }
        public HostSearchQueriesModule HostSearchQueries { get; private set; }
        public HostsModule Hosts { get; private set; }
        public IndexingModule Indexing { get; private set; }
        public InSearchModule InSearch { get; private set; }
        public InternalLinksModule InternalLinks { get; private set; }
        public RecrawlModule Recrawl { get; private set; }
        public SitemapsModule Sitemaps { get; private set; }
        public SiteQualityModule SiteQuality { get; private set; }
        public VerificationModule Verification { get; private set; }
    }
}
