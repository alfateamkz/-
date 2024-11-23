﻿using Alfateam.Sales.Models.Customers;

namespace Alfateam.Sales.API.Models.Analytics.Clients.RegularClients
{
    public class RegularClientsStatsRatingItem
    {
        public PersonContact Customer { get; set; }

        public int TakenOrdersCount { get; set; }
        public int WonOrdersCount { get; set; }



        public double TakenOrdersSum { get; set; }
        public double WonOrdersSum { get; set; }


        public double ConversionRate { get; set; }

    }
}
