using Alfateam.Database.Models.CRM.Accounting;
using Alfateam.Database.Models.CRM.Orders;
using Alfateam.Database.Models.CRM.Sales;
using Alfateam.Database.Models.CRM.Staff;
using Alfateam.Database.Models.CRM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Database.Models.Localizations.Texts;
using Alfateam.Database.Models;
using Alfateam.Database.Enums;
using Alfateam.Database.Enums.CRM;
using Alfateam.Database.Enums.CRM.Staff;
using Alfateam.Database.Helpers;

namespace Alfateam.Database {
    public class CRMDatabaseContext : DbContext {





        #region Accounting
        public DbSet<AccountingItem> AccountingItems { get; set; }

        #endregion

        #region Orders
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<OrderStage> OrderStages { get; set; }
        public DbSet<StageHumanResource> StageHumanResources { get; set; }
        public DbSet<StageMaterialResource> StageMaterialResources { get; set; }
        #endregion

        #region Sales
        public DbSet<Client> Clients { get; set; }

        #endregion

        #region Staff
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDayInfo> EmployeeDayInfos { get; set; }
        public DbSet<EmployeeDocuments> EmployeeDocuments { get; set; }

        #endregion

        public DbSet<ContactsModel> ContactsModels { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public CRMDatabaseContext() : base() {
            Database.EnsureCreated();

            if (!Employees.Any()) {
                CreateBossEmployee();
                SaveChanges();
            }

        }

        public CRMDatabaseContext(DbContextOptions<CRMDatabaseContext> options) {
            Database.EnsureCreated();

            if (!Employees.Any()) {
                CreateBossEmployee();
                SaveChanges();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(DatabaseSettings.CRMConnectionString,
                       new MySqlServerVersion(new Version(8, 0, 11)));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

        }


        private void CreateBossEmployee() {
            Employees.Add(new Employee {
                Surname = "Бондарев",
                Name = "Артур",
                Patronymic = "Александрович",
                BirthDate = new DateTime(2002, 9, 8),
                Role = EmployeeRole.Boss,
                Salary = 65000,
                Contacts = new ContactsModel {
                    Email = "alfateamkz2@yandex.kz",
                    Phone = "+77057417483",
                    Website = "https://alfateam.kz",
                    WhatsApp = "+79518549717",
                    Instagram = "",
                    Telegram = "alfateam_kz",
                    Vkontakte = "",
                },
                Documents = new EmployeeDocuments(),
                Description = "Царь и бог команды alfateam",
                Address = "г. Астана",
                PaymentInfo = "",
                PaymentTerm = PaymentTerm.Monthly,
                Status = EmployeeStatus.Active,
                EmployeeType = EmployeeType.FullTime,
                Login = "alfateam_artur",
                Password = "alfateam228"
            });
        }
    }
}
