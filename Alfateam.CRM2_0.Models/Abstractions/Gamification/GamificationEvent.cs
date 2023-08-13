using Alfateam.CRM2_0.Models.Abstractions.Content.Tests;
using Alfateam.CRM2_0.Models.Content.Tests.QuestionOptions;
using Alfateam.CRM2_0.Models.Gamification.Events;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Gamification
{


    [JsonConverter(typeof(JsonKnownTypesConverter<GamificationEvent>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(AchievementGamificationEvent), "AchievementGamificationEvent")]
    [JsonKnownType(typeof(ContestGamificationEvent), "ContestGamificationEvent")]
    [JsonKnownType(typeof(FineGamificationEvent), "FineGamificationEvent")]
    [JsonKnownType(typeof(LevelCriteriaGamificationEvent), "LevelCriteriaGamificationEvent")]
    [JsonKnownType(typeof(LevelGamificationEvent), "LevelGamificationEvent")]
    [JsonKnownType(typeof(OrderGamificationEvent), "OrderGamificationEvent")]
    [JsonKnownType(typeof(TaskGamificationEvent), "TaskGamificationEvent")]
    /// <summary>
    /// Базовая сущность события в системе геймификации
    /// </summary>
    public abstract class GamificationEvent : AbsModel
    {
        /// <summary>
        /// Название события
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Полученное количество монет
        /// </summary>
        public double Coins { get; set; }

        /// <summary>
        /// Полученное количество рейтинга
        /// </summary>
        public double Karma { get; set; }
    }
}
