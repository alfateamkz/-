using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.General;
using Alfateam.Administration.Models.General.RolePowers;
using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.Files;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class AdmininstrationDbContext : DbContext
    {
        public AdmininstrationDbContext()
        {
            Database.EnsureCreated();
        }
        public AdmininstrationDbContext(DbContextOptions<AdmininstrationDbContext> options) : this()
        {
            Database.EnsureCreated();
        }

        #region Abstractions

        public DbSet<RolePower> RolePowers { get; set; }


        #endregion


        #region General

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleModel> UserRoleModels { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Abstract RolePower
            modelBuilder.Entity<RolePower>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<CertCenterRolePower>();
            modelBuilder.Entity<CommonRolePower>();

        }
    }
}
