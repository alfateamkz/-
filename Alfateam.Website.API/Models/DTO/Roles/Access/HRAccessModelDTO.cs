using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Roles.Access;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.DTO.Roles.Access
{
    public class HRAccessModelDTO : DTOModel<HRAccessModel>
    {
        public int AccessLevel { get; set; }

        [ForClientOnly]
        public bool CanWatchJobVacancies => AccessLevel >= 1;
        [ForClientOnly]
        public bool CanWatchCVs => AccessLevel >= 2;
        [ForClientOnly]
        public bool CanHandleCVs => AccessLevel >= 3;
        [ForClientOnly]
        public bool CanEditItems => AccessLevel >= 4;
        [ForClientOnly]
        public bool CanEditLocalizations => AccessLevel >= 5;
        [ForClientOnly]
        public bool CanCreateItems => AccessLevel >= 6;
        [ForClientOnly]
        public bool CanRemoveItems => AccessLevel >= 7;
    }
}
