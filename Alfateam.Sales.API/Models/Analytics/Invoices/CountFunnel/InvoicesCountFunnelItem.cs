﻿using Alfateam.Sales.API.Enums.Analytics;

namespace Alfateam.Sales.API.Models.Analytics.Invoices.CountFunnel
{
    public class InvoicesCountFunnelItem
    {
        public InvoiceStatusType Type { get; set; }
        public int Count { get; set; }
    }
}
