using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Conversation
{
    /// <summary>
    /// Модель конференции с клиентом
    /// </summary>
    public class CustomerConference : CustomerConversation
    {
        public string ConferenceURL { get; set; }
    }
}
