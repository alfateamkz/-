using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Abstractions.Services;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Alfateam.DB;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Services
{
    public class CommonDBService : AbsDBService
    {
        public CommonDBService(CRMDBContext db) : base(db)
        {
        }

   
    }
}
