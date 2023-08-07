using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items
{
    public class MassMediaPostLocalization : LocalizableModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }



        /// <summary>
        /// Автоматическое поле, указывает на главную запись
        /// </summary>
        public int MassMediaPostId { get; set; }
    }
}
