using Alfateam.CRM2_0.Models.Abstractions.Content.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Tests.QuestionOptions
{
    /// <summary>
    /// Вариант ответа с картинкой
    /// </summary>
    public class PictureQuestionOption : QuestionOption
    {
        public string ImgPath { get; set; } = "";
    }
}
