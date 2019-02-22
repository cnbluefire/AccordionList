using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionList.Models
{
    public class ExpandGroupingCollection<TKey, TElement> : ObservableCollection<ExpandGrouping<TKey, TElement>>
    {
        public ExpandGroupingCollection(IEnumerable<IGrouping<TKey, TElement>> groups)
        {
            foreach (var group in groups)
            {
                var item = new ExpandGrouping<TKey, TElement>(group);
                this.Add(item);
            }
        }
    }

}
