using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Goals
{
    public enum GoalFlag
    {
        [Description("basket")]
        Basket = 1,
        [Description("order")]
        Order = 2
    }
}
