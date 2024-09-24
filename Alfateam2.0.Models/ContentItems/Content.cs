using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.ContentItems
{
    /// <summary>
    /// Сущность форматированного контента
    /// </summary>
    public class Content : AbsModel
    {
        public List<ContentItem> Items { get; set; } = new List<ContentItem>();

       

        public bool AreSame(Content content)
        {
            if(Items.Count != content.Items.Count)return false;

            for(int i= 0; i < Items.Count; i++)
            {
                var thisItem = Items[i];
                var thatItem = content.Items[i];


            }


            return true;
        }
    }
}
