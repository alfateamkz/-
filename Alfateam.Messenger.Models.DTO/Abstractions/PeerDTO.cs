using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Peers;
using Alfateam.Messenger.Models.Peers;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<PeerDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamExtMessengerPeerDTO), "AlfateamExtMessengerPeer")]
    [JsonKnownType(typeof(AlfateamMessengerPeerDTO), "AlfateamMessengerPeer")]
    [JsonKnownType(typeof(ExtMessengerPeerDTO), "ExtMessengerPeer")]
    public class PeerDTO : DTOModelAbs<Peer>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
