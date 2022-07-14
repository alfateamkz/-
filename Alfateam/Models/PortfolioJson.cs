using Alfateam.Database.Models.Portfolios;
using System.ComponentModel.DataAnnotations;

namespace Alfateam.Models
{
    public class PortfolioJson
    {
        [Key]
        public int Id { get; set; }

        public List<PortfolioImage> Images { get; set; } = new List<PortfolioImage>();
        public DateTime CreatedAt { get; set; }


        public string Caption { get; set; }
        public string Description { get; set; }
    }
}
