﻿using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using Alfateam.EDM.Models.Integrations.API;

namespace Alfateam.EDM.Models.General
{
    public class Business : AbsModel
    {
        public string Domain { get; set; }

        public List<EDMSubject> Subjects { get; set; } = new List<EDMSubject>();
        public SubscriptionInfo SubscriptionInfo { get; set; }
        public List<AlfateamAPIKey> APIKeys { get; set; } = new List<AlfateamAPIKey>();


        //Alfateam ID владельца бизнеса(домена). Нужен, чтобы не было на одном Alfateam ID несколько доменов
        public string OwnerAlfateamID { get; set; }
    }
}
