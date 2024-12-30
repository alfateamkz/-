using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{

    public class ReviewsAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }

        [NotMapped]
        public bool CanWatch => AccessLevel >= WatchLevel;
        [NotMapped]
        public bool CanHide => AccessLevel >= HideLevel;
        [NotMapped]
        public bool CanDelete => AccessLevel >= DeleteLevel;


        public static int WatchLevel => 1;
        public static int HideLevel => 2;
        public static int DeleteLevel => 3;
    }
}
