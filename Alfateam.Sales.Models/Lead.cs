using Alfateam.Core;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models
{
    public class Lead : AbsModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public List<ContactInfo> Contacts { get; set; } = new List<ContactInfo>();



        public string Comment { get; set; }
    }
}
