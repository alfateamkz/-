using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCMyProjectsPageTexts : LocalizableModel
    {
        public string Header { get; set; } = "Мои проекты";


        public string OrderDate { get; set; } = "Дата договора: {dd.MM.yyyy}";
        public string OrderDeadline { get; set; } = "Выполним до: {dd.MM.yyyy}";
        public string StatusCompleted { get; set; } = "Завершен";
        public string StatusInProgress{ get; set; } = "В работе";
    }
}
