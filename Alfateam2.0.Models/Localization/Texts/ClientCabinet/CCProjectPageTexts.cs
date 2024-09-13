using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.ClientCabinet
{
    public class CCProjectPageTexts : LocalizableModel
    {


        public string ProjectInfo { get; set; } = "Информация о проекте";


        public string Milestones { get; set; } = "Этапы";
        public string MilestoneStatus { get; set; } = "Статус: ";
        public string MilestoneStatusInProgress { get; set; } = "В работе";
        public string MilestoneStatusCompleted { get; set; } = "Завершен";
        public string MilestoneStatusInWaiting { get; set; } = "В ожидании";


        public string ProjectTotalCost { get; set; } = "Стоимость проекта:";
        public string AlreadyPaidSum { get; set; } = "Оплачено:";
        public string SumRemainder { get; set; } = "Осталось оплатить:";

        public string Manager { get; set; } = "Менеджер:";
    }
}
