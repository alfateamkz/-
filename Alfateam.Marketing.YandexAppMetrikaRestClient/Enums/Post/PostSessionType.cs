using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Post
{
    public enum PostSessionType
    {
        [Description("foreground")]
        Foreground = 1,
        [Description("background")]
        Background = 2
    }
}
