﻿using Alfateam2._0.Models;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Events;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.HR;
using Alfateam2._0.Models.Outstaff;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Posts;
using Alfateam2._0.Models.Reviews;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Modifiers;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop.Wishes;
using Alfateam2._0.Models.Team;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class WebsiteDBContext : DbContext
    {



        #region Abstractions
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<ProductModifierItem> ProductModifierItems { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }

        #endregion

        #region Events
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventFormat> EventFormats { get; set; }
        #endregion

        #region General
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountrySite> CountrySites { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PricingMatrix> PricingMatrices { get; set; }
        public DbSet<PricingMatrixItem> PricingMatrixItems { get; set; }
        public DbSet<RateVote> RateVotes { get; set; }
        public DbSet<Alfateam2._0.Models.General.TimeZone> TimeZones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Watch> Watches { get; set; }
        #endregion

        #region HR
        public DbSet<JobVacancy> JobVacancies { get; set; }
        public DbSet<JobVacancyExpierence> JobVacancyExpierences { get; set; }
        #endregion

        #region Outstaff
        public DbSet<OutstaffColumn> OutstaffColumns { get; set; }
        public DbSet<OutstaffItem> OutstaffItems { get; set; }
        public DbSet<OutstaffItemGrade> OutstaffItemGrades { get; set; }
        public DbSet<OutstaffItemGradeColumn> OutstaffItemGradeColumns { get; set; }
        public DbSet<OutstaffMatrix> OutstaffMatrices { get; set; }
        #endregion

        #region Portfolios
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        public DbSet<PortfolioIndustry> PortfolioIndustries { get; set; }
        #endregion

        #region Posts
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostIndustry> PostIndustries { get; set; }
        #endregion

        #region Reviews
        public DbSet<Review> Reviews { get; set; }
        #endregion

        #region Roles
        public DbSet<UserRoleModel> UserRoleModels { get; set; }
        #endregion

        #region Shop

        #region Modifiers
        public DbSet<ProductModifier> ProductModifiers { get; set; }
        #endregion

        #region Orders
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<ShopOrderItem> ShopOrderItems { get; set; }
        public DbSet<ShopOrderReturn> ShopOrderReturns { get; set; }
        #endregion

        #region Wishes
        public DbSet<ShopWishlist> ShopWishlists { get; set; }
        public DbSet<ShopWishlistItem> ShopWishlistItems { get; set; }
        #endregion

        public DbSet<ShopProduct> ShopProducts { get; set; }
        public DbSet<ShopProductCategory> ShopProductCategories { get; set; }
        public DbSet<ShopProductImage> ShopProductImages { get; set; }
        #endregion

        #region Team
        public DbSet<TeamGroup> TeamGroups { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamStructure> TeamStructures { get; set; }
        #endregion

        public DbSet<ComplianceDocument> ComplianceDocuments { get; set; }
        public DbSet<MassMediaPost> MassMediaPosts { get; set; }
        public DbSet<Partner> Partners { get; set; }
    }
}