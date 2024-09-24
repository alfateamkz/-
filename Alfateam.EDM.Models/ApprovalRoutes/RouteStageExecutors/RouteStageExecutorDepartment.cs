using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.ApprovalRoutes.RouteStageExecutors
{
    public class RouteStageExecutorDepartment : RouteStageExecutor
    {
        public Department Department { get; set; }
        public int DepartmentId { get; set; }


        public List<User> ExcludingUsers { get; set; } = new List<User>();

    }
}
