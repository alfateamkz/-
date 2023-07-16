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
    [JsonConverter(typeof(JsonKnownTypesConverter<Question>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(EmojiQuestion), "EmojiQuestion")]
    [JsonKnownType(typeof(PictureQuestion), "PictureQuestion")]
    [JsonKnownType(typeof(SimplePicturedQuestion), "SimplePicturedQuestion")]
    [JsonKnownType(typeof(SimpleQuestion), "SimpleQuestion")]
    public class Question : AbsModel
    {
        public Question()
        {

        }

        [JsonIgnore]
        public int TestId { get; set; }

        public string Text { get; set; } = "";

        public int Number { get; set; } = 1;

       

        public List<QuestionOption> Options { get; set; } = new List<QuestionOption>();

        public string Discriminator { get; set; }


        /// <summary>
        /// Кол-во файлов в инпуте. Задается на фронте.
        /// Если > 0 то грузим файлы на серваке, прилетаемые в запросе 
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public int FilesFromFrontend { get; set; }


     

        public bool MultipleAnswers { get; set; }
    }
}
