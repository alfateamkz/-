using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.GetTypes
{
    public class GetTypesResponse
    {
        [Description("types")]
        public List<AttributeType> Types { get; set; } = new List<AttributeType>();
    }
}
