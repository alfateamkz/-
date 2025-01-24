using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Team
{
    public class TeamMemberLocalization : LocalizableModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [NotMapped]
        public string ShownTitle => $"{Surname}-{Name} ({Position})";

        public string Position { get; set; }
        public string ShortExpierence { get; set; }
        public string Quote { get; set; }


        public Content DetailContent { get; set; }
        public string? CVFilepath { get; set; }




        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug($"{Surname}-{Name}-{Position}")}-{TeamMemberId}";


        /// <summary>
        /// Автоматическое поле
        /// Указывает на члена команды
        /// </summary>
        public int TeamMemberId { get; set; }
    }
}
