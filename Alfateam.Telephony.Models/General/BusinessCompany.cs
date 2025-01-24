using Alfateam.Core;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.Contacts;
using Alfateam.Telephony.Models.HLR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.General
{
    public class BusinessCompany : AbsModel
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        public string? LogoPath { get; set; }





        public List<User> Users { get; set; } = new List<User>();
        public Department Department { get; set; }




        public List<TelephonyNumber> TelephonyNumbers { get; set; } = new List<TelephonyNumber>();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<ContactCategory> ContactCategories { get; set; } = new List<ContactCategory>();



        public List<HLRTask> HLRTasks { get; set; } = new List<HLRTask>();


        public List<ExtLine> ExtLines { get; set; } = new List<ExtLine>();
        public List<ExtInteraction> ExtInteractions { get; set; } = new List<ExtInteraction>();
        public List<ModerationForbiddenPhrase> ModerationForbiddenPhrases { get; set; } = new List<ModerationForbiddenPhrase>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessId { get; set; }
    }
}
