using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentimentAnalysis
{
    public sealed class NormalizedNaiveSentimentAnalyzer
    {
        private readonly Dictionary<string, int> _sentimentScores;

        public NormalizedNaiveSentimentAnalyzer(Dictionary<string, int> sentimentScores)
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
            var count = 0;

            if (string.IsNullOrWhiteSpace(text))
            {
                return score;
            }

            var words = text.Split(' ');

            foreach (var word in words)
            {
                if (_sentimentScores.ContainsKey(word))
                {
                    count++;
                    score += _sentimentScores[word];
                }
            }

            return (double)score / count;
        }
    }
}
