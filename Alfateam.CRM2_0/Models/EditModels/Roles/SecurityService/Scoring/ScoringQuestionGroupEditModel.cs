﻿using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Roles.SecurityService.Scoring;

namespace Alfateam.CRM2_0.Models.EditModels.Roles.SecurityService.Scoring
{
    public class ScoringQuestionGroupEditModel : EditModel<ScoringQuestionGroup>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
