using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.ApprovalRoutes.RouteStageExecutors
{
    public class RouteStageExecutorUsers : RouteStageExecutor
    {
        public List<User> Users { get; set; } = new List<User>();
    }
}
