using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OCCAMNET.NPI
{
    public class StringTokenizer
    {
        private static char[] trimArray = new char[] { '"' };
        private List<string> operators;
        private string tokenizers;
        private string input = String.Empty;
        private string current = String.Empty;


        public StringTokenizer(string input, string splitStrings, string[] operators)
        {
            this.tokenizers = splitStrings;
            this.operators = new List<string>(operators);
            this.input = input;
        }

        /// <summary>
        /// Method splits string into tokens. 
        /// Uses splitString and operator string arrays to recognize token type
        /// Also method uses " character to recognize string and disable parsing until next " occurs. 
        /// So the character " is used as string indicator
        /// </summary>
        /// <returns></returns>
        public List<Token> Tokenize()
        {
            List<Token> result = new List<Token>();

            string[] splited = Regex.Split(this.input, this.tokenizers, RegexOptions.Compiled);

            int count = splited.Length;

            for (int i = 0; i < count; i++)
            {
                string s = splited[i];

                if (!String.IsNullOrEmpty(s))
                {
                    if (s.StartsWith("\"") && s.EndsWith("\""))
                    {
                        s = s.Trim(trimArray);
                        result.Add(new Token(s, TokenType.String));
                    }
                    else
                    {
                        result.Add(new Token(s, TypeOfToken(s)));
                    }
                }
            }

            /// Check for function 
            /// If first token is variable and second is leftbracke 
            ///     for examle: [i] => abs  [i+1] => '('
            /// then token type variable for abs is switched to function type
            for (int i = 0; i < result.Count; i++)
                if (i > 0 && result[i].TokenType == TokenType.LeftBracket && result[i - 1].TokenType == TokenType.Variable)
                    result[i - 1].TokenType = TokenType.Function;

            /// Checks and process negative numbers 
            /// Examples of negative number support
            /// 1) -345
            /// 2) (-345)
            /// 3) +-345
            for (int i = 0; i < result.Count; i++)
                if ((i == 0 && result[i].Content == "-") || (i > 0 && result[i].Content == "-" && (result[i - 1].TokenType == TokenType.Operator || result[i - 1].TokenType == TokenType.LeftBracket) && result[i + 1].TokenType == TokenType.Number))
                {
                    result[i + 1].Content = "-" + result[i + 1].Content;
                    result.RemoveAt(i);
                }

            return result;
        }

        private TokenType TypeOfToken(string token)
        {
            Decimal tmpNum;

            if (Decimal.TryParse(token, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out tmpNum))
                return TokenType.Number;

            if (operators.Contains(token))
                return TokenType.Operator;

            if (token.Equals("("))
                return TokenType.LeftBracket;

            if (token.Equals(")"))
                return TokenType.RightBracket;

            if (token.Equals(","))
                return TokenType.FunctionArgumentSeparator;

            return TokenType.Variable;
        }
    }
}
