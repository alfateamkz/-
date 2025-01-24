using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Integrations.API
{
    public class AlfateamAPIKey : AbsModel
    {
        public string Title { get; set; }
        public string Key { get; set; } = System.Guid.NewGuid().ToString();
        public bool IsEnabled { get; set; } = true;



        /// <summary>
        /// Если IsDefault == true, то этот API ключ используется на сайте и по нему ограничен CORS
        /// Нельзя будет по этому ключу отправлять запросы с других клиентов
        /// </summary>
        public bool IsDefault { get; set; }
        public DateTime? PaidBefore { get; set; }



        public List<AlfateamAPIRequestEntry> Requests { get; set; } = new List<AlfateamAPIRequestEntry>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessId { get; set; }
    }
}
