using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{
    public class HRAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }

        [NotMapped]
        public bool CanWatchJobVacancies => AccessLevel >= 1;
        [NotMapped]
        public bool CanWatchCVs => AccessLevel >= 2;
        [NotMapped]
        public bool CanHandleCVs => AccessLevel >= 3;
        [NotMapped]
        public bool CanEditItems => AccessLevel >= 4;
        [NotMapped]
        public bool CanEditLocalizations => AccessLevel >= 5;
        [NotMapped]
        public bool CanCreateItems => AccessLevel >= 6;
        [NotMapped]
        public bool CanRemoveItems => AccessLevel >= 7;
    }
}
