using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    /// <summary>
    /// Модель аккаунта в соц.сети\мессенджере\эл.почте
    /// </summary>
    public class Account : AbsModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
