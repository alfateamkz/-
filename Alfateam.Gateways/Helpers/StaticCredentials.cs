﻿using Alfateam.Gateways.Models.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Gateways.Helpers
{
    public static class StaticCredentials
    {
        public static readonly EmailCredentials OFFICIAL_EMAIL = new EmailCredentials("official@alfateam.co", "K!68y53eYFHz", "Alfateam corp.");
        public static readonly EmailCredentials SUPPORT_EMAIL = new EmailCredentials("support@alfateam.co", "vHJ9757%NAwg", "Alfateam corp. support");
        public static readonly EmailCredentials VERIFICATION_EMAIL = new EmailCredentials("verification@alfateam.co", "QkZKu2IbLa&6", "Alfateam corp. verification");
        public static readonly EmailCredentials RESTORE_EMAIL = new EmailCredentials("restore@alfateam.co", "t&VNA5B9NFNV", "Alfateam corp. restore");
        public static readonly EmailCredentials NOTIFICATIONS_EMAIL = new EmailCredentials("notifications@alfateam.co", "el5oak88Fc&C", "Alfateam corp. notifications");

        public static readonly SMSCredentials OFFICIAL_SMS = new SMSCredentials();
        public static readonly SMSCredentials SUPPORT_SMS = new SMSCredentials();
        public static readonly SMSCredentials RESTORE_SMS = new SMSCredentials();
        public static readonly SMSCredentials NOTIFICATIONS_SMS = new SMSCredentials();
    }
}
