using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Markup;

namespace Set
{
    public class Set<T> : ISet<T>
    {
        private HashSet<T> hashSet;

        public Set()
        {
            hashSet = new HashSet<T>();
        }

        public int Size => hashSet.Count;

        public List<T> Elements
        {
            get
            {
                
                return Elements;
            }
        }
            
        
        public void Add(ISet<T> s)
        {
            foreach(var item in s)
            {
                hashSet.Add(item);
            }
        }

        public void Add(T value)
        {
            hashSet.Add(value);
        }

        public bool Contains(T value)
        {
            foreach(var item in hashSet)
            {
                if(item.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return hashSet.GetEnumerator();
        }

        public void Remove(ISet<T> s)
        {
            throw new NotImplementedException();
        }

        public void Remove(T value)
        {
            foreach(var item in hashSet)
            {
                if (value.Equals(item))
                {
                    hashSet.Remove(item);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Set<T> Union(ISet<T> set1, ISet<T> set2)
        {
            return null;
        }

        public static Set<T> Intersection(ISet<T> set1, ISet<T> set2)
        {
            throw new NotImplementedException();
        }

    }
}
