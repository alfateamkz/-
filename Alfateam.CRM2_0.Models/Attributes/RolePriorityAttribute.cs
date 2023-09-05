using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Attributes
{
    /// <summary>
    /// Атрибут, указывающий на приоритет роли 
    /// Используется в перечислении UserRole
    /// По идее мы бы могли использовать значения enum, но если понадобится изменить приоритет,
    /// то придется и в БД менять значения
    /// </summary>
    internal class RolePriorityAttribute : Attribute
    {
        public readonly int Priority;
        public RolePriorityAttribute(int priority) 
        {
            Priority = priority;
        }

    }
}
