using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Sales.Scripting
{
    /// <summary>
    /// Модель блока скрипта продаж
    /// </summary>
    public class SalesScriptBlock : AbsModel
    {

        /// <summary>
        /// Текст фразы
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Тип блока
        /// </summary>
        public SalesScriptBlockType Type { get; set; } = SalesScriptBlockType.Intro;

        /// <summary>
        /// Разветвления скрипта
        /// </summary>
        public List<SalesScriptBlock> Nodes { get; set; } = new List<SalesScriptBlock>();
    }
}
