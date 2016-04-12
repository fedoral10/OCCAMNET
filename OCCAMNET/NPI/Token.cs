using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET.NPI
{
        public class Token
        {
            public TokenType TokenType { get; set; }
            public string Content;

            public Token(string content, TokenType tokenType)
            {
                this.TokenType = tokenType;
                this.Content = content;
            }

            public Token(string content)
            {
                this.TokenType = TokenType.None;
                this.Content = content;
            }
        }

        public abstract class TokenOpeartor
        {
            public abstract Token ProcessOperator(Token leftToken, Token rightToken);
        }

        public class TokenOperatorStringAdd : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token(leftToken.Content + rightToken.Content, TokenType.String);
            }
        }

        public class TokenOperatorDecimalAdd : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token((Decimal.Parse(leftToken.Content, System.Globalization.CultureInfo.InvariantCulture)
                    + Decimal.Parse(rightToken.Content, System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.InvariantCulture),
                    TokenType.Number);
            }
        }

        public class TokenOperatorDecimalMul : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token((Decimal.Parse(leftToken.Content, System.Globalization.CultureInfo.InvariantCulture)
                    * Decimal.Parse(rightToken.Content, System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.InvariantCulture),
                    TokenType.Number);
            }
        }

        public class TokenOperatorDecimalDiv : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token((Decimal.Parse(leftToken.Content, System.Globalization.CultureInfo.InvariantCulture)
                    / Decimal.Parse(rightToken.Content, System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.InvariantCulture),
                    TokenType.Number);
            }
        }

        public class TokenOperatorDecimalSub : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token((Decimal.Parse(leftToken.Content, System.Globalization.CultureInfo.InvariantCulture)
                    - Decimal.Parse(rightToken.Content, System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.InvariantCulture),
                    TokenType.Number);
            }
        }

        public class TokenOperatorDecimalStringAdd : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token((Decimal.Parse(leftToken.Content, System.Globalization.CultureInfo.InvariantCulture)
                    + Decimal.Parse(rightToken.Content, System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.InvariantCulture),
                    TokenType.Number);
            }
        }

        public class TokenOperatorDecimalStringMul : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token((Decimal.Parse(leftToken.Content, System.Globalization.CultureInfo.InvariantCulture)
                    * Decimal.Parse(rightToken.Content, System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.InvariantCulture),
                    TokenType.Number);
            }
        }

        public class TokenOperatorDecimalStringDiv : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token((Decimal.Parse(leftToken.Content, System.Globalization.CultureInfo.InvariantCulture)
                    / Decimal.Parse(rightToken.Content, System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.InvariantCulture),
                    TokenType.Number);
            }
        }

        public class TokenOperatorDecimalStringSub : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token((Decimal.Parse(leftToken.Content, System.Globalization.CultureInfo.InvariantCulture)
                    - Decimal.Parse(rightToken.Content, System.Globalization.CultureInfo.InvariantCulture)).ToString(System.Globalization.CultureInfo.InvariantCulture),
                    TokenType.Number);
            }
        }

        public class TokenOperatorDateAdd : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                return new Token(DateTime.Parse(leftToken.Content, CultureInfo.InvariantCulture).AddDays(
                    Int32.Parse(rightToken.Content, CultureInfo.InvariantCulture)).ToString(
                    CultureInfo.InvariantCulture),
                    TokenType.Date);
            }
        }

        public class TokenOperatorDateSub : TokenOpeartor
        {
            public override Token ProcessOperator(Token leftToken, Token rightToken)
            {
                if (leftToken.TokenType == TokenType.Date && rightToken.TokenType == TokenType.Number)
                {
                    return new Token(DateTime.Parse(leftToken.Content, CultureInfo.InvariantCulture).AddDays(
                        -Int32.Parse(rightToken.Content, CultureInfo.InvariantCulture)).ToString(
                        CultureInfo.InvariantCulture),
                        TokenType.Date);
                }
                else if (leftToken.TokenType == TokenType.Date && rightToken.TokenType == TokenType.Date)
                {
                    return new Token(
                    DateTime.Parse(leftToken.Content, CultureInfo.InvariantCulture).Subtract(
                        DateTime.Parse(rightToken.Content, CultureInfo.InvariantCulture)).Days.ToString(CultureInfo.InvariantCulture),
                        TokenType.Number
                        );
                }
                else
                {
                    throw new ArgumentException(String.Format("Operator doesn't support this data types. Lvalue:{0} Rvalue:{1}", leftToken.TokenType, rightToken.TokenType));
                }
            }
        }

        public static class TokenOperatorFactory
        {
            private static Dictionary<TokenType, Dictionary<TokenType, Dictionary<string, TokenOpeartor>>> Mapping = new Dictionary<TokenType, Dictionary<TokenType, Dictionary<string, TokenOpeartor>>>();

            static TokenOperatorFactory()
            {
                Mapping.Add(TokenType.String, new Dictionary<TokenType, Dictionary<string, TokenOpeartor>>());
                Mapping.Add(TokenType.Number, new Dictionary<TokenType, Dictionary<string, TokenOpeartor>>());
                Mapping.Add(TokenType.Date, new Dictionary<TokenType, Dictionary<string, TokenOpeartor>>());

                Mapping[TokenType.String].Add(TokenType.Number, new Dictionary<string, TokenOpeartor>());
                Mapping[TokenType.String].Add(TokenType.String, new Dictionary<string, TokenOpeartor>());

                Mapping[TokenType.Number].Add(TokenType.String, new Dictionary<string, TokenOpeartor>());
                Mapping[TokenType.Number].Add(TokenType.Number, new Dictionary<string, TokenOpeartor>());
                Mapping[TokenType.Number].Add(TokenType.Date, new Dictionary<string, TokenOpeartor>());

                Mapping[TokenType.Date].Add(TokenType.Number, new Dictionary<string, TokenOpeartor>());
                Mapping[TokenType.Date].Add(TokenType.Date, new Dictionary<string, TokenOpeartor>());

                Mapping[TokenType.String][TokenType.String].Add("+", new TokenOperatorStringAdd());

                Mapping[TokenType.String][TokenType.Number].Add("+", new TokenOperatorDecimalStringAdd());
                Mapping[TokenType.String][TokenType.Number].Add("-", new TokenOperatorDecimalStringSub());
                Mapping[TokenType.String][TokenType.Number].Add("*", new TokenOperatorDecimalStringMul());
                Mapping[TokenType.String][TokenType.Number].Add("/", new TokenOperatorDecimalStringDiv());

                Mapping[TokenType.Number][TokenType.String].Add("+", new TokenOperatorDecimalStringAdd());
                Mapping[TokenType.Number][TokenType.String].Add("-", new TokenOperatorDecimalStringSub());
                Mapping[TokenType.Number][TokenType.String].Add("*", new TokenOperatorDecimalStringMul());
                Mapping[TokenType.Number][TokenType.String].Add("/", new TokenOperatorDecimalStringDiv());

                Mapping[TokenType.Number][TokenType.Number].Add("+", new TokenOperatorDecimalAdd());
                Mapping[TokenType.Number][TokenType.Number].Add("-", new TokenOperatorDecimalSub());
                Mapping[TokenType.Number][TokenType.Number].Add("*", new TokenOperatorDecimalMul());
                Mapping[TokenType.Number][TokenType.Number].Add("/", new TokenOperatorDecimalDiv());

                Mapping[TokenType.Date][TokenType.Number].Add("+", new TokenOperatorDateAdd());
                Mapping[TokenType.Date][TokenType.Number].Add("-", new TokenOperatorDateSub());
                Mapping[TokenType.Date][TokenType.Date].Add("-", new TokenOperatorDateSub());
            }

            public static TokenOpeartor Make(Token leftToken, Token rightToken, Token operatorToken)
            {
                if (Mapping.ContainsKey(leftToken.TokenType) && Mapping[leftToken.TokenType].ContainsKey(rightToken.TokenType))
                    return Mapping[leftToken.TokenType][rightToken.TokenType][operatorToken.Content];
                else
                    throw new ArgumentException("Operator not found for given types");
            }
        }

        public static class TokenOperatorFacade
        {
            public static Token ProcessOperator(Token leftToken, Token rightToken, Token operatorToken)
            {
                TokenOpeartor to = TokenOperatorFactory.Make(leftToken, rightToken, operatorToken);
                return to.ProcessOperator(leftToken, rightToken);
            }
        }
    }

