using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Security
{
    /// <summary>
    /// Использованные авторизационные данные
    /// Нужно, чтобы пользователь не мог повторно использовать пароль при смене
    /// Например: человек меняет пароль после компрометации
    /// </summary>
    public class UsedCredential : AbsModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
