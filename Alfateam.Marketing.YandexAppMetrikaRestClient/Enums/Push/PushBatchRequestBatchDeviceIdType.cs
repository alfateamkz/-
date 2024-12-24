using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Push
{
    public enum PushBatchRequestBatchDeviceIdType
    {
        [Description("appmetrica_device_id")]
        AppmetricaDeviceId = 1,
        [Description("ios_ifa")]
        iOSIFA = 2,
        [Description("google_aid")]
        GoogleAID = 3,
        [Description("android_push_token")]
        AndroidPushToken = 4,
        [Description("ios_push_token")]
        iOSPushToken = 5,
        [Description("huawei_push_token")]
        HuaweiPushToken = 6,
        [Description("huawei_oaid")]
        HuaweiOAID = 7,
    }
}
