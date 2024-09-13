using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral
{
    public class CCRefMainPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Реферальная программа";
        public string RulesText { get; set; } = "Правила реферальной программы. Задать из админки";
        public string MyRefLink { get; set; } = "Моя реферальная ссылка: {refLink}";


        public string BtnMyAccounts { get; set; } = "Мои счета";
        public string BtnWithdraw { get; set; } = "Вывести";


        public string RefTableHeaderLogin { get; set; } = "Логин";
        public string RefTableHeaderName { get; set; } = "Имя";
        public string RefTableHeaderOrdersCount { get; set; } = "Кол-во заказов";
        public string RefTableHeaderActions { get; set; } = "Действия";
    }
}
