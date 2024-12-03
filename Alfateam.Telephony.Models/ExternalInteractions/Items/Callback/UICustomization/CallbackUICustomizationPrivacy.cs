﻿using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization
{
    public class CallbackUICustomizationPrivacy : AbsModel
    {
        public string Header { get; set; }
        public string LinkText { get; set; }
        public string FullTextOfPrivacy { get; set; }
    }
}
