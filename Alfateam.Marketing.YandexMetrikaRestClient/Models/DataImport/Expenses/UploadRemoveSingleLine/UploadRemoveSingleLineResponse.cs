using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.UploadRemoveSingleLine
{
    public class UploadRemoveSingleLineResponse
    {
        [JsonProperty("uploading")]
        public ExpenseUploading Uploading { get; set; }
    }
}
