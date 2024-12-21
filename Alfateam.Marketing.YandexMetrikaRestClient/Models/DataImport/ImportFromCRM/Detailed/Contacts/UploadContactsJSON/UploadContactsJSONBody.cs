using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Contacts.UploadContactsJSON
{
    public class UploadContactsJSONBody
    {
        [JsonProperty("contacts")]
        public List<ContactRow> Contacts { get; set; } = new List<ContactRow>();
    }
}
