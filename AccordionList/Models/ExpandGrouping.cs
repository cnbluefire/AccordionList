using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionList.Models
{
    public class ExpandGrouping<TKey, TElement> : ObservableCollection<TElement>
    {
        private List<TElement> _items = new List<TElement>();
        private TKey _key;
        private bool _expand;

        public ExpandGrouping(IGrouping<TKey, TElement> group)
        {
            this._key = group.Key;

            foreach (var item in group)
            {
                _items.Add(item);
            }
        }

        public TKey Key => _key;
        public bool Expand
        {
            get => _expand;
            set
            {
                _expand = value;
                UpdateExpand();
            }
        }

        private void UpdateExpand()
        {
            if (Expand)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    base.InsertItem(i, _items[i]);
                }
            }
            else
            {
                _items = this.ToList();
                base.ClearItems();
            }
        }

        protected override void ClearItems()
        {
            if (Expand)
            {
                base.ClearItems();
            }
            else
            {
                _items.Clear();
            }
        }

        protected override void InsertItem(int index, TElement item)
        {
            if (Expand)
            {
                base.InsertItem(index, item);
            }
            else
            {
                _items.Insert(index, item);
            }
        }

        protected override void MoveItem(int oldIndex, int newIndex)
        {
            if (Expand)
            {
                base.MoveItem(oldIndex, newIndex);
            }
            else
            {
                var item = _items[oldIndex];
                _items[oldIndex] = _items[newIndex];
                _items[newIndex] = item;
            }
        }

        protected override void RemoveItem(int index)
        {
            if (Expand)
            {
                base.RemoveItem(index);
            }
            else
            {
                _items.RemoveAt(index);
            }
        }

        protected override void SetItem(int index, TElement item)
        {
            if (Expand)
            {
                base.SetItem(index, item);
            }
            else
            {
                _items[index] = item;
            }
        }

    }

}
