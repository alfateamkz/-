using Alfateam.Administration.Models.Enums;
using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.General
{
    public class Product : AbsModel
    {
        public string Title { get; set; }
        public ProductType Type { get; set; }
        public string Identifier { get; set; }



        public string? ImagePath { get; set; }
        public string Description { get; set; }
    }
}
