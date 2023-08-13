using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{

    public class ReviewsAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }

        public bool CanWatch => AccessLevel >= WatchLevel;
        public bool CanHide => AccessLevel >= HideLevel;
        public bool CanDelete => AccessLevel >= DeleteLevel;


        public static int WatchLevel => 1;
        public static int HideLevel => 2;
        public static int DeleteLevel => 3;
    }
}
