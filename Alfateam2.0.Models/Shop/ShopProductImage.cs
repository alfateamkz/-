using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Shop
{
    /// <summary>
    /// Сущность картинки товара
    /// </summary>
    public class ShopProductImage : AbsModel
    {
        public string ImgPath { get; set; }
    }
}
