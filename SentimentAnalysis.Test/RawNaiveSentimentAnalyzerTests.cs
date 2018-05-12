using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SentimentAnalysis.Test
{
    [TestClass]
    public class RawNaiveSentimentAnalyzerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanHandleNullSentimentDictionary()
        {

            var analyzer = new RawNaiveSentimentAnalyzer(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CanHandleEmptySentimentDictionary()
        {

            var analyzer = new RawNaiveSentimentAnalyzer(new Dictionary<string, int>());
        }

        [TestMethod]
        public void CanHandleEmptyText()
        {
            var scoreDictionary = new Dictionary<string, int>
            {
                { "foo", -1 }
            };

            var analyzer = new RawNaiveSentimentAnalyzer(scoreDictionary);

            Assert.AreEqual(0, analyzer.GetSentimentScore(""));
        }

        [TestMethod]
        public void CanScorePositiveText()
        {
            var scoreDictionary = new Dictionary<string, int>
            {
                { "foo", 1 },
                { "bar", 2 }
            };

            var analyzer = new RawNaiveSentimentAnalyzer(scoreDictionary);

            Assert.AreEqual(3, analyzer.GetSentimentScore("foo bar"));
        }

        [TestMethod]
        public void CanScoreNegativeText()
        {
            var scoreDictionary = new Dictionary<string, int>
            {
                { "foo", -1 },
                { "bar", -2 }
            };

            var analyzer = new RawNaiveSentimentAnalyzer(scoreDictionary);

            Assert.AreEqual(-3, analyzer.GetSentimentScore("foo bar"));
        }

        [TestMethod]
        public void CanScoreNeutralText()
        {
            var scoreDictionary = new Dictionary<string, int>
            {
                { "foo", -1 },
                { "bar", 1 }
            };

            var analyzer = new RawNaiveSentimentAnalyzer(scoreDictionary);

            Assert.AreEqual(0, analyzer.GetSentimentScore("foo bar"));
        }
    }
}
