using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alfateam.CRM2_0.Models.Content.Tests
{
    /// <summary>
    /// Модель значения конкретной шкалы для варианта ответа
    /// </summary>
    public class QuestionOptionScaleInfo : AbsModel 
    {
        public int Score { get; set; }


        public TestScale Scale { get; set; }
        public int ScaleId { get; set; }
    }
}
