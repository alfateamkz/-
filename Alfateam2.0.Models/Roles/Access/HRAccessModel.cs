using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{
    public class HRAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }


        public bool CanWatchJobVacancies => AccessLevel >= 1;
        public bool CanWatchCVs => AccessLevel >= 2;
        public bool CanHandleCVs => AccessLevel >= 3;
        public bool CanEditItems => AccessLevel >= 4;
        public bool CanEditLocalizations => AccessLevel >= 5;
        public bool CanCreateItems => AccessLevel >= 6;
        public bool CanRemoveItems => AccessLevel >= 7;
    }
}
