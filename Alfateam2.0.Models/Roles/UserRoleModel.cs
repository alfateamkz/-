﻿using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Roles
{
    /// <summary>
    /// Сущность роли и прав пользователя
    /// </summary>
    public class UserRoleModel : AbsModel
    {
        /// <summary>
        /// Если Role == Owner, то доступны все разделы вне зависимости от свойств ниже
        /// </summary>
        public UserRole Role { get; set; } = UserRole.User;


        /// <summary>
        ///  Имеет ли пользователь админки доступ ко всем странам 
        ///  Если false, то имеет доступ только к странам из списка AvailableCountries
        /// </summary>
        public bool IsAllCountriesAccess { get; set; }  
        /// <summary>
        /// К каким странам пользователь админки имеет доступ
        /// </summary>
        public List<Country> AvailableCountries { get; set; } = new List<Country>();


        /// <summary>
        /// Если AllContentAccess по правам установлен выше, чем другие доступы, то другие доступы
        /// автоматически повышаются до AllContentAccess
        /// </summary>
        public AllContentAccessType AllContentAccess { get; set; } = AllContentAccessType.None;
        public PortfolioAccessType PortfolioAccess { get; set; } = PortfolioAccessType.None;
        public PostsAccessType PostsAccess { get; set; } = PostsAccessType.None;
        public MassMediaPostsAccessType MassMediaPostsAccess { get; set; } = MassMediaPostsAccessType.None;


        public HRAccessType HRAccess { get; set; } = HRAccessType.None;
        public ShopAccessType ShopAccess { get; set; } = ShopAccessType.None;
    }
}