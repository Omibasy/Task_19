using System;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace Task_20.ViewModel
{
    class ListOfAnimals<T> :  INotifyCollectionChanged, IList

    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            try
            {
                CollectionChanged?.Invoke(this, e);
            }
            catch
            {
                return;
            }
        }

        readonly List<T> list = new List<T>();

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => true;

        public bool IsFixedSize => ((IList)list).IsFixedSize;

        public object SyncRoot => ((ICollection)list).SyncRoot;

        public bool IsSynchronized => ((ICollection)list).IsSynchronized;

        object IList.this[int index] { get => ((IList)list)[index]; set => ((IList)list)[index] = value; }

        public void Clear() => list.Clear();

        public bool Contains(T item) => list.Contains(item);

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator();

        public void RemoveAt(int index) => list.RemoveAt(index);

        public List<T> ToList()
        {
            List<T> values = new List<T>();

            Task.Run(() =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    values.Add(list[i]);
                }           
            }).Wait();

            return values;
        }

        public void ToListOfAnimals(List<T> values)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < values.Count; i++)
                {
                    list.Add(values[i]);
                }
            }).Wait();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Add(object value)
        {
            return ((IList)list).Add(value);
        }

        public bool Contains(object value)
        {
            return ((IList)list).Contains(value);
        }

        public int IndexOf(object value)
        {
            return ((IList)list).IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            ((IList)list).Insert(index, value);
        }

        public void Remove(object value)
        {
            ((IList)list).Remove(value);
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection)list).CopyTo(array, index);
        }
 
    }
}
