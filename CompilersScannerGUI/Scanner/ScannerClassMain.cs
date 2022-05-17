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
        public static string Scan(string input)
        {
            output = "";
            

            chars = input.ToCharArray().ToList<char>();
            chars.Add('\r');

            long len = chars.Count();

            bool isComment = false;
            
            string token = Empty;

            for (int i = 0; i < len; i++)
            {
                if (whiteSpacesCheck(chars[i]))
                    continue;

                token += chars[i];

                if (symbolCheck(token))
                {
                    if (chars[i] == ':' )
                    {
                        for(int y = i+1; y < len; y++)
                        {
                            if (chars[y] == '=')
                            {
                                token += chars[y];
                                i = y;
                                obj = new Token(token, "Special Symbol");
                                break;
                            }
                            else if (Char.IsLetter(chars[y])==false)
                            {
                                obj = new Token(token, "Error");
                                break;
                            }
                        }

                    }
                    else
                    {
                        obj = new Token(token, "Special Symbol");
                    }
                    
                }
                else if (isNumber(token))
                {
                    for (int x = i+1 ; x < len; x++)
                    {
                        if (whiteSpacesCheck(chars[x]))
                            break;
                        if (isNumber(chars[x]+"") == false && chars[x] != '.')
                            break;
                        else
                        {
                            token += chars[x];
                            i++;
                        }
                    }
                    obj = new Token(token, "Number");
                }
                else if(chars[i] == '{')
                {
                    for(int k = i + 1; k < len; k++)
                    {
                        token += chars[k];
                        if (chars[k] == '}')
                        {
                            i = k;
                            token = Empty;
                            isComment = true;
                            break;
                        }
                    }
                    if (isComment) continue;
                }
                else
                {
                    for (int k = i + 1; k < len; k++)
                    {
                        if (whiteSpacesCheck(chars[k]) || !Char.IsLetter(chars[k]) || char.IsSeparator(chars[k]))
                        {
                            i = k - 1;
                            break;
                        }
                        token += chars[k];
                    }
                    if (reservedCheck(token))
                    {
                        obj = new Token(token, "Reserved Word");
                    }
                    else
                    {
                        obj = new Token(token, "Identifier");
                    }
                }
              //  TokensList.Add(obj);
                output += obj.ToString();
              
                token = Empty;
                isComment = false;
            }
           
            return output;
        }
    }
}
