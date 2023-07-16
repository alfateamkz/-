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
    /// Вариант ответа с эмодзи
    /// </summary>
    public class EmojiQuestionOption : QuestionOption
    {
        public string Text { get; set; } = "";
        public string Emoji { get; set; } = "";
        //public List<EmojiQuestionOptionLocalization> Localizations { get; set; } = new List<EmojiQuestionOptionLocalization>();
    }
}
