using Alfateam.Database.Models.CRM;
using Alfateam.Database.Models.CRM.Sales;

namespace Alfateam.CRM.ViewModels.Sales.Clients {
    public class ClientPageVM {
        public Client Client { get; set; } = new Client() {
            Contacts = new ContactsModel()
        };
    }
}
