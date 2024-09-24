using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность, описывающая причину, по которой пользователь забанен
    /// </summary>
    public class BanInfo : AbsModel
    {
        public BanType Type { get; set; } 
        public string Reason { get; set; }
        public DateTime BanBefore { get; set; } = DateTime.MaxValue;


    }
}
