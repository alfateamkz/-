using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Тип раздела, к которому нужен доступ
    /// </summary>
    public enum ContentAccessModelType
    {
        All = 1,
        Posts = 2,
        MassMediaPosts = 3,
        Portfolio = 4,
        Compliance = 5,
        Events = 6
    }
}
