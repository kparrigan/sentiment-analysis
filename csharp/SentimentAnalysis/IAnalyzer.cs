using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentimentAnalysis
{
    public interface ISentinmentAnalyzer
    {
        double GetSentimentScore(string text);      
    }
}
