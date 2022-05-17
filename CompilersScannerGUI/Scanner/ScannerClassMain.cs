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
        // function that does the scanner logic (Scanner DFA)
        public static string Scan(string input)
        {
            // first we initialize the output string as empty string
            output = "";
            
            // set the chars equal to the input code
            chars = input.ToCharArray().ToList<char>();
            chars.Add('\r');

            // len to count the number of chars for the input
            long len = chars.Count();

            // initialize isComment flag by false
            bool isComment = false;
            
            // initialize token as empty
            string token = Empty;


            // main loop which loops through each character
            for (int i = 0; i < len; i++)
            {
                // if white space then ignore the iteration and go to the next iteration
                if (whiteSpacesCheck(chars[i]))
                    continue;
                // append the current char to token string
                token += chars[i];

                // if token is a symbol then go check for assignment operator :=
                if (symbolCheck(token))
                {
                    // check assignment operator
                    if (chars[i] == ':' )
                    {
                        for(int y = i+1; y < len; y++)
                        {
                            // if assignment operator then add the token as a special symbol
                            if (chars[y] == '=')
                            {
                                token += chars[y];
                                i = y;
                                obj = new Token(token, "Special Symbol");
                                break;
                            }
                            // if we didnt find = after the : then store token as error
                            else if (Char.IsLetter(chars[y])==false)
                            {
                                obj = new Token(token, "Error");
                                break;
                            }
                        }

                    }
                    // if any other symbol other than the assignment operator store token as special symbol
                    else
                    {
                        obj = new Token(token, "Special Symbol");
                    }
                    
                }

                // if token is a number
                else if (isNumber(token))
                {
                    //loop to append numbers with more than one digit
                    for (int x = i+1 ; x < len; x++)
                    {
                        // if we find white space then we have our number in the token string
                        if (whiteSpacesCheck(chars[x]))
                            break;
                        // if the character after is not a number or . (for decimal) then exit the loop
                        if (isNumber(chars[x]+"") == false && chars[x] != '.')
                            break;
                        else
                        {
                            // add digit to the token
                            token += chars[x];
                            i++;
                        }
                    }
                    // create token as number
                    obj = new Token(token, "Number");
                }
                // check for curly brace for the comment
                else if(chars[i] == '{')
                {
                    // loop and append every cahr inside the curly brace until we find the closing of the curly brace
                    for(int k = i + 1; k < len; k++)
                    {
                        token += chars[k];
                        // if we found the closing of the curly brace empty the token and break the loop and raise the isComment flag
                        if (chars[k] == '}')
                        {
                            i = k;
                            token = Empty;
                            isComment = true;
                            break;
                        }
                    }
                    // check for the isComment flag if it was true then go to the next iteration
                    if (isComment) continue;
                }
                else
                {
                    for (int k = i + 1; k < len; k++)
                    {
                        // check if it is white space or not a letter or a separator so that they stop appending for identifiers
                        if (whiteSpacesCheck(chars[k]) || !Char.IsLetter(chars[k]) || char.IsSeparator(chars[k]))
                        {
                            i = k - 1;
                            break;
                        }
                        token += chars[k];
                    }
                    // now we check if the token is a reserved word or not
                    // if reserved word then create token as reserved word
                    // if not reserved word then this is definetly an identifier
                    if (reservedCheck(token))
                    {
                        obj = new Token(token, "Reserved Word");
                    }
                    else
                    {
                        obj = new Token(token, "Identifier");
                    }
                }
                // append the token to the output string
                output += obj.ToString();
                
                // empty the token for the next iteratio
                // make the isComment flag = false for the next iteration
                token = Empty;
                isComment = false;
            }
           
            return output;
        }
    }
}
