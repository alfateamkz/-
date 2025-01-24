using Alfateam.DB;
using Alfateam.TicketSystem.Models;

namespace Alfateam.TicketSystem.API.Jobs
{
    public static class UnusedUploadedFilesJob
    {
        public static void Start()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    using(TicketSystemDbContext db = new TicketSystemDbContext())
                    {
                        var filesToDelete = new List<UploadedFile>();
                        foreach(var file in db.UploadedFiles.Where(o => o.RelatedEntityId == null && o.CreatedAt.AddHours(1) < DateTime.UtcNow))
                        {
                            filesToDelete.Add(file);
                            File.Delete(file.RelativePath);

                            //TODO: check UnusedUploadedFilesJob
                        }

                        if (filesToDelete.Any())
                        {
                            db.UploadedFiles.RemoveRange(filesToDelete);
                            db.SaveChanges();
                        }
                    }

                    await Task.Delay(TimeSpan.FromHours(1));
                }
            });
        }
    }
}
