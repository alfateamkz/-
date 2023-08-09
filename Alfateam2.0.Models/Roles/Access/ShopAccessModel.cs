using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles.Access
{
    public class ShopAccessModel : AbsModel
    {
        public int AccessLevel { get; set; }


        public bool CanWatchProducts => AccessLevel >= 1;
        public bool CanWatchOrders => AccessLevel >= 2;
        public bool CanApproveOrders => AccessLevel >= 3;
        public bool CanCancelOrders => AccessLevel >= 4;



        public bool CanEditProducts => AccessLevel >= 5;
        public bool CanEditProductLocalizations => AccessLevel >= 6;
        public bool CanEditProductPrices => AccessLevel >= 7;


        public bool CanCreate => AccessLevel >= 8;

        public bool CanDeleteProducts => AccessLevel >= 9;
    }
}
