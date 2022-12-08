using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TextualAnalysisTests
    {
        //Textual Analysis
        #region
        //Test stop words
        [TestMethod]
        public void TextualAnalysis1a()
        {
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequenciesFromFile("../../../Data/small.txt", true);
            Assert.IsFalse(result.ContainsKey("a"));
            Assert.IsFalse(result.ContainsKey("always"));
            Assert.IsFalse(result.ContainsKey("above"));
            Assert.IsFalse(result.ContainsKey("across"));
            Assert.IsFalse(result.ContainsKey("after"));
            Assert.IsFalse(result.ContainsKey("both"));
            Assert.IsFalse(result.ContainsKey("he"));
            Assert.IsFalse(result.ContainsKey("me"));
            Assert.IsFalse(result.ContainsKey("own"));
            Assert.IsFalse(result.ContainsKey("put"));
            Assert.IsFalse(result.ContainsKey("she"));
            Assert.IsFalse(result.ContainsKey("this"));
            Assert.IsFalse(result.ContainsKey("you"));
            Assert.IsTrue(result.ContainsKey("light"));
        }

        [TestMethod]
        public void TextualAnalysis1b()
        {
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequenciesFromFile("../../../Data/small.txt", false);
            Assert.IsTrue(result.ContainsKey("a"));
            Assert.IsTrue(result.ContainsKey("always"));
            Assert.IsTrue(result.ContainsKey("above"));
            Assert.IsTrue(result.ContainsKey("across"));
            Assert.IsTrue(result.ContainsKey("after"));
            Assert.IsTrue(result.ContainsKey("both"));
            Assert.IsTrue(result.ContainsKey("he"));
            Assert.IsTrue(result.ContainsKey("me"));
            Assert.IsTrue(result.ContainsKey("own"));
            Assert.IsTrue(result.ContainsKey("put"));
            Assert.IsTrue(result.ContainsKey("she"));
            Assert.IsTrue(result.ContainsKey("this"));
            Assert.IsTrue(result.ContainsKey("you"));
            Assert.IsTrue(result.ContainsKey("light"));
        }

        [TestMethod]
        public void TextualAnalysis2()
        {
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequenciesFromFile("../../../Data/had.txt", false);
            Assert.AreEqual(4, result.GetValueOrDefault("had"));
        }

        //Test Case sensitivity
        [TestMethod]
        public void TextualAnalysis3()
        {
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequenciesFromFile("../../../Data/small.txt", true);
            Dictionary<string, int> result2 = TextualAnalysis.TextualAnalysis.ComputeWordFrequenciesFromFile("../../../Data/small_upper.txt", true);
            Assert.AreEqual(result.Count, result2.Count);
            var keys = result.Keys;
            foreach (var key in keys)
            {
                Assert.AreEqual(result.GetValueOrDefault(key), result2.GetValueOrDefault(key));
            }
        }

        //Test Case sensitivity without removing stop words
        [TestMethod]
        public void TextualAnalysis4()
        {
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequenciesFromFile("../../../Data/small.txt", true);
            Dictionary<string, int> result2 = TextualAnalysis.TextualAnalysis.ComputeWordFrequenciesFromFile("../../../Data/small_upper.txt", true);
            Assert.AreEqual(result.Count, result2.Count);
            var keys = result.Keys;
            foreach (var key in keys)
            {
                Assert.AreEqual(result.GetValueOrDefault(key), result2.GetValueOrDefault(key));
            }
        }

        //Test the default false
        [TestMethod]
        public void TextualAnalysis5a()
        {
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequencies("How much wood would a wood chuck chuck if a wood chuck could chuck wood?");

            Assert.AreEqual(result.GetValueOrDefault("wood"), 4);
            Assert.AreEqual(result.GetValueOrDefault("chuck"), 4);
            Assert.AreEqual(result.GetValueOrDefault("much"), 1);
            Assert.AreEqual(result.GetValueOrDefault("how"), 1);
            Assert.AreEqual(result.GetValueOrDefault("a"), 2);

        }

        //Test the default false
        [TestMethod]
        public void TextualAnalysis5b()
        {
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequencies("How much wood would a wood chuck chuck if a wood chuck could chuck wood?", true);

            Assert.AreEqual(result.GetValueOrDefault("wood"), 4);
            Assert.AreEqual(result.GetValueOrDefault("chuck"), 4);
            Assert.AreEqual(result.GetValueOrDefault("much"), 0);
            Assert.AreEqual(result.GetValueOrDefault("how"), 0);
            Assert.AreEqual(result.GetValueOrDefault("a"), 0);

        }

        //Test Frequency from string only
        [TestMethod]
        public void TextualAnalysis6()
        {
            string test = "Valar morghulis valar morghulis! valar morghulis valar! Morghulis  valar morghulis!  valar morghulis,  valar! Morghulis  valar morGhulis";
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequencies(test);
            Assert.AreEqual(8, result.GetValueOrDefault("morghulis"));
            Assert.AreEqual(8, result.GetValueOrDefault("valar"));
        }

        //Test Frequency from string only
        [TestMethod]
        public void TextualAnalysis7()
        {
            string test = "dog dog dog dog dog";
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequencies(test);
            Assert.AreEqual(5, result.GetValueOrDefault("dog"));
        }

        //Test Frequency from file only
        [TestMethod]
        public void TextualAnalysis8()
        {
            Dictionary<string, int> result = TextualAnalysis.TextualAnalysis.ComputeWordFrequenciesFromFile("../../../Data/allMen.txt");
            Assert.AreEqual(8, result.GetValueOrDefault("morghulis"));
            Assert.AreEqual(8, result.GetValueOrDefault("valar"));
        }
        #endregion
        //C:/Users/ses10/Desktop/School/Data Structures - Grading/Data/stop-words.txt
    }
}
