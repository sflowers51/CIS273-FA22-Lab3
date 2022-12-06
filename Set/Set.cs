using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
{
    public class Set<T> : ISet<T>
    {
        private HashSet<T> hashSet;

        public Set()
        {
            hashSet = new HashSet<T>(); 
        }

        public int Size => throw new NotImplementedException();

        public List<T> Elements
        {
            get
            {
                // do work

                //return result
                return null;
            }
        }
            

        public void Add(ISet<T> s)
        {
            foreach(var item in s)
            {
                this.Add(item);
            }
        }

        public void Add(T value)
        {
            hashSet.Add(value);
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Set<T> Union(Set<T> set1, Set<T> set2)
        {
            return null;
        }

        public static Set<T> Intersection(Set<T> set1, Set<T> set2)
        {

        }
    }
}
