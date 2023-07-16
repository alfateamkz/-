using Alfateam.Database.Abstraction;
using Alfateam.Database.Enums.CRM;
using Alfateam.Database.Models.CRM.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Orders {


    public class OrderModel : BaseModel {

        public string Title { get; set; }
        public string? Description { get; set; }
        public string? TSPath { get; set; } = "";

        public OrderStatus Status { get; set; } = OrderStatus.Active;

        public Client? Client { get; set; }
        public int? ClientId { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } = DateTime.Now.AddMonths(1);
        /// <summary>
        /// Перенесеный дедлайн в случае, если завален основный дедлайн
        /// </summary>
        public DateTime? ActualDeadline { get; set; }




        public double Price { get; set; }
        [NotMapped]
        public double Budget => BudgetItems.Where(o => !o.IsDeleted).Sum(o => o.Sum);
        public List<BudgetItem> BudgetItems { get; set; } = new List<BudgetItem>();
        public List<OrderStage> Stages { get; set; } = new List<OrderStage>();


        public void SetDefaultData() {
            BudgetItems = new List<BudgetItem> {
                new BudgetItem {
                    Title = "Оплата труда рабочих",
                },
                new BudgetItem {
                    Title = "Подоходный налог",
                }
            };


            var stage = new OrderStage() {
                Title = "Этап 1",
                Description = "Описание этапа 1",
            };
            stage.SetDefaultData();
            Stages.Add(stage);
        }

  

    }
}
