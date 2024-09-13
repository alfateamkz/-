using Alfateam.CRM2_0.Abstractions.Services;
using Alfateam.DB;

namespace Alfateam.CRM2_0.Core
{
    public class ControllerParams
    {

        public ControllerParams(CRMDBContext db, IWebHostEnvironment appEnv, AbsUploadFileService fileService, AbsDBService dBService)
        {
            DB = db;
            AppEnvironment = appEnv;
            FileService = fileService;
            DBService = dBService;
        }


        public readonly AbsDBService DBService;
        public readonly CRMDBContext DB;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly AbsUploadFileService FileService;
    }
}
