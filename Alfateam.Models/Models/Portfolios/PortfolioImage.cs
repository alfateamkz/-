using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Portfolios
{
    public class PortfolioImage : BaseModel {

        public string? ImgPath { get; set; }
    }
}
