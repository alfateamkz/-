using Alfateam.Core;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.ExternalInteractions.Items.Callback.UICustomization
{
    public class CallbackUICustomizationGeneral : AbsModel
    {
        public int CountdownSeconds { get; set; }
        public string ImgPath { get; set; }



        public CallbackUICustomizationGeneralButtonPosition ButtonPosition { get; set; }
        public int X_Px_Margin { get; set; }
        public int Y_Px_Margin { get; set; }



        public string ButtonText { get; set; }


        public CallbackUICustomizationTextsWorkingTime TextsWorkingTime { get; set; }
        public CallbackUICustomizationTextsLeavingSite TextsLeavingSite { get; set; }
        public CallbackUICustomizationTextsNotWorkingTime TextsNotWorkingTime { get; set; }
        public CallbackUICustomizationTextsDelayedCall TextsDelayedCall { get; set; }
    }
}
