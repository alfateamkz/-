using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Content.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alfateam.CRM2_0.Models.Content.Tests
{
    /// <summary>
    /// Модель результата теста
    /// </summary>
    public class TestResult : AbsModel
    {
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";




        /// <summary>
        /// Шкала теста (в случае если тест со шкалами)
        /// </summary>
        public TestScale? Scale { get; set; }
        public int? ScaleId { get; set; }


        public bool IsNegativeResult { get; set; }

        public string ImgPath { get; set; } = "";
        public string VideoPath { get; set; } = "";



        /// <summary>
        /// Кол-во файлов в инпуте. Задается на фронте.
        /// Если > 0 то грузим файлы на серваке, прилетаемые в запросе 
        /// </summary>
        [NotMapped]
        public int FilesFromFrontend { get; set; }


        public TestResultConditionType ConditionType { get; set; }
        public double FirstValue { get; set; }
        /// <summary>
        /// Заполняется в случае, если ConditionType == Between
        /// </summary>
        public double SecondValue { get; set; }



        /// <summary>
        /// Чтобы с фронта забить айдишники
        /// </summary>
        [NotMapped]
        public List<int> NeedToHandleItemsIds { get; set; } = new List<int>();



       

        public bool IsThisResult(double score)
        {

            switch (ConditionType)
            {
                case TestResultConditionType.Equal:
                    return FirstValue == score;
                case TestResultConditionType.Between:
                    return FirstValue <= score && SecondValue >= score;
                case TestResultConditionType.From:
                    return FirstValue < score;
                case TestResultConditionType.To:
                    return FirstValue > score;
            }
            return false;
        }
        
        public bool IsThisResult(double score,int testScaleId) {

            if (ScaleId != testScaleId) return false;
            return IsThisResult(score);
        }
    }
}
