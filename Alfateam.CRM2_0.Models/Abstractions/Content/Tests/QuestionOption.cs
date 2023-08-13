using Alfateam.CRM2_0.Models.Content.Tests;
using Alfateam.CRM2_0.Models.Content.Tests.QuestionOptions;
using Alfateam.CRM2_0.Models.Content.Tests.Questions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Alfateam.CRM2_0.Models.Abstractions.Content.Tests
{
    [JsonConverter(typeof(JsonKnownTypesConverter<QuestionOption>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(EmojiQuestionOption), "EmojiQuestionOption")]
    [JsonKnownType(typeof(PictureQuestionOption), "PictureQuestionOption")]
    [JsonKnownType(typeof(SimplePicturedQuestion), "SimplePicturedQuestion")]
    [JsonKnownType(typeof(SimpleQuestionOption), "SimpleQuestionOption")]
    public class QuestionOption : AbsModel
    {

        public QuestionOption()
        {

        }


        /// <summary>
        /// Используется, если  Test.HasMultipleScoreScales == false
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// Используется, если  Test.HasMultipleScoreScales == true
        /// </summary>
        public List<QuestionOptionScaleInfo> ScaleScoreInfos { get; set; } = new List<QuestionOptionScaleInfo>();


        public string Discriminator { get; set; }





        /// <summary>
        /// Теги для что нужно проработать (только квиза при обучении)
        /// </summary>
        public string? Tags { get; set; }




        /// <summary>
        /// Кол-во файлов в инпуте. Задается на фронте.
        /// Если > 0 то грузим файлы на серваке, прилетаемые в запросе 
        /// </summary>
        [NotMapped]
        public int FilesFromFrontend { get; set; }
    }
}
