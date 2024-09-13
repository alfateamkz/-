using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.StaticPages.InnerLandings
{
    public class ILWorkWithUsPageTexts : LocalizableModel
    {
        public string MainBlockHeader { get; set; } = "Возможно, это работа твоей мечты!";
        public string MainBlockShortText { get; set; } = "Начни карьеру в нашей большой и дружной семье!";
        public string MainBlockWantToTeamBtn { get; set; } = "Хочу в команду";



        public string OurPhilosophyBlockHeader { get; set; } = "Наша философия";
        public string OurPhilosophyBlockHtmlColumn1 { get; set; } = "Не следим, во сколько ты пришел и ушел с работы, решил поработать из дома или офиса";
        public string OurPhilosophyBlockHtmlColumn2 { get; set; } = "Строим команду единамышлинников и даем свободу в реализации";
        public string OurPhilosophyBlockHtmlColumn3 { get; set; } = "Не любим душнил и не стоим над головой.";


        public string WorkInAlfateamBlockHeader { get; set; } = "Работа в Alfateam";
        public string WorkInAlfateamBlockLargeText { get; set; } = "Новый уровень развития вашего потенциала";
        public string WorkInAlfateamBlockLowerText { get; set; } = "С нами ты сможешь влиять на IT-индустрию, задавать новые тренды и создавать новые продукты";



        public string AvailableVacanciesHeader { get; set; } = "Доступные вакансии";
        public string LiveInOurCompanyHeader { get; set; } = "Жизнь в нашей компании";
        public string AlreadyJoinedUsHeader { get; set; } = "К нам уже присоединились";
    }
}
