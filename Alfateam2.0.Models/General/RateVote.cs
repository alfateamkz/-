using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Реюзабельная сущность оценочного фидбека
    /// Например лайки и дизлайки
    /// </summary>
    public class RateVote : AbsModel
    {
        public DateTime SetAt { get; set; }

        /// <summary>
        /// Пользователь, который оценил
        /// Если SetBy == null, то оценил неавторизованный пользователь
        /// </summary>
        public User? SetBy { get; set; }
        /// <summary>
        /// Отпечаток браузера
        /// </summary>
        public string SetByFingerprint { get; set; }
    }
}
