using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;


namespace Alfateam.CRM2_0.Models.Content.Tests
{
    /// <summary>
    /// Модель шкалы теста
    /// </summary>
    public class TestScale : AbsModel
    {
        public string Title { get; set; }
        public int MaximumScore { get; set; }
    }
}
