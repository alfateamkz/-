using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.General.RolePowers;
using Alfateam.DB.Helpers;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.Models;
using Alfateam.TicketSystem.Models.Abstractions;
using Alfateam.TicketSystem.Models.DTO.Tickets.DistributionStrategies;
using Alfateam.TicketSystem.Models.General;
using Alfateam.TicketSystem.Models.General.Security;
using Alfateam.TicketSystem.Models.General.WorkingDays;
using Alfateam.TicketSystem.Models.General.WorkingDays.Changes;
using Alfateam.TicketSystem.Models.Integrations.API;
using Alfateam.TicketSystem.Models.Tickets;
using Alfateam.TicketSystem.Models.Tickets.Messages;
using Alfateam.TicketSystem.Models.Tickets.Senders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class TicketSystemDbContext : DbContext
    {
        public TicketSystemDbContext()
        {
            Database.EnsureCreated();
            CreateDefaultBusinessIfDoesNotExist();

        }
        public TicketSystemDbContext(DbContextOptions<TicketSystemDbContext> options)
        {
            Database.EnsureCreated();
            CreateDefaultBusinessIfDoesNotExist();
        }

        #region Abstractions
        public DbSet<TicketCreator> TicketCreators { get; set; }
        public DbSet<TicketDistributionStrategy> TicketDistributionStrategies { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<TicketMessageSender> TicketMessageSenders { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<WorkingDayChange> WorkingDayChanges { get; set; }

        #endregion

        #region General

        #region Security
        public DbSet<UserPermissions> UserPermissions { get; set; }

        #endregion

        #region WorkingDays

        public DbSet<CompanyWorkingDay> CompanyWorkingDayItems { get; set; }
        public DbSet<CompanyWorkingDays> CompanyWorkingDays { get; set; }

        #endregion

        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessCompany> BusinessCompanies { get; set; }
        public DbSet<BusinessCompanyTicketSettings> BusinessCompanyTicketSettings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SubscriptionInfo> SubscriptionInfo { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        #region Integrations

        #region API
        public DbSet<AlfateamAPIKey> AlfateamAPIKeys { get; set; }
        public DbSet<AlfateamAPIRequestEntry> AlfateamAPIRequestEntries { get; set; }

        #endregion

        #endregion

        #region Tickets

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessageAttachment> TicketMessageAttachments { get; set; }

        #endregion

        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }




        #region Initial methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.BuildConnectionString("alfateam_ticket_system"), new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Abstract TicketDistributionStrategy
            modelBuilder.Entity<TicketDistributionStrategy>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AverageLoadingTicketDistributionStrategy>();
            modelBuilder.Entity<ByOperatorPriorityTicketDistributionStrategy>();
            modelBuilder.Entity<MaxLoadingTicketDistributionStrategy>();
            modelBuilder.Entity<NotifyAllTicketDistributionStrategy>();
            modelBuilder.Entity<RandomTicketDistributionStrategy>();

            //Abstract TicketMessage
            modelBuilder.Entity<TicketMessage>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<TextTicketMessage>();

            //Abstract TicketMessageSender
            modelBuilder.Entity<TicketMessageSender>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<TicketMessageAdminSender>();
            modelBuilder.Entity<TicketMessageCustomerSender>();
            modelBuilder.Entity<TicketMessageAnonymSender>();

            //Abstract WorkingDayChange
            modelBuilder.Entity<WorkingDayChange>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<WorkingDayChangeDayOff>();
            modelBuilder.Entity<WorkingDayChangeNewTime>();
        }

        #endregion

        private void CreateDefaultBusinessIfDoesNotExist()
        {
            if (!Businesses.Any())
            {
                var business = new Business()
                {
                    Domain = "alfateam",
                    SubscriptionInfo = new SubscriptionInfo
                    {
                        SubscriptionBefore = DateTime.MaxValue,
                    },
                    OwnerAlfateamID = "artur-kachok-alfateam-hui"
                };

                var company = new BusinessCompany()
                {
                    Department = new Department()
                    {
                        Title = "Головное подразделение",
                        Description = "Наше офис (туалетная комната)",
                        Address = "РК, г. Астана, ул. Акмешит, д.7, кв.43",
                        IsRoot = true,
                    },
                    Description = "Делаем сайты и прочую хуйню",
                    ActualAddress = "РК, г. Астана, ул. Акмешит, д.7, кв.43",
                    LegalAddress = "РК, г. Астана, ул. Александра Затаевича, д.10, кв.24",
                    CountryCode = "KZ",
                    BusinessNumber = "123456789012",
                    Title = "ТОО Альфатим ИТ(Alfateam)",
                };
                company.Users.Add(new User
                {
                    Department = company.Department,
                    Permissions = new UserPermissions(),
                    Position = "Президент",
                    Role = UserRole.Owner,
                    AlfateamID = "artur-kachok-alfateam-hui",
                });


                business.Companies.Add(company);
                Businesses.Add(business);
                SaveChanges();
            }
        }
    }
}
