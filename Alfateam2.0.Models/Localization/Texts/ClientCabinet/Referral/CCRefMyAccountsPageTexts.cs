using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral
{
    public class CCRefMyAccountsPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Мои счета";
        public string AvailableToWithdraw { get; set; } = "Доступно для вывода: {sum} {curr_code}";
    }
}
