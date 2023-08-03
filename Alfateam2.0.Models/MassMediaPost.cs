using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models
{
    /// <summary>
    /// Сущность поста в разделе "Мы в СМИ"
    /// </summary>
    public class MassMediaPost : AbsModel
    {
        public string ImgPath { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public string URL { get; set; }


        public int ClicksCount { get; set; }



        public List<MassMediaPostLocalization> Localizations { get; set; } = new List<MassMediaPostLocalization>();
    }
}
