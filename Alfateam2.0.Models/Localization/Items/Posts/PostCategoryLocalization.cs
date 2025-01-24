using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Posts
{
    public class PostCategoryLocalization : LocalizableModel
    {
        public string Title { get; set; }


        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{PostCategoryId}";



        /// <summary>
        /// Автоматическое поле.
        /// Указывает на объект, которому принадлежит данная локализация
        /// </summary>
        public int PostCategoryId { get; set; }
    }
}
