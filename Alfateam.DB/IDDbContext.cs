using Alfateam.Core.Helpers;
using Alfateam.DB.Helpers;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.ID.Models;
using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Payments;
using Alfateam.ID.Models.Payments.Ways;
using Alfateam.ID.Models.Security;
using Alfateam.ID.Models.Security.Verifications;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Promocodes;
using Alfateam2._0.Models.Shop.Modifiers.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class IDDbContext : DbContext
    {
        public IDDbContext()
        {
            Database.EnsureCreated();
            CreateDefaultUsers();
        }
        public IDDbContext(DbContextOptions<IDDbContext> options)
        {
            Database.EnsureCreated();
            CreateDefaultUsers();
        }


        #region Abstractions

        public DbSet<BindedPaymentWay> BindedPaymentWays { get; set; }
        public DbSet<Verification> Verifications { get; set; }

        #endregion

        #region Payments
        public DbSet<Payment> Payments { get; set; }

        #endregion

        #region Security
        public DbSet<Session> Sessions { get; set; }

        #endregion

        public DbSet<User> Users { get; set; }




        private void CreateDefaultUsers()
        {
            if (!Users.Any())
            {
                Users.Add(new User
                {
                    Name = "Артур",
                    Surname = "Бондарев",
                    Patronymic = "Александрович",
                    CountryCode = "KZ",
                    LanguageCode = "MN",
                    Email = "alfateamkz2@yandex.kz",
                    Phone = "77057417483",
                    IsEmailVerified = true,
                    IsPhoneVerified = true,
                    Password = PasswordHelper.EncryptPassword("alfateam_id"),
                });
                SaveChanges();
            }
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.AlfateamID, new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Abstract Verification
            modelBuilder.Entity<CodeVerification>();

            //Abstract BindedPaymentWay
            modelBuilder.Entity<BindedPaymentWay>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<BindedBankCard>();

        }
    }
}
