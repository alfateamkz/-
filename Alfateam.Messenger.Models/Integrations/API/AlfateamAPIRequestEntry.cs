using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Integrations.API
{
    public class AlfateamAPIRequestEntry : AbsModel
    {
        public string URL { get; set; }
        public string HTTPMethod { get; set; }
        public string Headers { get; set; }
        public string? Response { get; set; }




        public string IP { get; set; }
        public string? UserAgent { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int AlfateamAPIKeyId { get; set; }
    }
}
