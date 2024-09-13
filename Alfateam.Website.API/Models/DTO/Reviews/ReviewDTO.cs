using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Reviews;

namespace Alfateam.Website.API.Models.DTO.Reviews
{
    public class ReviewDTO : DTOModel<Review>
    {
        [ForClientOnly]
        public DateTime PublishedAt { get; set; }

        public bool IsHidden { get; set; }


        /// <summary>
        /// Количество звезд от 0 до 5
        /// </summary>
        public int Rate { get; set; }

        

        /// <summary>
        /// Страна, из которой был оставлен отзыв
        /// </summary>
        public CountryDTO Country { get; set; }



        public UserDTO User { get; set; }



        public string Title { get; set; }
        public string Text { get; set; }

        public string? URLToProject { get; set; }
    }
}
