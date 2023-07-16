using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class Language : BaseModel {
        public string Title { get; set; }
        public string Code { get; set; }
        public string? IconPath { get; set; }

        public bool IsShown { get; set; } = true;

        public override string ToString()
        {
            return Title;
        }
    }
}
