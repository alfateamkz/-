using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger
{
    /// <summary>
    /// Базовая модель чата
    /// </summary>
    public abstract class Chat : AbsModel
    {
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
