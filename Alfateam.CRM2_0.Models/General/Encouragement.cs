using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Сущность поощрения за что-либо
    /// </summary>
    public class Encouragement : AbsModel
    {
        public DateTime Date { get; set; }
        public User CreatedBy { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }


        public Currency Currency { get; set; }
        public double Sum { get; set; }
        
    }
}
