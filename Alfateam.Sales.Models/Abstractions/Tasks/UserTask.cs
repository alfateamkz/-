using Alfateam.Core;
using Alfateam.Sales.Models.BusinessProposals.Placeholders;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Tasks;
using Alfateam.Sales.Models.Tasks.CompletionCheck;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Abstractions.Tasks
{

    [JsonConverter(typeof(JsonKnownTypesConverter<UserTask>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(SimpleUserTask), "SimpleUserTask")]
    [JsonKnownType(typeof(WithAmountUserTask), "WithAmountUserTask")]
    public class UserTask : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }




        public User TaskFor { get; set; }
        public int TaskForId { get; set; }




        public string Title { get; set; }
        public string? Description { get; set; }





        public List<MarkedAsCompleted> MarkedAsCompleted { get; set; } = new List<MarkedAsCompleted>();
        public List<TaskCompletionCheckResult> CompletionCheckResults { get; set; } = new List<TaskCompletionCheckResult>();


        public UserTaskStatus Status { get; set; } = UserTaskStatus.Active;





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }



        public bool IsDeadlinePassed()
        {
            if(this is SimpleUserTask simpleTask)
            {
                return simpleTask.EndDate < DateTime.UtcNow;
            }
            else if (this is WithAmountUserTask withAmountTask)
            {
                return withAmountTask.EndDate < DateTime.UtcNow;
            }

            throw new NotImplementedException();    
        }
    }
}
