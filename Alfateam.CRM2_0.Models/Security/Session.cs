using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Security
{
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
