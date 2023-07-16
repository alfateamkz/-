using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Content.Tests;
using Alfateam.CRM2_0.Models.Enums.Content.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Enums;

namespace Alfateam.CRM2_0.Models.Content.Tests
{
    /// <summary>
    /// Модель теста
    /// </summary>
    public class Test : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PassingTimeInMinutes { get; set; } = 2;


        public TestType Type { get; set; } = TestType.Simple;
        public List<TestScale> Scales { get; set; } = new List<TestScale>();

        public string MainTags { get; set; } = "";
        public string SecondaryTags { get; set; } = "";


        public TestCategory Category { get; set; }
        public int CategoryId { get; set; }



        public string? IconImgPath { get; set; } = "";
        public string ImgPath { get; set; } = "";
        public string? ResultImgPath { get; set; } = "";
        public string VideoPath { get; set; } = "";


        public List<Question> Questions { get; set; } = new List<Question>();
        public List<TestResult> Results { get; set; } = new List<TestResult>();


      



        public bool ShowScores { get; set; }
        public int Watches { get; set; }



        /// <summary>
        /// Метод для тестов типа  TestType.Simple или  TestType.Scaled
        /// </summary>
        public TestResult GetTestResult(double scores)
        {
            var eqResults = Results.Where(o => o.ConditionType == TestResultConditionType.Equal);
            foreach(var res in eqResults)
            {
                if (res.IsThisResult(scores)) return res;
            }
            var otherResults = Results.Where(o => o.ConditionType != TestResultConditionType.Equal);
            foreach (var res in otherResults)
            {
                if (res.IsThisResult(scores)) return res;
            }
            return Results.FirstOrDefault(o => o.ConditionType == TestResultConditionType.NoCondition);
        }

        /// <summary>
        /// Метод для тестов типа TestType.ScaledWithConditions
        /// </summary>
        public List<TestResult> GetTestResults(Dictionary<TestScale,int> scores) {
            var results = new List<TestResult>();

            foreach(var score in scores) {

                TestResult result = null;

                var scaleResults = Results.Where(o => o.ScaleId == score.Key.Id);

                var eqResults = scaleResults.Where(o => o.ConditionType == TestResultConditionType.Equal);
                foreach (var res in eqResults) {
                    if (res.IsThisResult(score.Value)) {
                        result = res;
                        break;
                    }
                }
                var otherResults = scaleResults.Where(o => o.ConditionType != TestResultConditionType.Equal);
                foreach (var res in otherResults) {
                    if (res.IsThisResult(score.Value)) {
                        result = res;
                        break;
                    }
                }

                if(result == null)
                {
                    result = scaleResults.FirstOrDefault(o => o.ConditionType == TestResultConditionType.NoCondition);
                }
                if(result != null)
                {
                    results.Add(result);
                }
            }

            return results;
        }
    }
}
