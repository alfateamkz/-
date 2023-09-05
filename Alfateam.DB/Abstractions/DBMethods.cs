using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB.Abstractions
{
    public abstract class DBMethods
    {
        protected readonly CRMDBContext DB;
        public DBMethods(CRMDBContext db)
        {
            DB = db;
        }
    }
}
