using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCProjectPageTexts : LocalizableModel
    {

        [Description("Заголовок: Информация о проекте")]
        public string ProjectInfo { get; set; } = "Информация о проекте";


        [Description("Этапы")]
        public string Milestones { get; set; } = "Этапы";
        [Description("Статус:")]
        public string MilestoneStatus { get; set; } = "Статус: ";
        [Description("В работе")]
        public string MilestoneStatusInProgress { get; set; } = "В работе";
        [Description("Завершен")]
        public string MilestoneStatusCompleted { get; set; } = "Завершен";
        [Description("В ожидании")]
        public string MilestoneStatusInWaiting { get; set; } = "В ожидании";



        [Description("Стоимость проекта:")]
        public string ProjectTotalCost { get; set; } = "Стоимость проекта:";
        [Description("Оплачено:")]
        public string AlreadyPaidSum { get; set; } = "Оплачено:";
        [Description("Осталось оплатить:")]
        public string SumRemainder { get; set; } = "Осталось оплатить:";

        [Description("Менеджер:")]
        public string Manager { get; set; } = "Менеджер:";
    }
}
