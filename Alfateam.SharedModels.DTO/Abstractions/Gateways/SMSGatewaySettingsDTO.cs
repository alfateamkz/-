using Alfateam.SharedModels.Abstractions.Gateways;
using Alfateam.SharedModels.DTO.Gateways.SMS.Countries.Kazakhstan;
using Alfateam.SharedModels.DTO.Gateways.SMS.Countries.Mongolia;
using Alfateam.SharedModels.DTO.Gateways.SMS.Countries.Russia;
using Alfateam.SharedModels.DTO.Gateways.SMS.Global;
using Alfateam.SharedModels.Gateways.SMS.Countries.Kazakhstan;
using Alfateam.SharedModels.Gateways.SMS.Countries.Mongolia;
using Alfateam.SharedModels.Gateways.SMS.Countries.Russia;
using Alfateam.SharedModels.Gateways.SMS.Global;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Abstractions.Gateways
{
    [JsonConverter(typeof(JsonKnownTypesConverter<SMSGatewaySettingsDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(MobizonSMSGatewaySettingsDTO), "MobizonSMSGatewaySettings")]
    [JsonKnownType(typeof(SMSCGatewaySettingsDTO), "SMSCGatewaySettings")]

    [JsonKnownType(typeof(UniSMSGatewaySettingsDTO), "UniSMSGatewaySettings")]

    [JsonKnownType(typeof(SMSAeroGatewaySettingsDTO), "SMSAeroGatewaySettings")]
    [JsonKnownType(typeof(SMSRuGatewaySettingsDTO), "SMSRuGatewaySettings")]

    [JsonKnownType(typeof(TwilioSMSGatewaySettingsDTO), "TwilioSMSGatewaySettings")]
    public class SMSGatewaySettingsDTO : DTOModelAbs<SMSGatewaySettings>
    {
    }
}
