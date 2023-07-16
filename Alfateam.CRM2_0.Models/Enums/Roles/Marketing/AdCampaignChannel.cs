using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Enums.Roles.Marketing
{
    /// <summary>
    /// Канал рекламной кампании
    /// </summary>
    public enum AdCampaignChannel
    {
        OutdoorAds = 1, //Наружная реклама
        MetroAds = 2, //Реклама в метро
        TV = 3, //Реклама на телевидении
        NativeAd = 4, //Нативная реклама
        Targeting = 5, //Таргетированная реклама
        BlogersAds = 6, //Реклама у блогеров
        AppsAd = 7, //Реклама в приложениях
        SEO = 8, //SEO
        Direct = 9, //Директ
        SMM = 10, //SMM
        ContextualAds = 11, //Контекстная реклама
        Retargeting = 12, //Ретаргетинг
        Forums = 13, //Форумы
        Emailing = 14, //Email-рассылка
        AdSystems = 15, //Рекламные системы



        Other = 999, //Прочее
    }
}
