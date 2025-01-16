using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductFeedUploadInputMethod
    {
        [Description("Manual Upload")]
        ManualUpload = 1,
        [Description("Server Fetch")]
        ServerFetch = 2,
        [Description("Google Sheets Fetch")]
        GoogleSheetsFetch = 3,
        [Description("Reupload Last File")]
        ReuploadLastFile = 4,
        [Description("User initiated server fetch")]
        UserInitiatedServerFetch = 5,
    }
}
