
using Alfateam.DB;

namespace Alfateam.Marketing.API.HostedServices
{
    public class AutopostingHostedService : IHostedService
    {
        public readonly MarketingDbContext DB;
        public AutopostingHostedService(MarketingDbContext db)
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
                //Публикация постов
                foreach (var post in DB.Posts.Where(o => !o.IsDeleted && o.PublishedAt == null && o.PublishAt < DateTime.UtcNow))
                {
                    //TODO: send post
                    post.PublishedAt = DateTime.UtcNow;
                    DB.Posts.Update(post);
                }

                //Удаление постов
                foreach (var post in DB.Posts.Where(o => !o.IsDeleted && o.PublishedAt != null && o.DeleteIn != null && o.DeletedPostAtSourceAt == null))
                {
                    //TODO: delete post
                    post.DeletedPostAtSourceAt = DateTime.UtcNow;
                    DB.Posts.Update(post);
                }

                await DB.SaveChangesAsync();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
