﻿using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Gamification;
using Alfateam.CRM2_0.Models.General.Info;
using Alfateam.CRM2_0.Models.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Базовая модель пользователя CRM
    /// </summary>
    public class User : AbsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }


        public Country Country { get; set; }
        public int CountryId { get; set; }


        public UserRoleModel RoleModel { get; set; }


        public GamificationUser? GamificationUser { get; set; }
        public int? GamificationUserId { get; set; }


        public string Login { get; set; }
        public string Email { get; set; }

      


        [JsonIgnore]
        public string Password { get; set; }



        [JsonIgnore]
        public List<UsedCredential> UsedCredentials { get; set; } = new List<UsedCredential>();


        public bool IsActive { get; set; } = true;



        [JsonIgnore]
        public Business Business { get; set; }
        [JsonIgnore]
        public int BusinessId { get; set; }

        [JsonIgnore]
        public Organization? Organization { get; set; }
        [JsonIgnore]
        public int? OrganizationId { get; set; }

        [JsonIgnore]
        public OrganizationOffice? Office { get; set; }
        [JsonIgnore]
        public int? OfficeId { get; set; }
    }
}
