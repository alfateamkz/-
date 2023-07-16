using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Localizations
{
    public class PortfolioLocalization : LocalizationModel
    {
        public string? Caption { get; set; }
        public string? Description { get; set; }
    }
}
