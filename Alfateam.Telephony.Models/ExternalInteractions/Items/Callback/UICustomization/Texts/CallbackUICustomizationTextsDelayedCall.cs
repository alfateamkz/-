﻿using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization.Texts
{
    public class CallbackUICustomizationTextsDelayedCall : AbsModel
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public string CallNow { get; set; }
        public string ThankForOrder { get; set; }
    }
}
