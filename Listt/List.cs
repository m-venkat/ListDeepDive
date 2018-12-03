using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyCollections
{
    public class List<T> : IEnumerable<T>, IEnumerable
    {
        private T[] _items = new T[4];//Initial capacity 4
        private int _size = 0;
        public List()
        {
            
        }

        public T this[int index]
        {
          get
          {
              if ((uint) index >= (uint) this._items.Length)
                  throw new ArgumentOutOfRangeException();
              else
                return this._items[index];
            }
            set
            {
                if ((uint)index >= (uint)this._items.Length)
                    throw new ArgumentOutOfRangeException();
                this._items[index] = value;
            }
        }

        public int Count()
        {
            return _size;
        }

       

        public void Add(T item)
        {
            if (_size >= _items.Length)
            {
                T[] destinArray = new T[_size*2];
                Array.Copy(_items,destinArray,_size);
                _items = destinArray;
                _items[_size] = item;
                _size++;
            }
            else
            {
                _items[_size] = item;
                _size++;
            }
        }

        public object Count(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(_items, item, 0);
            if (index > 0)
            {
                Array.Copy(_items, index+1, _items,index, _size-index);
            }

            this._size--;

        }

        public T FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0;i<=_size-1;i++)
                 yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
