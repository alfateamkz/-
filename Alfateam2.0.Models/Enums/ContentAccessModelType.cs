using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Тип раздела, к которому нужен доступ
    /// </summary>
    public enum ContentAccessModelType
    {
        All = 1, //Все разделы
        Posts = 2, //Новостные записи
        MassMediaPosts = 3, //Записи раздела "Мы в СМИ"
        Portfolio = 4, //Портфолио
        Compliance = 5, //Комплаенс
        Events = 6, //События
        Team = 7, //Раздел "Команда"
        General = 8, // Раздел в админке "Основное"
        Partners = 9, //Раздел "Партнеры",
        Services = 10, //Лендинги услуг
    }
}
