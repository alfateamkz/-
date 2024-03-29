﻿using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.TestTasks
{
    /// <summary>
    /// Модель тестового задания для кандидата
    /// </summary>
    public class CandidateTestTask : AbsModel
    {
        //public Candidate Candidate { get; set; }
        //public int CandidateId { get; set; } //Задача назначается только в рамках собеседования, см. сущность CandidateInterview

        public CandidateTestTaskStatus Status { get; set; } = CandidateTestTaskStatus.Active;

        public DateTime Deadline { get; set; }

        public string TaskDetails { get; set; }

        public CandidateTestTaskAnswer? Answer { get; set; }
        public int? AnswerId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        [JsonIgnore]
        public int CandidateInterviewId { get; set; }

    }
}
