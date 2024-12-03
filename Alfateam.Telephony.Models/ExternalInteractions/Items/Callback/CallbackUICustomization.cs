using Alfateam.Core;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.Callback
{
    public class CallbackUICustomization : AbsModel
    {
        public CallbackUICustomizationFormType FormType { get; set; }


        public CallbackUICustomizationGeneral General { get; set; }
        public CallbackUICustomizationPrivacy Privacy { get; set; }
        public CallbackUICustomizationTexts Texts { get; set; }
    }
}
