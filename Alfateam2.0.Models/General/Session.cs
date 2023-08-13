using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность авторизационной сессии
    /// </summary>
    public class Session : AbsModel
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public string SessID { get; set; } = Guid.NewGuid().ToString();
        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddHours(12);
        public bool IsDeactivated { get; set; }


        [JsonIgnore]
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;


        
    }
}
