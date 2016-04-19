using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    class IFBuilder
    {
        private string _cadena;
        private string _source;
        private List<string> _and;
        private List<string> _or;
        public IFBuilder(string comparacion)
        {
            this._and = new List<string>();
            this._or = new List<string>();
            _cadena = "if("+comparacion+"{0}) "
                + "{"
                + "{1}"
                + "}";
        }
        public void addElseIF(IFBuilder ifbuilder)
        {
            this._cadena = this._cadena + "else "
            + " { "
            + ifbuilder.ToString()
            + " } ";
        }

        public void addElse(string source)
        {
            this._cadena = this._cadena + "else"
                + " { "
                + source
                + " } ";
        }
        public void addAND(string comparacion)
        {
            _and.Add("&& " + comparacion);
        }
        public void addOR(string comparacion)
        {
            _or.Add("||" + comparacion);
        }

        public void setSoruce(string source)
        {
            this._source = source;
        }
        public override string ToString()
        {
            string ands="";
            foreach(string and in this._and)
            {
                ands = ands + and;
            }
            string ors = "";
            foreach (string or in this._or)
            {
                ors = ors + or;
            }
            string retorno = string.Format(this._cadena, ands + ors, _source);
            
            return retorno;
        }
    }
}
