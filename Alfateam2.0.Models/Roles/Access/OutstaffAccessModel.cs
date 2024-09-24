using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{
    public class OutstaffAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }


        public bool CanWatch => AccessLevel >= 1;
        public bool CanEditMainText => AccessLevel >= 2;
        public bool CanEditLocalizations => AccessLevel >= 3;
        public bool CanEditPrices => AccessLevel >= 4;
        public bool CanAddNewItems => AccessLevel >= 5;
        public bool CanRemoveItems => AccessLevel >= 6;

    }
}
