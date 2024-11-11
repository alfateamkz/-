using Alfateam.Core;
using Alfateam2._0.Models.Localization.Items.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.HR
{
    public class JobVacancyCategory : AbsModel
    {
        public string Title { get; set; }
        public List<JobVacancyCategoryLocalization> Localizations { get; set; } = new List<JobVacancyCategoryLocalization>();
    }
}
