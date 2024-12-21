using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.FindAllExpenses
{
    public class FindAllExpensesResponse
    {
        [JsonProperty("uploadings")]
        public List<ExpenseUploading> Uploadings { get; set; } = new List<ExpenseUploading>();
    }
}
