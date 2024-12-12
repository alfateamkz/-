
using Alfateam.DB;
using Alfateam.Marketing.Models.Websites.Stats;
using System.Net.NetworkInformation;

namespace Alfateam.Marketing.API.HostedServices
{
    public class WebsiteOnlinePingHostedService : IHostedService
    {
        public readonly MarketingDbContext DB;
        public WebsiteOnlinePingHostedService(MarketingDbContext db)
        {
            DB = db;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            DoWork(cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {


            return Task.CompletedTask;
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                foreach(var website in DB.Websites.Where(o => !o.IsDeleted))
                {
                    website.OnlineInfo.Add(PingHost(website.URL));
                    DB.Websites.Update(website);
                }
                DB.SaveChanges();

                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }


        private WebsiteOnlineInfo PingHost(string nameOrAddress)
        {
            using (Ping pinger = new Ping())
            {
                PingReply reply = pinger.Send(nameOrAddress);

                return new WebsiteOnlineInfo
                {
                    IsOnline = reply.Status == IPStatus.Success,
                    ResponseDuration = TimeSpan.FromMilliseconds(reply.RoundtripTime)
                };
            }
        }
    }
}
