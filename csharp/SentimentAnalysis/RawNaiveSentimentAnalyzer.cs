using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentimentAnalysis
{
    public sealed class RawNaiveSentimentAnalyzer : ISentinmentAnalyzer
    {
        private readonly Dictionary<string, int> _sentimentScores;

        public RawNaiveSentimentAnalyzer(Dictionary<string, int> sentimentScores)
        {
            if (sentimentScores == null || !sentimentScores.Any())
            {
                throw new ArgumentException($"{sentimentScores} is invalid.");
            }

            _sentimentScores = sentimentScores;
        }

        public double GetSentimentScore(string text)
        {
            var score = 0;

            if (string.IsNullOrWhiteSpace(text))
            {
                return score;
            }

            var words = text.Split(' ');

            foreach(var word in words)
            {
                if (_sentimentScores.ContainsKey(word))
                {
                    score += _sentimentScores[word];
                }
            }

            return score;
        }
    }
}
