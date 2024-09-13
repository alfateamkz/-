using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Reviews;

namespace Alfateam.Website.API.Models.CreateModels.Reviews
{
    public class ReviewCreateModel : CreateModel<Review>
    {

        /// <summary>
        /// Количество звезд от 0 до 5
        /// </summary>
        public int Rate { get; set; }


        public string Title { get; set; }
        public string Text { get; set; }

        public string? URLToProject { get; set; }

    }
}
