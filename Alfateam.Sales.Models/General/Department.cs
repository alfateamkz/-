using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class Department : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public List<Department> SubDepartments { get; set; } = new List<Department>();




        /// <summary>
        /// Головное ли подразделение. Если да, то оно не может быть удалено
        /// </summary>
        public bool IsRoot { get; set; }






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
