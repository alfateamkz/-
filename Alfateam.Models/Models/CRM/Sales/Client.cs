using Alfateam.Database.Abstraction;
using Alfateam.Database.Enums.CRM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Sales {
    public class Client : BaseModel {

        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }

        public DateTime? BirthDate { get; set; }


        public ClientType ClientType { get; set; } = ClientType.Individual;
        public string CompanyName { get; set; } = "";
        public string Address { get; set; } = "";


        public string? Description { get; set; }
        public ContactsModel Contacts { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public override string ToString() {

            switch (ClientType) {
                case ClientType.Individual:
                    return $"{Surname} {Name} {Patronymic}";
                case ClientType.IE:
                    return $"ИП {Surname} {Name} {Patronymic}";
                case ClientType.LLC:
                    return $"{CompanyName}";
                case ClientType.Other:
                    return $"{Surname} {Name} {Patronymic} ({CompanyName})";
                default:
                    return $"{Surname} {Name} {Patronymic}";
            }

       
            
        }
    }
}
