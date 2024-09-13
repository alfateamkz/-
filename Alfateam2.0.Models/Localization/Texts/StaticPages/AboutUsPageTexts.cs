using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages
{
    public class AboutUsPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "О нас";
        public string Header { get; set; } = "О НАС";



        public string Block1Header { get; set; } = "Воплоти свои мечты с нашим дизайном";
        public string Block1Description { get; set; } = "Наша цель - помочь клиентам воплотить их видение и концепции в реальность. ";


        public string Block2HTMLContent { get; set; } = "Наши клиенты - это наше вдохновение и двигатель прогресса." +
            " Мы гордимся тем, что имеем возможность сотрудничать с ведущими компаниями," +
            " стартапами и предпринимателями, которые делят нашу страсть к инновациям и жаждут успеха.";



        public string Block3HTMLContent { get; set; } = "Мы искренне рады приветствовать вас в нашей компании, станьте частью истории вместе с нами!";





        public string OurAdvantagesHeader { get; set; } = "НАШИ ПРЕИМУЩЕСТВА";
        public string OurAdvantagesHtmlBlock1 { get; set; } = "Блок Талантливая команда дизайнеров. Заполнить из админки";
        public string OurAdvantagesHtmlBlock2 { get; set; } = "Блок Креативность и инновации. Заполнить из админки";
        public string OurAdvantagesHtmlBlock3 { get; set; } = "Блок Профессионализм и опыт. Заполнить из админки";
        public string OurAdvantagesHtmlBlock4 { get; set; } = "Блок Высокое качество. Заполнить из админки";
        public string OurAdvantagesHtmlBlock5 { get; set; } = "Блок Профессиональное обслуживание. Заполнить из админки";
        public string OurAdvantagesHtmlBlock6 { get; set; } = "Блок Развитие партнерских отношений. Заполнить из админки";




        public string OurHistoryHtmlBlock1 { get; set; } = "Блок истории 1. Заполнить из админки";
        public string OurHistoryHtmlBlock2 { get; set; } = "Блок истории 2. Заполнить из админки";
        public string OurHistoryHtmlBlock3 { get; set; } = "Блок истории 3. Заполнить из админки";
    }
}
