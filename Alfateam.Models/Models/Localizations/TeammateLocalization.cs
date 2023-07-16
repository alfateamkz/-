using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Localizations
{
    public class TeammateLocalization : LocalizationModel
    {
        public string? Title { get; set; }
        public string? MiddleDescription { get; set; }
        public string? Position { get; set; }
    }
}
