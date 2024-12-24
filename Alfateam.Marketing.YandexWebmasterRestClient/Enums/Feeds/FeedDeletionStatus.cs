using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.Feeds
{
    public enum FeedDeletionStatus
    {
        [Description("OK")]
        Ok = 1,
        [Description("NOT_EXIST")]
        NotExist = 2,
    }
}
