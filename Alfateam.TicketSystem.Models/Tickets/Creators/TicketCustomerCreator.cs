﻿using Alfateam.TicketSystem.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models.Tickets.Creators
{
    public class TicketCustomerCreator : TicketCreator
    {
        public string Identifier { get; set; }
    }
}
