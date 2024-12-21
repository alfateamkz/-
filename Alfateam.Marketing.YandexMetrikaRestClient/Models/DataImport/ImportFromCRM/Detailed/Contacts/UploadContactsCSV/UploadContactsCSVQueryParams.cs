using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Contacts.UploadContacts
{
    public class UploadContactsCSVQueryParams
    {
        [JsonProperty("columns_mapping")]
        public string ColumnsMapping { get; set; }

        [JsonProperty("merge_mode")]
        public MergeMode MergeMode { get; set; }

        [JsonProperty("delimiter_type")]
        public DelimiterType DelimiterType { get; set; }
    }
}
