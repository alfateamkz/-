using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients
{
    public enum PrivilegeEnum
    {
        [Description("EDIT_CAMPAIGNS")]
        EditCampaigns = 1,
        [Description("IMPORT_XLS")]
        ImportXLS = 2,
        [Description("TRANSFER_MONEY")]
        TransferMoney = 3,
    }
}
