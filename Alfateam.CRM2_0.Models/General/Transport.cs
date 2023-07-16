using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель объекта транспорта
    /// </summary>
    public class Transport : AbsModel
    {
        /// <summary>
        /// Тип транспорта
        /// </summary>
        public TransportType Type { get; set; } = TransportType.Car;


        /// <summary>
        /// Название марки транспорта
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Название модели транспорта
        /// </summary>
        public string Model { get; set; }


        /// <summary>
        /// Год выпуска
        /// </summary>
        public int YearOfIssue { get; set; }

        
        /// <summary>
        /// Свойства, описывающие транспорт
        /// </summary>
        public List<TrasportProperty> Properties { get; set; } = new List<TrasportProperty>();
    }
}
