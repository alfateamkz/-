using Alfateam.Core;
using Alfateam.Telephony.Models.General.AudioRecords;
using Alfateam.Telephony.Models.SMS;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<AudioRecord>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FileAudioRecord), "FileAudioRecord")]
    [JsonKnownType(typeof(ReadingAudioRecord), "ReadingAudioRecord")]
    public class AudioRecord : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
