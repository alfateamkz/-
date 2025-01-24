using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Common
{
    public class LinksLocalization : LocalizableModel
    {
        public LinksLocalization()
        {

        }
        public LinksLocalization(int languageId) : base(languageId)
        {

        }

        public string VkontakteLink { get; set; } = "";
        public string InstagramLink { get; set; } = "";
        public string FacebookLink { get; set; } = "";
        public string TwitterLink { get; set; } = "";
        public string TelegramLink { get; set; } = "";
    }
}
