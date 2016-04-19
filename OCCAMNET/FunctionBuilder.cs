using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    class FunctionBuilder
    {

        //Dictionary<string, IParametro> _parametros_definidos;

        private string _cadena_funcion;
        

        public FunctionBuilder(string cadena_funcion)
        {
            //this._parametros_definidos = parametros;
            this._cadena_funcion = cadena_funcion;
        }


        public string getFunction()
        {
            string funcion = "public int ejecutar() \n" +
                             "{\n" +
                            "int retorno = 0;\n" +
                            " [body] " +
                            "\n return retorno;" +
                            "}";


            List<string> tokens = commons.SplitAndKeep(this._cadena_funcion, commons._operadores);

            string lol = "";
            int cont_operandos = 0;
            foreach (string token in tokens)
            {
                if (token == "=" ||  token == "+" || token == "-" || token == "/" || token == "*")
                {
                    lol = lol + token;
                }
                else
                {
                    lol = lol + "parametros[" + cont_operandos + "].valor";
                    cont_operandos++;
                }

            }


            return funcion.Replace("[body]", lol+";");
        }

    
        

        /*private IParametro findParametro(string nombre)
    {
        IEnumerable<IParametro> i = from para in this._parametros where para.identificador == nombre select para;
        IParametro parametro =i.First<IParametro>();
        if (parametro == null)
            return null;
        else
            return parametro;
    }
    private int getIndexParametro(IParametro parametro)
    {
        return this._parametros.IndexOf(parametro);
    }*/
        //AX=AX+X
        /*
         *
         *
         * public int ejecutar()
           {
            int retorno = 0;
            {0}
            return retorno;
           }
             */
    }
}
