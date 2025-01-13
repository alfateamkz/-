using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages.Add
{
    public class AdImagesAddParamsBody
    {
        public List<AdImageAddItem> AdImages { get; set; } = new List<AdImageAddItem>();
    }
}
