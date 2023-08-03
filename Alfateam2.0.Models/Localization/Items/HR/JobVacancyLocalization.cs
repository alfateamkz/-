using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.HR
{
    public class JobVacancyLocalization : LocalizableModel
    {
        public string Title { get; set; }
        public Content InnerContent { get; set; }
    }
}
