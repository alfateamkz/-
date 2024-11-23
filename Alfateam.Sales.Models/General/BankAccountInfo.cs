using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class BankAccountInfo : AbsModel
    {
        public string Title { get; set; }
        public string Bank { get; set; }
        public string AccountInfo { get; set; }
    }
}
