using Alfateam.Database.Abstraction;
using Alfateam.Database.Models.SitePagesTexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class SiteFrontend : BaseModel {


        public ErrorPages ErrorPages { get; set; } = new ErrorPages();
        public GeneralTexts GeneralTexts { get; set; } = new GeneralTexts();
        public LandingTexts LandingTexts { get; set; } = new LandingTexts();
    }
}
