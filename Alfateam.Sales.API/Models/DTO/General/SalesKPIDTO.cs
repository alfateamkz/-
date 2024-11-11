using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;
using System.ComponentModel;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class SalesKPIDTO : DTOModelAbs<SalesKPI>
    {
        [Description("Средний чек")]
        public int AverageCheque { get; set; }

        [Description("Сумма продаж")]
        public int SumOfSales { get; set; }

        [Description("Количество продаж")]
        public int SalesCount { get; set; }

        [Description("Количество открытых сделок")]
        public int CreatedDealsCount { get; set; }

        [Description("Количество новых клиентов")]
        public int NewClientsCount { get; set; }


        [Description("Количество людей/компаний, с которыми было какое-либо взаимодействие")]
        public int InteractedCount { get; set; }

        [Description("Количество людей/компаний, которые заинтересовались в покупке")]
        public int LeadsCount { get; set; }

        [Description("Процент людей/компаний, которые заинтересовались в покупке")]
        public double PercentOfLeads { get; set; }

        [Description("Процент продаж")]
        public double PercentOfSales { get; set; }


        [Description("Среднее время продажи")]
        public TimeSpan AverageTimeOfSale { get; set; }


        [Description("Количество людей/компаний, которые вернулось и с которыми удалось заключить сделку")]
        public int ReturnedClientCount { get; set; }


        [Description("Среднее количество холодных звонков, результатом которых станет продажа")]
        public int AverageColdCallsToSale { get; set; }

        [Description("Необходимое количество холодных звонков в день")]
        public int MinimalColdCallsPerDay { get; set; }
    }
}
