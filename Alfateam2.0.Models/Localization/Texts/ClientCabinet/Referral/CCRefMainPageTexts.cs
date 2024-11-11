using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral
{
    public class CCRefMainPageTexts : LocalizableModel
    {
        [Description("Заголовок: Реферальная программа")]
        public string Header { get; set; } = "Реферальная программа";

        [Description("Правила реферальной программы. Задать из админки")]
        public string RulesText { get; set; } = "Правила реферальной программы. Задать из админки";

        [Description("Моя реферальная ссылка: {refLink}")]
        public string MyRefLink { get; set; } = "Моя реферальная ссылка: {refLink}";


        [Description("Кнопка: Мои счета")]
        public string BtnMyAccounts { get; set; } = "Мои счета";
        [Description("Кнопка: Вывести")]
        public string BtnWithdraw { get; set; } = "Вывести";






        [Description("Столбец таблицы: Логин")]
        public string RefTableHeaderLogin { get; set; } = "Логин";

        [Description("Столбец таблицы: Имя")]
        public string RefTableHeaderName { get; set; } = "Имя";

        [Description("Столбец таблицы: Кол-во заказов")]
        public string RefTableHeaderOrdersCount { get; set; } = "Кол-во заказов";
   
        [Description("Столбец таблицы: Действия")]
        public string RefTableHeaderActions { get; set; } = "Действия";
    }
}
