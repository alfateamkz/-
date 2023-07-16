using Alfateam.Database.Abstraction;
using Alfateam.Database.Enums.CRM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Orders {

    public class OrderStage : BaseModel {

        public string Title { get; set; }
        public string? Description { get; set; }


        public OrderStageStatus Status { get; set; } = OrderStageStatus.NotStarted;

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } = DateTime.Now.AddMonths(1);

        /// <summary>
        /// Перенесеный дедлайн в случае, если завален основный дедлайн
        /// </summary>
        public DateTime? ActualDeadline { get; set; }


        public double Price { get; set; }
        public List<BudgetItem> BudgetItems { get; set; } = new List<BudgetItem>();
    


        public List<StageHumanResource> HumanResources { get; set; } = new List<StageHumanResource>();
        public List<StageMaterialResource> MaterialResources { get; set; } = new List<StageMaterialResource>();


        public void SetDefaultData() {
            BudgetItems.Add(new BudgetItem {
                Title = "Затраты на этап",
            });
        }
    }
}
