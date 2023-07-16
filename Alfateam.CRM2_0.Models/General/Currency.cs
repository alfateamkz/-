using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель валюты
    /// </summary>
    public class Currency : AbsModel
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public CurrencyType Type { get; set; } = CurrencyType.Fiat;
    }
}
