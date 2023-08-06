using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{
    public class PostsAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }

        [NotMapped]
        public bool CanWatch => AccessLevel >= 1;
        [NotMapped]
        public bool CanEditCurrent => AccessLevel >= 2;
        [NotMapped]
        public bool CanEditLocalizations => AccessLevel >= 3;
        [NotMapped]
        public bool CanCreateNew => AccessLevel >= 4;
        [NotMapped]
        public bool CanDelete => AccessLevel >= 5;
    }
}
