using Alfateam.Database.Abstraction;
using Alfateam.Database.Enums;
using Alfateam.Database.Enums.CRM;
using Alfateam.Database.Enums.CRM.Staff;
using Alfateam.Database.Models.CRM.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM
{


    public class Employee : BaseModel {


        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public string? PhotoPath { get; set; } = "";

        [NotMapped] //TODO: сделать маппед
        public string Position { get; set; }


        public DateTime BirthDate { get; set; } = DateTime.Now;


        public EmployeeRole Role { get; set; } = EmployeeRole.Employee;
        public EmployeeType EmployeeType { get; set; } = EmployeeType.FullTime;
        public PaymentTerm PaymentTerm { get; set; } = PaymentTerm.Monthly;
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;

        public double Salary { get; set; }
        [NotMapped]
        public double HourlyWage {
            get {                                                                                                             

                switch (EmployeeType) {
                    case EmployeeType.FullTime:
                        return Salary / 160;
                    case EmployeeType.PartTime:
                        return Salary / 80;
                    default:
                        return 0;
                }
            }
        }




        public string? Description { get; set; }
        public ContactsModel Contacts { get; set; }
        public EmployeeDocuments Documents { get; set; }


        public string? Address { get; set; } = "";
        public string? PaymentInfo { get; set; } = "";



        public string Login { get; set; }
        public string Password { get; set; }



        /// <summary>
        /// Информация о рабочих днях сотрудника (для штатных)
        /// </summary>
        public List<EmployeeDayInfo> EmployeeDays { get; set; } = new List<EmployeeDayInfo>();


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime EmployeedAt { get; set; } = DateTime.Now;
        public DateTime? FiredAt { get; set; }



        public override string ToString() {
            return $"{Surname} {Name} {Patronymic} ({Position})";
        }


    }
}
