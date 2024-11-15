using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Tasks
{
    /// <summary>
    /// Задачи сотрудникам. Если CreatedById == TaskForId, то задача выставлена себе
    /// </summary>
    public class SimpleUserTask : UserTask
    { 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
