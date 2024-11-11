using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models
{
    public class Customer : AbsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        [NotMapped]
        public string FIO => $"{Surname} {Name} {Patronymic}";



        public CustomerCategory Category { get; set; }
        public int CategoryId  { get; set; }



        public CompanyInfo? CompanyInfo { get; set; }

        
        public string Comment { get; set; }



        public List<Order> Orders { get; set; } = new List<Order>();
        public List<CustomerConversation> Conversations { get; set; } = new List<CustomerConversation>();




        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
