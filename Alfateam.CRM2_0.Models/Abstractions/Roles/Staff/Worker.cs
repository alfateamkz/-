using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Staff
{
    /// <summary>
    /// Базовая модель пользователя, который может учавствовать в разработке проектов
    /// От данного класса наследуются Employee (сотрудник фирмы) и Counterparty(контрагент)
    /// </summary>
    public abstract class Worker : User
    {




        public WorkerNotificationSettings NotificationSettings { get; set; }
        public List<WorkerDocument> Documents { get; set; } = new List<WorkerDocument>();


        public List<Encouragement> Encouragements { get; set; } = new List<Encouragement>();
        public List<Fine> Fines { get; set; } = new List<Fine>();

    }
}
