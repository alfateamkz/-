using Alfateam.CRM2_0.Models.Abstractions.Content.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Content.Tests.Questions
{
    /// <summary>
    /// Обычный вопрос с картинкой
    /// </summary>
    public class SimplePicturedQuestion : Question
    {
        public string ImgPath { get; set; }
       // public List<SimpleQuestionOption> Options { get; set; } = new List<SimpleQuestionOption>();
    }
}
