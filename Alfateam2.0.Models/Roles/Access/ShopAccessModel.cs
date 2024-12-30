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
    public class ShopAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }


        [NotMapped]
        public bool CanWatchProducts => AccessLevel >= 1;
        [NotMapped]
        public bool CanWatchOrders => AccessLevel >= 2;
        [NotMapped]
        public bool CanApproveOrders => AccessLevel >= 3;
        [NotMapped]
        public bool CanCancelOrders => AccessLevel >= 4;



        [NotMapped]
        public bool CanEditProducts => AccessLevel >= 5;
        [NotMapped]
        public bool CanEditProductLocalizations => AccessLevel >= 6;
        [NotMapped]
        public bool CanEditProductPrices => AccessLevel >= 7;


        [NotMapped]
        public bool CanCreate => AccessLevel >= 8;

        [NotMapped]
        public bool CanDeleteProducts => AccessLevel >= 9;
    }
}
