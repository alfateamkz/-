using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность просмотра
    /// </summary>
    public class Watch : AbsModel
    {
        public DateTime WatchedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Пользователь, который просмотрел
        /// Если WatchedBy == null, то просмотрел неавторизованный пользователь
        /// </summary>
        public User? WatchedBy { get; set; }
        public int? WatchedById { get; set; }



        /// <summary>
        /// Отпечаток браузера
        /// </summary>
        public string WatchedByFingerprint { get; set; }
    }
}
