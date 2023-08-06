using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Posts
{
    public class PostCategoryLocalization : LocalizableModel
    {
        public string Title { get; set; }


        /// <summary>
        /// Автоматическое поле.
        /// Указывает на объект, которому принадлежит данная локализация
        /// </summary>
        public int PostCategoryId { get; set; }
    }
}
