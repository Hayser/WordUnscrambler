using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word_unscrambler.Data;
using Word_unscrambler.Workers;

namespace Word_unscrambler
{
    class Program
    {
        
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {

            try
            {
                bool continueGame = true;
                do
                {
                    Console.WriteLine(Constants.OptionsEnterWords);
                    var option = Console.ReadLine() ?? string.Empty;
                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterWordsFiles);
                            ExcuteFileGame();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterWordsManually);
                            ExcuteGameManual();
                            break;
                        default:
                            Console.Write(Constants.EnterWordsOptionNot);
                            break;
                    }
                    var continueOption = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionOnContinue);
                        continueOption = (Console.ReadLine() ?? string.Empty);
                    } while (
                             !continueOption.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                             !continueOption.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueGame = continueOption.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueGame);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramExit+ ex.Message);
            }
          

            Console.ReadKey();
        }

        private static void ExcuteGameManual()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scambreWords = manualInput.Split(',');
            DisplayMatchWords(scambreWords);
        }

       

        private static void ExcuteFileGame()
        {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scambreWords = _fileReader.Read(fileName);
                DisplayMatchWords(scambreWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorWordsCannotLoad + ex.Message);
            }
           

            
           
        }
        
        private static void DisplayMatchWords(string[] scambreWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListName);

            List<MatchWords> matchedWords = _wordMatcher.Match(scambreWords, wordList);
            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
