using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alfateam.CRM2_0.Models.Content.Tests
{
    /// <summary>
    /// Модель категории теста
    /// </summary>
    public class TestCategory : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }




        public override string ToString()
        {
            return Title;
        }

        //TODO: доделать образовательные разделы в целом
    }
}
