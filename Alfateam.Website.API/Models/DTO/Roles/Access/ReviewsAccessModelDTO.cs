using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Roles.Access;

namespace Alfateam.Website.API.Models.DTO.Roles.Access
{
    public class ReviewsAccessModelDTO : DTOModel<ReviewsAccessModel>
    {
        public int AccessLevel { get; set; }

        [ForClientOnly]
        public bool CanWatch => AccessLevel >= ReviewsAccessModel.WatchLevel;
        [ForClientOnly]
        public bool CanHide => AccessLevel >= ReviewsAccessModel.HideLevel;
        [ForClientOnly]
        public bool CanDelete => AccessLevel >= ReviewsAccessModel.DeleteLevel;
    }
}
