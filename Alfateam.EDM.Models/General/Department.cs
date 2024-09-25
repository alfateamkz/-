using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.General
{
    public class Department : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Address { get; set; }
        public List<Department> SubDepartments { get; set; } = new List<Department>();




        public List<Document> Documents { get; set; } = new List<Document>();
    }
}
