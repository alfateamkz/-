﻿using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Contacts
{
    public class ContactCategory : AbsModel
    {
        public string Title { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
