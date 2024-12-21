using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.GetAttributes
{
    public class GetAttributesResponse
    {
        [Description("custom_attributes")]
        public List<AttributeModel> CustomAttributes { get; set; } = new List<AttributeModel>();

        [Description("system_attributes")]
        public List<AttributeModel> SystemAttributes { get; set; } = new List<AttributeModel>();
    }
}
