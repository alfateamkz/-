using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.HR
{
    public class JobVacancyCategoryLocalization : LocalizableModel
    {
        public string Title { get; set; }

        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{JobVacancyCategoryId}";

        public int JobVacancyCategoryId { get; set; }
    }
}
