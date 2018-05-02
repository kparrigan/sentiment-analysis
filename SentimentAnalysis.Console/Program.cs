using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SentimentAnalysis.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sentimentScoreFile = ConfigurationManager.AppSettings["SentimentScoreFile"];
            var scoreDictionary = ParseSentimentScoreFile(sentimentScoreFile);

            //TODO plug in to actual data here....
            ReadKey();
        }

        private static Dictionary<string, int> ParseSentimentScoreFile(string filePath)
        {
            var scoreDictionary = new Dictionary<string, int>();

            using (var reader = new StreamReader(filePath))
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine();
                    var split = line.Split('\t');

                    scoreDictionary.Add(split[0], Int32.Parse(split[1]));
                }
            }

            return scoreDictionary;
        }
    }
}
