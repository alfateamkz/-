﻿using Alfateam.Marketing.Models.Abstractions.MailingAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.MailingAccounts.Social
{
    public class VKMailingAccount : SocialMailingAccount
    {
        public string AuthToken { get; set; }
    }
}
