using Alfateam.Telephony.API.Models.DTO.General.AudioRecords;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.General.AudioRecords;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Telephony.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<AudioRecordDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FileAudioRecordDTO), "FileAudioRecord")]
    [JsonKnownType(typeof(ReadingAudioRecordDTO), "ReadingAudioRecord")]
    public class AudioRecordDTO : DTOModelAbs<AudioRecord>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
