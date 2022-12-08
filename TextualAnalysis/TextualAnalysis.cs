using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace TextualAnalysis
{
    public class TextualAnalysis
    {
        public static string stopWordFilePath = "../../../Data/stop-words.txt";

        public TextualAnalysis()
        {
        }


        public static Dictionary<string, int> ComputeWordFrequencies(string s, bool ignoreStopWords = false)
        {
            var wordCounts = new Dictionary<string, int>();
            // s = "all the faith he had had had had no effect."

            // remove punctuation
            var cleanString = Regex.Replace(s, @"[^\w\s]", "");

            // split the string into words (filtering out the empty strings)

            var words = cleanString.ToLower().Split("/").Where(s => s != "");

            string[] stopwords = GetStopWordsFromFile(stopWordFilePath);

            //foreach word do somethin
            foreach(var word in words)
            {
                //if not ignoring stop words and word is  stop word
                if (ignoreStopWords = false & stopwords.Contains(word))
                {
                    //skip the stop word
                    wordCounts.Add(word, 0 );
                }

                else
                {
                    //else
                    if (wordCounts.ContainsKey(word))
                    {
                        //or increment the word count if it's already in the dictionary
                        wordCounts[word] = wordCounts[word] + 1 ;
                    }

                    //either add word if new with count of one
                    wordCounts.Add(word, 1);
                }


            }

            return wordCounts;
        }


        public static Dictionary<string, int> ComputeWordFrequenciesFromFile(string path, bool ignoreStopWords = false)
        {
            // read in the file
            string text = System.IO.File.ReadAllText(path);

            // call the other method
            Dictionary<string, int> result = ComputeWordFrequencies(text);

            // return the result of the other method
            return result;
        }

        private static string[] GetStopWordsFromFile(string path)
        {
            var rawLines = System.IO.File.ReadAllLines(path);
            var lines = new List<string>();

            foreach (var line in rawLines)
            {
                // ignore blank lines
                if (line.Trim() != "")
                {
                    lines.Add(line.Trim().ToLower());
                }
            }

            return lines.ToArray();
        }

    }
}
