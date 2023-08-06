using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Reviews
{
    /// <summary>
    /// Сущность отзыва на сайте
    /// </summary>
    public class Review : AbsModel
    {
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Количество звезд от 0 до 5
        /// </summary>
        public int Rate { get; set; }


        /// <summary>
        /// Страна, из которой был оставлен отзыв
        /// </summary>
        public Country Country { get; set; }
        public int CountryId { get; set; }



        public User User { get; set; }
        public int UserId { get; set; }



        public string Title { get; set; }
        public string Text { get; set; }

        public string? URLToProject { get; set; }



    }
}
