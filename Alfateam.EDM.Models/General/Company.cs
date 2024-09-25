using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.General
{
    public class Company : AbsModel
    {
        public string Title { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

    }
}
