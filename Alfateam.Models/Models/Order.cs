using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public string Description { get; set; }
        public string Contacts { get; set; }
        public string Budget { get; set; }
    }
}
