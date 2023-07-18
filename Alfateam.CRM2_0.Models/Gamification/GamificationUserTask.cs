using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Gamification;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Gamification
{
    /// <summary>
    /// Задание пользователю в системе геймификации
    /// </summary>
    public class GamificationUserTask : AbsModel
    {
        public User TaskFor { get; set; }



        public string Title { get; set; }
        public string? Description { get; set; }



        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public GamificationUserTaskStatus Status { get; set; } = GamificationUserTaskStatus.Planned;


        public double Coins { get; set; }
        public double Rating { get; set; }

    }
}
