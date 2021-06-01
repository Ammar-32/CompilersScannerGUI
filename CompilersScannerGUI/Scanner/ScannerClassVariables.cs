using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CompilersDesign;

namespace CompilersScannerGUI
{
    partial class Scanner
    {
        public static string testPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static string output = "";

        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static Token obj;

        static List<char> chars = new List<char>();

        static char[] SpecialSymbol = { '+', '-', '*', '/', '=', '<', '(', ')', ';', ':', '>' };
        static string[] ReservedWords = { "if", "then", "else", "end", "repeat", "until", "read", "write" };
        static char[] WhiteSpaces = { '\r', '\t', '\n', ' ' };

        static List<Token> TokensList = new List<Token>();

        static string Empty = String.Empty;
    }
}
