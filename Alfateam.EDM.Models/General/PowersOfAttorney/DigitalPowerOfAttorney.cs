using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General.PowersOfAttorney
{
    public class DigitalPowerOfAttorney : PowerOfAttorney
    {
        public string IssuerInfo { get; set; }

        /// <summary>
        /// Содержимое файла МЧД
        /// </summary>
        public string FileContent { get; set; }
    }
}
