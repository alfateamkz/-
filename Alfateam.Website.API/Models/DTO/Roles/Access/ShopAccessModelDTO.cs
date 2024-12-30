using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Roles.Access;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.DTO.Roles.Access
{
    public class ShopAccessModelDTO : DTOModel<ShopAccessModel>
    {
        public int AccessLevel { get; set; }


        [ForClientOnly]
        public bool CanWatchProducts => AccessLevel >= 1;
        [ForClientOnly]
        public bool CanWatchOrders => AccessLevel >= 2;
        [ForClientOnly]
        public bool CanApproveOrders => AccessLevel >= 3;
        [ForClientOnly]
        public bool CanCancelOrders => AccessLevel >= 4;



        [ForClientOnly]
        public bool CanEditProducts => AccessLevel >= 5;
        [ForClientOnly]
        public bool CanEditProductLocalizations => AccessLevel >= 6;
        [ForClientOnly]
        public bool CanEditProductPrices => AccessLevel >= 7;


        [ForClientOnly]
        public bool CanCreate => AccessLevel >= 8;

        [ForClientOnly]
        public bool CanDeleteProducts => AccessLevel >= 9;
    }
}
