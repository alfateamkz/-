using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.SharedModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Services
{
    public class UploadedFilesService
    {
        public readonly DbContext DB;
        public readonly AbsDBService DBService;
        public UploadedFilesService(DbContext db, AbsDBService dbService)
        {
            DB = db;
            DBService = dbService;

            DBService.SetDB(db);
        }


        public bool AreAllFilesAvailable(IEnumerable<string> fileIds)
        {
            return fileIds.All(o => IsFileAvailable(o));
        }
        public bool IsFileAvailable(string fileId)
        {
            var file = DBService.TryGetOne(GetUploadedFilesDbSet(), fileId);
            return !file.IsUsed;
        }





        public void ThrowIfAnyFileNotAvailable(IEnumerable<string> fileIds)
        {
            if (!AreAllFilesAvailable(fileIds))
            {
                throw new Exception400("Файл(ы) уже используется(ются) в другой сущности");
            }
        }
        public void ThrowIfFileNotAvailable(string fileId)
        {
            if (!IsFileAvailable(fileId))
            {
                throw new Exception400("Файл уже используется в другой сущности");
            }
        }





        public void ThrowIfNewFileNotAvailable(string oldFileName, string newFileName)
        {
            if(oldFileName != newFileName)
            {
                ThrowIfFileNotAvailable(newFileName);
            }
        }



        public void TryBindFileWithEntityIfChanged(string oldFileName, string newFileName)
        {
            if (oldFileName != newFileName)
            {
                TryBindFileWithEntity(newFileName);
                TryUnbindFile(oldFileName);
            }
        }

        public void TryBindFileWithEntity(string fileId)
        {
            var file = DBService.TryGetOne(GetUploadedFilesDbSet(), fileId);
            if (file.IsUsed)
            {
                throw new Exception403("Файл уже используется в другой сущности");
            }
            file.IsUsed = true;
            DBService.UpdateEntity(GetUploadedFilesDbSet(), file);
        }




        public void TryUnbindFile(string fileId)
        {
            var file = DBService.TryGetOne(GetUploadedFilesDbSet(), fileId);
            file.IsUsed = false;
            DBService.UpdateEntity(GetUploadedFilesDbSet(), file);
        }
        public void TryUnbindFile(UploadedFile file)
        {
            file.IsUsed = false;
            DBService.UpdateEntity(GetUploadedFilesDbSet(), file);
        }






        #region Private methods

        private DbSet<UploadedFile> GetUploadedFilesDbSet()
        {
            var prop = DB.GetType().GetProperties().FirstOrDefault(o => o.Name == "UploadedFiles");
            return prop.GetValue(DB) as DbSet<UploadedFile>;
        }

        #endregion
    }
}
