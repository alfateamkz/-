using Alfateam.CRM2_0.Models.Security;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.ID.Models;
using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Payments;
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
        }
        public IDDbContext(DbContextOptions<IDDbContext> options)
        {
            Database.EnsureCreated();
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
    }
}
