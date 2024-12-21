using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.CreateProducts
{
    public class CreateProductsBody
    {
        [Description("attributes")]
        public List<AttributeModel> Attributes { get; set; } = new List<AttributeModel>();

        [Description("items")]
        public List<ListItem> Items { get; set; } = new List<ListItem>();
    }
}
