using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace OCCAMNET.Builders
{
    class CSBuilder
    {
        private StringBuilder _salida;
        public CSBuilder(string nombre,string funcion,string ns)
        {
            this._salida = new StringBuilder();
            _salida.AppendLine("using System;");
            _salida.AppendLine("namespace "+ns);
            _salida.AppendLine("{");
            _salida.AppendLine("class OPERACION_" + nombre + " : IOperacion");
            _salida.AppendLine("{");
            
            _salida.AppendLine("public string nombre { get; set; }");
            _salida.AppendLine("public IParametro[] parametros { get; set; }");
            _salida.AppendLine(funcion);
            _salida.AppendLine("}");
            _salida.AppendLine("}");
        }

        public string getClase()
        {
            return _salida.ToString();
        }

        public string creaFuncion(string operacion_aritmetica_logica)
        {
            string[] arr = commons.limpia_codigo(operacion_aritmetica_logica).Split(' ');
            string retorno = null;
            string func = " public int ejecutar() "
                          + "{"
                          + "   int retorno = 0;"
                          + "   try"
                          + "   { "
                          + "       {0} "
                          + "   } "
                          + "   catch (Exception ex)"
                          + "   {"
                          + "       Console.Write(ex.Message); "
                          + "       retorno =1; "
                          + "   }"
                          + "   return retorno;"
                          + "}";


            switch (arr.Length)
            {
                /*asignacion simple*/
                case 3:
                    retorno = "";
                break;
                /*asignacion con operacion*/
                case 5:
                    _salida.AppendLine();
                break;
                default:
                    throw new Exception("Instruccion desconocida");
            }
            return retorno;
        }

        private string _asignacion_simple_memoria_inmediato = 
        "if (parametros[0].TIPO == commons.tipo.MEMORIA && parametros[1].TIPO == commons.tipo.INMEDIATO) "
        + " { "
        + " Memoria m; "
        + " if (commons._memoria_definida.ContainsKey(parametros[0].valor)) "
        + " { "
        + "     m = commons._memoria_definida[parametros[0].valor]; "
        + "     m.valor = int.Parse(parametros[1].valor); "
        + " }"
        + " else"
        + " {"
        + "     m = new Memoria();"
        + "     m.Direccion = parametros[0].valor;"
        + "     m.valor = int.Parse(parametros[1].valor);"
        + " } "
        + "}";

    }
}
