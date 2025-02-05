using Alfateam.SharedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Services.Jobs
{
    public static class UnusedUploadedFilesJob
    {
        public static void Start<T>() where T: DbContext, new()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    using (T db = new T())
                    {
                        var filesToDelete = new List<UploadedFile>();
                        foreach (var file in GetUploadedFilesDbSet(db).Where(o => !o.IsUsed && o.CreatedAt.AddHours(1) < DateTime.UtcNow))
                        {
                            filesToDelete.Add(file);
                            File.Delete(file.RelativePath);

                            //TODO: check UnusedUploadedFilesJob
                        }

                        if (filesToDelete.Any())
                        {
                            GetUploadedFilesDbSet(db).RemoveRange(filesToDelete);
                            db.SaveChanges();
                        }
                    }

                    await Task.Delay(TimeSpan.FromHours(1));
                }
            });
        }



        #region Private methods

        private static DbSet<UploadedFile> GetUploadedFilesDbSet(DbContext db)
        {
            var prop = db.GetType().GetProperties().FirstOrDefault(o => o.Name == "UploadedFiles");
            return prop.GetValue(db) as DbSet<UploadedFile>;
        }

        #endregion
    }
}
