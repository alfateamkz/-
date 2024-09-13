using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Common
{
    public class ClientCabinetCommonTexts : LocalizableModel
    {

        public string LastBreadcrump { get; set; } = "Личный кабинет";
        public string Header { get; set; } = "ЛИЧНЫЙ КАБИНЕТ";



        public string Info { get; set; } = "Информация";
        public string MyOrders { get; set; } = "Мои заказы";
        public string Favorites { get; set; } = "Избранное";
        public string Notifications { get; set; } = "Оповещения";
        public string MyProjects { get; set; } = "Мои проекты";
        public string DeliveryAddress { get; set; } = "Адрес доставки";
        public string ReferralProgram { get; set; } = "Реф. программа";
        public string Logout { get; set; } = "Выход из аккаунта";
    }

}
