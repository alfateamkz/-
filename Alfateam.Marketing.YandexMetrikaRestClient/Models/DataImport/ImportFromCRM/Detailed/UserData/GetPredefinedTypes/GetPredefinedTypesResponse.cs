using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.GetPredefinedTypes
{
    public class GetPredefinedTypesResponse
    {
        [Description("types")]
        public List<AttributeType> Types { get; set; } = new List<AttributeType>();
    }
}
