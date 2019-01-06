using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_unscrambler
{
    class Constants
    {
        public const string OptionsEnterWords = "Ingrese las palabras manualmente M o por medio de un archivo A:";
        public const string OptionOnContinue = "Continuar S/N";
        public const string EnterWordsFiles = "Ingrese la ruta del archivo y nombre";
        public const string EnterWordsManually = "Ingrese las palabras Manualmente separadas por coma:";
        public const string EnterWordsOptionNot = "la opción ingresada no es correcta";
        public const string ErrorWordsCannotLoad = "Ocurrio un error al cargar las palabras";
        public const string ErrorProgramExit = "Se cerrara la aplicacíón";

        public const string MatchFound = "Se encontro la palabra {0}: {1}";
        public const string MatchNotFound = "No se encontraron palabras";

        public const string Yes = "S";
        public const string No = "N";
        public const string File = "A";
        public const string Manual = "M";
        public const string wordListName = "words.txt";

    }
}
