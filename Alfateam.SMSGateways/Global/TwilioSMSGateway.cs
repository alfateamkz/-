﻿using Alfateam.SMSGateways.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SMSGateways.Global
{
    public class TwilioSMSGateway : ISMSGateway
    {
        public SentSmsStatus Send(string phone, string message)
        {
            throw new NotImplementedException();
        }
    }
}
