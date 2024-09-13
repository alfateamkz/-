using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Staff;
using Alfateam.CRM2_0.Models.Roles.Staff.Counterparties;
using Alfateam.CRM2_0.Models.Roles.Staff.Counterparties.Subparties;
using Alfateam.CRM2_0.Models.Roles.Staff.Employess;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Staff
{


    [JsonConverter(typeof(JsonKnownTypesConverter<Worker>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(Employee), "Employee")]
    [JsonKnownType(typeof(Counterparty), "Counterparty")]
    /// <summary>
    /// Базовая модель пользователя, который может участвовать в разработке проектов
    /// От данного класса наследуются Employee (сотрудник фирмы) и Counterparty(контрагент)
    /// </summary>
    public class Worker : User
    {



        public WorkerNotificationSettings NotificationSettings { get; set; }
        public List<WorkerDocument> Documents { get; set; } = new List<WorkerDocument>();


        public List<Encouragement> Encouragements { get; set; } = new List<Encouragement>();
        public List<Fine> Fines { get; set; } = new List<Fine>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? OrganizationOfficeStaffId { get; set; } 

    }
}
