using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.General.WorkingDays
{
    public class WorkingDaysModel : AbsModel
    {
        public WorkingDaysModel() : this(false)
        {

        }

        public WorkingDaysModel(bool createModels = false)
        {
            if (createModels)
            {
                Days.Add(new WorkingDay
                {
                    DayOfWeek = DayOfWeek.Monday,
                    IsWorkingDay = true,
                });
                Days.Add(new WorkingDay
                {
                    DayOfWeek = DayOfWeek.Tuesday,
                    IsWorkingDay = true,
                });
                Days.Add(new WorkingDay
                {
                    DayOfWeek = DayOfWeek.Wednesday,
                    IsWorkingDay = true,
                });
                Days.Add(new WorkingDay
                {
                    DayOfWeek = DayOfWeek.Thursday,
                    IsWorkingDay = true,
                });
                Days.Add(new WorkingDay
                {
                    DayOfWeek = DayOfWeek.Friday,
                    IsWorkingDay = true,
                });
                Days.Add(new WorkingDay
                {
                    DayOfWeek = DayOfWeek.Saturday,
                    IsWorkingDay = true,
                });
                Days.Add(new WorkingDay
                {
                    DayOfWeek = DayOfWeek.Sunday,
                    IsWorkingDay = true,
                });
            }
        }

        public List<WorkingDay> Days { get; set; } = new List<WorkingDay>();
    }
}
