using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM {
    public class ContactsModel : BaseModel {


        public string? Phone { get; set; } = "";
        public string? Email { get; set; } = "";



        public string? Telegram { get; set; } = "";
        public string? WhatsApp { get; set; } = "";
        public string? Vkontakte { get; set; } = "";
        public string? Instagram { get; set; } = "";



        public string? Website { get; set; } = "";
    }
}
