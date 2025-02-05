using Alfateam.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.ID.Models.Security
{
    public class Session : AbsModel
    {
        public User User { get; set; }
        public int UserId { get; set; }



        public string SessID { get; set; } = Guid.NewGuid().ToString();
        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddHours(12);
        public string RefreshToken { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeactivated { get; set; }
        public bool IsRefreshTokenUsed { get; set; }




        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string Fingerprint { get; set; }




        [JsonIgnore]
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;

        [JsonIgnore]
        public bool IsActive => !IsExpired && !IsDeactivated;
    }
}
