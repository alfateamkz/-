using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Roles.Access;

namespace Alfateam.Website.API.Models.DTO.Roles.Access
{
    public class OutstaffAccessModelDTO : DTOModel<OutstaffAccessModel>
    {
        public int AccessLevel { get; set; }

        [ForClientOnly]
        public bool CanWatch => AccessLevel >= 1;
        [ForClientOnly]
        public bool CanEditMainText => AccessLevel >= 2;
        [ForClientOnly]
        public bool CanEditLocalizations => AccessLevel >= 3;
        [ForClientOnly]
        public bool CanEditPrices => AccessLevel >= 4;
        [ForClientOnly]
        public bool CanAddNewItems => AccessLevel >= 5;
        [ForClientOnly]
        public bool CanRemoveItems => AccessLevel >= 6;
    }
}
