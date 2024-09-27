using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Enums
{
    public enum DocumentsAccessType
    {
        OnlyUserDepartment = 1,
        OnlyUserDepartmentAndSubsidiary = 2,
        OnlySelectedDepartments = 3,
        AllDepartments = 4,
    }
}
