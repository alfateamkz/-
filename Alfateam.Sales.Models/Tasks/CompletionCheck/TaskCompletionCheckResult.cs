using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Tasks.CompletionCheck
{
    public class TaskCompletionCheckResult : AbsModel
    {
        public MarkedAsCompleted MarkedAsCompleted { get; set; }
        public int MarkedAsCompletedId  { get; set; }


        public bool IsCompleted { get; set; }
        public string? Comment { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int UserTaskId { get; set; }
    }
}
