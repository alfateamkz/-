using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.HR
{
    public class HRJobVacanciesListPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Вакансии";
        public string Header { get; set; } = "Вакансии";


        public string SearchVacancyPlaceholder { get; set; } = "Поиск вакансии";
        public string FindJobBtn { get; set; } = "Найти работу";


        public string NowWatchingAmountText { get; set; } = "Сейчас просматривают {amount} человек";
        public string NowWatching2_3_4_AmountText { get; set; } = "Сейчас просматривают {amount} человека";
        public string SendRequest { get; set; } = "Откликнуться";




        public string ExpierenceNo { get; set; } = "Без опыта";
        public string ExpierenceFrom1Year { get; set; } = "От 1 года";
        public string ExpierenceFromPlural { get; set; } = "От {amount} лет";

        public string ExpierenceTo1Year { get; set; } = "До 1 года";
        public string ExpierenceToPlural { get; set; } = "До {amount} лет";

        public string ExpierenceFrom0To1Year { get; set; } = "От нуля до 1 года";
        public string ExpierenceFromToPlural { get; set; } = "От {amount_from} до {amount_to} лет";




        public string FilterNameEducation { get; set; } = "Образование";
        public string FilterNameWorkTime { get; set; } = "График работы";
        public string FilterNameIncomeLevel { get; set; } = "Уровень дохода";

    }
}
