using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{
    public class ContentAccessModel : AbsModel
    {
        public ContentAccessModelType Type { get; set; }
        public int AccessLevel { get; set; }




        [NotMapped]
        public bool CanWatch => AccessLevel >= WatchLevel;
        [NotMapped]
        public bool CanEditCurrent => AccessLevel >= EditCurrentLevel;
        [NotMapped]
        public bool CanEditLocalizations => AccessLevel >= EditLocalizationsLevel;
        [NotMapped]
        public bool CanCreateNew => AccessLevel >= CreateNewLevel;
        [NotMapped]
        public bool CanDelete => AccessLevel >= DeleteLevel;


        public static int WatchLevel => 1;
        public static int EditCurrentLevel => 2;
        public static int EditLocalizationsLevel => 3;
        public static int CreateNewLevel => 4;
        public static int DeleteLevel => 5;
    }
}
