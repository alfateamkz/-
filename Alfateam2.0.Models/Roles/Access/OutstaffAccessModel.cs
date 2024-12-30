using Alfateam.Core;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{
    public class OutstaffAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }


        [NotMapped]
        public bool CanWatch => AccessLevel >= 1;
        [NotMapped]
        public bool CanEditMainText => AccessLevel >= 2;
        [NotMapped]
        public bool CanEditLocalizations => AccessLevel >= 3;
        [NotMapped]
        public bool CanEditPrices => AccessLevel >= 4;
        [NotMapped]
        public bool CanAddNewItems => AccessLevel >= 5;
        [NotMapped]
        public bool CanRemoveItems => AccessLevel >= 6;

    }
}
