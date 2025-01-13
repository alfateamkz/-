﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.SmartAdTargets
{
    public enum SmartAdTargetsMethod
    {
        [Description("add")]
        Add = 1,
        [Description("delete")]
        Delete = 2,
        [Description("get")]
        Get = 3,
        [Description("resume")]
        Resume = 4,
        [Description("setBids")]
        SetBids = 5,
        [Description("suspend")]
        Suspend = 6,
        [Description("update")]
        Update = 7,
    }
}
