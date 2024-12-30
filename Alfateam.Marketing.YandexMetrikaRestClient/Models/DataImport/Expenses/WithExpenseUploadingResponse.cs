using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses
{
    public class WithExpenseUploadingResponse
    {
        [JsonProperty("uploading")]
        public ExpenseUploading Uploading { get; set; }
    }
}
