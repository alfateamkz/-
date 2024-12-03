using Alfateam.Core;
using Alfateam.SharedModels.Gateways.SMS.Countries.Kazakhstan;
using Alfateam.SharedModels.Gateways.SMS.Countries.Mongolia;
using Alfateam.SharedModels.Gateways.SMS.Countries.Russia;
using Alfateam.SharedModels.Gateways.SMS.Global;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.Abstractions.Gateways
{

    [JsonConverter(typeof(JsonKnownTypesConverter<SMSGatewaySettings>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(MobizonSMSGatewaySettings), "MobizonSMSGatewaySettings")]
    [JsonKnownType(typeof(SMSCGatewaySettings), "SMSCGatewaySettings")]

    [JsonKnownType(typeof(UniSMSGatewaySettings), "UniSMSGatewaySettings")]

    [JsonKnownType(typeof(SMSAeroGatewaySettings), "SMSAeroGatewaySettings")]
    [JsonKnownType(typeof(SMSRuGatewaySettings), "SMSRuGatewaySettings")]

    [JsonKnownType(typeof(TwilioSMSGatewaySettings), "TwilioSMSGatewaySettings")]
    public class SMSGatewaySettings : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
    }
}
