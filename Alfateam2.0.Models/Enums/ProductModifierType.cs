using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Enums
{
    /// <summary>
    /// Формат отображения модификатора товара
    /// </summary>
    public enum ProductModifierType
    {
        Color = 1, //Цвет
        Combobox = 2, //Выпадающий список
        CheckboxOrRadio = 3 //Галочки(если множественный выбор) или радиокнопки
    }
}
