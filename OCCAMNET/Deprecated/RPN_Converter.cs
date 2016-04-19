using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OCCAMNET
{
    class RPN_Converter
    {
        private Stack<string> _pila;
        private Queue<string> _cola;

        private char[] _operadores = { '=','(',')','*','+','-','^'};

        public RPN_Converter()
        {
            this._cola = new Queue<string>();
            this._pila = new Stack<string>();
        }

        public void convertir(string cadena)
        {
            List<string> tokens = SplitAndKeep(cadena, _operadores);

            foreach (string token in tokens)
            {
                if (!esOperador(token))
                {
                    this._cola.Enqueue(token);
                }
                else
                {
                    this._pila.Push(token);
                }
            }

            Console.Write(tokens);
        }

        private bool esOperador(string token)
        {
            foreach (char operador in this._operadores)
            {
                if (operador.ToString() == token)
                {
                    return true;
                }
            }
            return false;
        }
        public List<string> SplitAndKeep(string s, char[] delims)
        {
            int start = 0, index;

            List<string> retorno = new List<string>();

            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0)
                    retorno.Add(s.Substring(start, index - start).Trim());
                retorno.Add(s.Substring(index, 1).Trim());
                start = index + 1;
            }

            if (start < s.Length)
            {
                retorno.Add(s.Substring(start).Trim());
            }
            return retorno;
        }
        private int prioridadOperando(string oper)
        {
            if (oper == "(" || oper == ")")
            {
                return 1;
            }
            else
            {
                if (oper=="^")
                {
                    return 2;
                }
                else
                {
                    if (oper == "/" || oper == "/")
                    {
                        return 3;
                    }
                    else
                    {
                        if (oper == "+" || oper == "-")
                            return 4;
                        else
                            return 5;
                    }
                }
            }
            
        }
    }
}

