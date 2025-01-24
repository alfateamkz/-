using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.Blogs.Blocks;
using Alfateam.Administration.Models.Blogs.Feedbacks.Comments;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.Administration.Models.Blogs.Feedbacks.Watches;
using Alfateam.Administration.Models.General;
using Alfateam.Administration.Models.General.RolePowers;
using Alfateam.Administration.Models.General.Security;
using Alfateam.Administration.Models.StaticTextsConstructor;
using Alfateam.Administration.Models.Stats;
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
        public DbSet<AbsField> Fields { get; set; }
        public DbSet<BlogPostBlock> BlogPostBlocks { get; set; }
        public DbSet<RolePower> RolePowers { get; set; }


        #endregion

        #region Blogs

        #region Feedbacks

        #region Comments
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentAttachment> CommentAttachments { get; set; }

        #endregion

        #region Reactions
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<ReactionCounter> ReactionCounters { get; set; }
        public DbSet<SetReaction> SetReactions { get; set; }

        #endregion

        #region Watches
        public DbSet<Watch> Watches { get; set; }
        public DbSet<WatchesCounter> WatchesCounters { get; set; }

        #endregion

        #endregion

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        #endregion

        #region General

        #region Security
        public DbSet<UserAction> UserActions { get; set; }

        #endregion

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleModel> UserRoleModels { get; set; }

        #endregion

        #region StaticTextsConstructor
        public DbSet<StaticTextsModel> StaticTextsModels { get; set; }
        public DbSet<TextCategory> TextCategories { get; set; }

        #endregion

        #region Stats
        public DbSet<WebsiteVisit> WebsiteVisits { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Abstract AbsField
            modelBuilder.Entity<AbsField>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<HTMLTextField>();
            modelBuilder.Entity<ImageField>();
            modelBuilder.Entity<SimpleTextField>();
            modelBuilder.Entity<VideoField>();

            //Abstract RolePower
            modelBuilder.Entity<RolePower>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<CertCenterRolePower>();
            modelBuilder.Entity<CommonRolePower>();

            //Abstract BlogPostBlock
            modelBuilder.Entity<BlogPostBlock>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<AudioBlock>();
            modelBuilder.Entity<DelimiterBlock>();
            modelBuilder.Entity<HTMLTextBlock>();
            modelBuilder.Entity<ImageBlock>();
            modelBuilder.Entity<QuoteBlock>();
            modelBuilder.Entity<VideoBlock>();
        }
    }
}
