using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_unscrambler.Data;

namespace Word_unscrambler.Workers
{
    class WordMatcher
    {
        public List<MatchWords> Match(string[] scambreWords, string[] wordList)
        {
            var matchedWords = new List<MatchWords>();

            foreach(var scambreWord in scambreWords)
            {
                foreach (var word in wordList)
                {
                    if (scambreWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(buildMatchWords(scambreWord,word));
                    }
                    else
                    {
                        var scrambledWordArray = scambreWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedcrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if (sortedcrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(buildMatchWords(scambreWord, word));
                        }
                    }

                }
            }


            return matchedWords;
        }

        private MatchWords buildMatchWords(string scambreWord, string word)
        {
            MatchWords match = new MatchWords
            {
                ScrambledWord = scambreWord,
                Word = word
        };
            return match;
        }
        
    }
}
