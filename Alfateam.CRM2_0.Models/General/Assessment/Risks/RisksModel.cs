using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Assessment.Risks
{
    /// <summary>
    /// Сущность реюзабельной модели рисков
    /// </summary>
    public class RisksModel : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public RisksModelType Type { get; set; }



        public List<RisksGroup> Groups { get; set; } = new List<RisksGroup>();
    }
}
