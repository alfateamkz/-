using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCMyProjectsPageTexts : LocalizableModel
    {
        [Description("Заголовок: Мои проекты")]
        public string Header { get; set; } = "Мои проекты";


        [Description("Дата договора: {dd.MM.yyyy}")]
        public string OrderDate { get; set; } = "Дата договора: {dd.MM.yyyy}";

        [Description("Выполним до: {dd.MM.yyyy}")]
        public string OrderDeadline { get; set; } = "Выполним до: {dd.MM.yyyy}";

        [Description("Завершен")]
        public string StatusCompleted { get; set; } = "Завершен";
        [Description("В работе")]
        public string StatusInProgress{ get; set; } = "В работе";
    }
}
