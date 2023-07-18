using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff
{
    /// <summary>
    /// Модель настроек напоминаний сотруднику/контрагенту
    /// </summary>
    public class WorkerNotificationSettings : AbsModel
    {

        /// <summary>
        /// Раз во сколько дней нужно высылать напоминания
        /// </summary>
        public int OnceEveryDay { get; set; } = 1;
        /// <summary>
        /// Нужно ли высылать уведомления в нерабочие дни
        /// </summary>
        public bool NotifyAtOffDays { get; set; }


        /// <summary>
        /// Время, в которое нужно высылать уведомления
        /// </summary>
        public TimeSpan NotifyAtTime { get; set; } = new TimeSpan(17, 0, 0);



        /// <summary>
        /// Нужно ли высылать SMS уведомления на телефон сотрудника
        /// </summary>
        public bool ShouldSendSMSNotification { get; set; } = true;
        /// <summary>
        /// Нужно ли высылать уведомления на почтовый ящик сотрудника
        /// </summary>
        public bool ShouldSendEmailNotification { get; set; } = true;
    }
}
