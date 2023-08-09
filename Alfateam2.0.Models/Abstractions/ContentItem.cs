using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{
    /// <summary>
    /// Сущность блока контента
    /// </summary>
    public abstract class ContentItem : AbsModel
    {
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();

        public virtual bool AreSame(ContentItem other)
        {
            if(this.GetType() != other.GetType()) return false;
            if(this.Guid != other.Guid) return false;
            if(this.Id != other.Id) return false;

            return true;
        }
    }
}
