using Alfateam.Core;
using Alfateam.Sales.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Scripting
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



        /// <summary>
        /// ID родительского блока, заполняется автоматически
        /// </summary>
        public int? SalesScriptBlockId { get; set; }
        /// <summary>
        /// ID скрипта продаж, частью которого является блок. Заполняется вручную
        /// </summary>
        public int SalesScriptId { get; set; }
    }
}
