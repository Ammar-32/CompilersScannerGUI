using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompilersScannerGUI
{
    partial class Scanner
    {
       
        private static bool reservedCheck(string stringToCheck)
        {
            for (int i = 0; i < ReservedWords.Length; i++)
            {
                if (stringToCheck == ReservedWords[i])
                    return true;
            }
            return false;
        }

        
        private static bool symbolCheck(string stringToCheck)
        {
            for (int i = 0; i < SpecialSymbol.Length; i++)
            {
                if (stringToCheck == "" + SpecialSymbol[i])
                    return true;
            }
            return false;
        }

       
        private static bool whiteSpacesCheck(char charToCheck)
        {
            for (int i = 0; i < WhiteSpaces.Length; i++)
            {
                if (charToCheck == WhiteSpaces[i])
                    return true;
            }
            return false;
        }

        
        private static bool isNumber(string numberToCheck)
        {
            double Num;
            if (double.TryParse(numberToCheck, out Num))
                return true;
            return false;
        }
    }
}
