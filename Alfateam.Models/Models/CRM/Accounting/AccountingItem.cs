using Alfateam.Database.Abstraction;
using Alfateam.Database.Enums.CRM.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Accounting {
    public class AccountingItem : BaseModel {

        public string Title { get; set; }
        public string Description { get; set; }


        public DateTime Date { get; set; } = DateTime.Now;
        public double Sum { get; set; }
        public AccountingItemDirection Direction { get; set; } = AccountingItemDirection.Income;
    }
}
