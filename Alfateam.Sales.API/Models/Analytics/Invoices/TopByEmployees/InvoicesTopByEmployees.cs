using Alfateam.Sales.API.Enums.Analytics;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Invoices;


namespace Alfateam.Sales.API.Models.Analytics.Invoices.TopByEmployees
{
    public class InvoicesTopByEmployees
    {
        public InvoiceStatusType Type { get; set; }
        public InvoiceFilterParameterType ParameterType { get; set; }
        public Currency Currency { get; set; }


        public List<InvoicesTopByEmployeesItem> Places { get; set; } = new List<InvoicesTopByEmployeesItem>();
        public int? MyPlace { get; set; }


        public InvoicesTopByEmployees Fill(IEnumerable<Invoice> invoices, int myUserId)
        {
            invoices = invoices.Where(o => o.CurrencyId == Currency.Id);

            SetPlacesValuesAndOrder(invoices);
            SetPlacesNumberAndMyPlace(invoices, myUserId);

            return this;
        }


        private void SetPlacesValuesAndOrder(IEnumerable<Invoice> invoices)
        {
            var groupedInvoicesByManager = invoices.GroupBy(o => o.CreatedById);
            foreach (var group in groupedInvoicesByManager)
            {
                switch (ParameterType)
                {
                    case InvoiceFilterParameterType.NumberOfInvoices:
                        Places.Add(new InvoicesTopByEmployeesItem
                        {
                            Value = group.Count(),
                            ManagerId = group.Key,
                        });
                        break;
                    case InvoiceFilterParameterType.SumOfInvoices:
                        Places.Add(new InvoicesTopByEmployeesItem
                        {
                            Value = group.Sum(o => o.TotalSum),
                            ManagerId = group.Key,
                        });
                        break;
                }
            }

            Places = Places.OrderByDescending(o => o.Value).ToList();
        }
        private void SetPlacesNumberAndMyPlace(IEnumerable<Invoice> invoices, int myUserId)
        {
            int placesCounter = 1;
            foreach (var place in Places)
            {
                place.Place = placesCounter++;

                if (place.ManagerId == myUserId)
                {
                    MyPlace = place.Place;
                }
            }
        }

    }
}
