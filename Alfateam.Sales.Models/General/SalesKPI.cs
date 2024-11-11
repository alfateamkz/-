using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    /// <summary>
    /// Модель ключевых показателей продаж
    /// </summary>
    public class SalesKPI : AbsModel
    {
        /// <summary>
        /// Средний чек
        /// </summary>
        public int AverageCheque { get; set; }
        /// <summary>
        /// Сумма продаж
        /// </summary>
        public int SumOfSales { get; set; }
        /// <summary>
        /// Количество продаж
        /// </summary>
        public int SalesCount { get; set; }
        /// <summary>
        /// Количество открытых сделок
        /// </summary>
        public int CreatedDealsCount { get; set; }
        /// <summary>
        /// Количество новых клиентов
        /// </summary>
        public int NewClientsCount { get; set; }


        /// <summary>
        /// Количество людей/компаний, с которыми было какое-либо взаимодействие
        /// </summary>
        public int InteractedCount { get; set; }
        /// <summary>
        /// Количество людей/компаний, которые заинтересовались в покупке
        /// </summary>
        public int LeadsCount { get; set; }
        /// <summary>
        /// Процент людей/компаний, которые заинтересовались в покупке
        /// </summary>
        public double PercentOfLeads { get; set; }
        /// <summary>
        /// Процент продаж
        /// </summary>
        public double PercentOfSales { get; set; }


        /// <summary>
        /// Среднее время продажи
        /// </summary>
        public TimeSpan AverageTimeOfSale { get; set; }


        /// <summary>
        /// Количество людей/компаний, которые вернулось и с которыми удалось заключить сделку
        /// </summary>
        public int ReturnedClientCount { get; set; }



        /// <summary>
        /// Среднее количество холодных звонков, результатом которых станет продажа
        /// </summary>
        public int AverageColdCallsToSale { get; set; }
        /// <summary>
        /// Необходимое количество холодных звонков в день
        /// </summary>
        public int MinimalColdCallsPerDay { get; set; }

    }
}
