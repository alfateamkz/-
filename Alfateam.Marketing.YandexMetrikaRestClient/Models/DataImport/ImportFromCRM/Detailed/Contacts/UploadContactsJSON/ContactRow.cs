using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Contacts.UploadContactsJSON
{
    public class ContactRow
    {
        [JsonProperty("uniq_id")]
        public string UniqId { get; set; }

        [JsonProperty("attribute_values")]
        public List<List<string>> AttributeValues { get; set; } = new List<List<string>>();

        [JsonProperty("birth_date")]
        public DateOnly BirthDate { get; set; }

        [JsonProperty("client_ids")]
        public List<long> ClientIds { get; set; } = new List<long>();

        [JsonProperty("create_date_time")]
        public DateTime CreateDateTime { get; set; }

        [JsonProperty("emails")]
        public List<string> Emails { get; set; } = new List<string>();

        [JsonProperty("emails_md5")]
        public List<string> EmailsMD5 { get; set; } = new List<string>();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phones")]
        public List<string> Phones { get; set; } = new List<string>();

        [JsonProperty("phones_md5")]
        public List<string> PhonesMD5 { get; set; } = new List<string>();

        [JsonProperty("update_date_time")]
        public DateTime UpdateDateTime { get; set; }

        [JsonProperty("user_ids")]
        public List<string> UserIds { get; set; } = new List<string>();
    }
}
