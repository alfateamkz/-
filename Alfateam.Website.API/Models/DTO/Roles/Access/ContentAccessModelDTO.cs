using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Roles.Access;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.DTO.Roles.Access
{
    public class ContentAccessModelDTO : DTOModel<ContentAccessModel>
    {
        public ContentAccessModelType Type { get; set; }
        public int AccessLevel { get; set; }




        [ForClientOnly]
        public bool CanWatch => AccessLevel >= ContentAccessModel.WatchLevel;
        [ForClientOnly]
        public bool CanEditCurrent => AccessLevel >= ContentAccessModel.EditCurrentLevel;
        [ForClientOnly]
        public bool CanEditLocalizations => AccessLevel >= ContentAccessModel.EditLocalizationsLevel;
        [ForClientOnly]
        public bool CanCreateNew => AccessLevel >= ContentAccessModel.CreateNewLevel;
        [ForClientOnly]
        public bool CanDelete => AccessLevel >= ContentAccessModel.DeleteLevel;
    }
}
