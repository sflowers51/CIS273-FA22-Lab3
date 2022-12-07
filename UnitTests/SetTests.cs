using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Set;

namespace UnitTests
{
    [TestClass]
    public class SetTests
    {
        //Size
        [TestMethod]
        public void Set1()
        {
            Set.ISet<int> set1 = new Set<int>();
            int tests = 5;
            for (int i = 0; i < tests; i++)
            {
                set1.Add(i);
            }
            Assert.AreEqual(tests, set1.Size);
        }

        //Contains
        [TestMethod]
        public void Set2()
        {
            Set.ISet<int> set1 = new Set<int>();
            int tests = 5;
            for (int i = 0; i < tests; i++)
            {
                set1.Add(i);
            }
            for (int i = 0; i < tests; i++)
            {
                Assert.IsTrue(set1.Contains(i));
            }
        }

        [TestMethod]
        public void Set3()
        {
            Set.ISet<int> set1 = new Set<int>();
            Set.ISet<int> set2 = new Set<int>();
            Set.ISet<int> set3 = new Set<int>();
            for (int i = 0; i < 100; i += 2)
            {
                set1.Add(i);
            }
            for (int i = 1; i < 100; i += 2)
            {
                set2.Add(i);
            }
            set3 = Set.Set<int>.Union(set1, set2);
            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(set3.Contains(i));
            }
        }

        [TestMethod]
        public void Set4()
        {
            Set.ISet<int> set1 = new Set<int>();
            Set.ISet<int> set2 = new Set<int>();
            Set.ISet<int> set3 = new Set<int>();
            for (int i = 0; i < 100; i += 2)
            {
                set1.Add(i);
            }
            for (int i = 1; i < 100; i += 2)
            {
                set2.Add(i);
            }
            set3 = Set.Set<int>.Union(set1, set2);
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.IsTrue(set1.Contains(i));
                    Assert.IsFalse(set2.Contains(i));
                }
                else
                {
                    Assert.IsTrue(set2.Contains(i));
                    Assert.IsFalse(set1.Contains(i));
                }
            }
        }

        [TestMethod]
        public void Set5()
        {
            Set.ISet<int> set1 = new Set<int>();
            Set.ISet<int> set2 = new Set<int>();
            Set.ISet<int> set3 = new Set<int>();
            for (int i = 0; i < 100; i += 2)
            {
                set1.Add(i);
            }
            for (int i = 1; i < 100; i += 2)
            {
                set2.Add(i);
            }
            set3 = Set.Set<int>.Intersection(set1, set2);
            Assert.AreEqual(0, set3.Size);
            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(set3.Contains(i));
            }
        }

        //Test Intersection
        [TestMethod]
        public void Set6()
        {
            Set.ISet<int> set1 = new Set<int>();
            Set.ISet<int> set2 = new Set<int>();
            Set.ISet<int> set3 = new Set<int>();
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    set1.Add(i);
                }
                if (i % 3 == 0)
                {
                    set2.Add(i);
                }
            }
            set3 = Set.Set<int>.Intersection(set1, set2);
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    Assert.IsTrue(set3.Contains(i));
                }
                else
                {
                    Assert.IsFalse(set3.Contains(i));
                }
            }
        }

        //Test Remove
        [TestMethod]
        public void Set7()
        {
            Set.ISet<int> set1 = new Set<int>();
            for (int i = 0; i < 100; i++)
            {
                set1.Add(i);
            }
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    set1.Remove(i);
                }
            }
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    Assert.IsFalse(set1.Contains(i));
                }
                else
                {
                    Assert.IsTrue(set1.Contains(i));
                }
            }
        }

        [TestMethod]
        public void Set8()
        {
            Set.ISet<int> set1 = new Set<int>();
            Set.ISet<int> set2 = new Set<int>();
            for (int i = 0; i < 100; i += 2)
            {
                set1.Add(i);
            }
            for (int i = 1; i < 100; i += 2)
            {
                set2.Add(i);
            }
            set1.Add(set2);
            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(set1.Contains(i));
            }
        }

        [TestMethod]
        public void Set9()
        {
            Set.ISet<int> set1 = new Set<int>();
            Set.ISet<int> set2 = new Set<int>();
            for (int i = 0; i < 100; i += 2)
            {
                set1.Add(i);
            }
            for (int i = 1; i < 100; i += 2)
            {
                set2.Add(i);
            }
            set1.Add(set2);
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 != 0)
                {
                    Assert.IsTrue(set2.Contains(i));
                }
                else
                {
                    Assert.IsFalse(set2.Contains(i));
                }
            }
        }

        [TestMethod]
        public void Set10()
        {
            Set.ISet<int> set1 = new Set<int>();
            Set.ISet<int> set2 = new Set<int>();
            Set.ISet<int> set3 = new Set<int>();
            for (int i = 0; i < 100; i += 2)
            {
                set1.Add(i);
            }
            for (int i = 1; i < 100; i += 2)
            {
                set2.Add(i);
            }
            set3 = Set.Set<int>.Union(set1, set2);
            set1.Add(set2);
            Assert.AreEqual(set3.Size, set1.Size);
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(set3.Contains(i), set1.Contains(i));
            }
        }

        [TestMethod]
        public void Set11()
        {
            Set.ISet<int> set1 = new Set<int>();
            Set.ISet<int> set2 = new Set<int>();
            for (int i = 0; i < 100; i++)
            {
                set1.Add(i);
            }
            for (int i = 1; i < 100; i += 2)
            {
                set2.Add(i);
            }
            set1.Remove(set2);
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.IsTrue(set1.Contains(i));
                }
                else
                {
                    Assert.IsFalse(set1.Contains(i));
                }
            }
        }
    }
}
