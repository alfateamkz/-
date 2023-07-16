using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Triggero.Models.Enums
{
    /// <summary>
    /// Тип теста
    /// </summary>
    public enum TestType 
    {
        Simple = 1, //Обычный
        Scaled = 2, //Со шкалами (обычный)
        ScaledWithConditions = 3, //Со шкалами (с условиями)
    }
}
