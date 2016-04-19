using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    class commonBuilder
    {
        private string _base = "using System; \n " +
                            "using System.Collections.Generic; \n " +
                            "using System.Linq; \n " +
                            "using System.Text; \n " +
                            "using System.Threading.Tasks; \n " +
        "public static Dictionary<string, IOperacion> _operaciones_definidas { get; set; }  \n " +
        "public static Dictionary<string, Registro> _registros_definidos { get; set; } \n " +
        "public static Dictionary<string, Memoria> _memoria_definida { get; set; }  \n " +

                            "namespace [ns] \n " +
                            "{ \n " +
                            "    class commons \n " +
                            "    { \n " +
                            "        public static void inicializar() \n " +
                            "        { \n " +
                            "            _operaciones_definidas = new Dictionary<string, IOperacion>(); \n " +
                            "            _registros_definidos = new Dictionary<string, Registro>(); \n " +
                            "            _memoria_definida = new Dictionary<string, Memoria>(); \n " +
                            "        [initreg]    \n " +
                            "        [initope]    \n " +
                            "        } \n " +
                            "    } \n " +
                            "}";
        private string _ns;
        public commonBuilder(string ns)
        {
            this._ns = ns;
        }
        public Dictionary<string, Registro> registros_definidos { get; set; }
        public Dictionary<string, IOperacion> operaciones_definidas { get; set; }

        public string getCommonClass()
        {
            string salida = null;

            //Registros
            string registros = "";
            foreach (KeyValuePair<string, Registro> entry in registros_definidos)
            {
                registros = registros + "Registro " + entry.Key + "= new Registro(); \n";
                registros = registros + entry.Key + ".Identificador=\"" + entry.Key + "\"; \n";
                registros = registros + "_registros_definidos.Add(\"" + entry.Key + "\", "+entry.Key+ "); \n";
            }
            //Operaciones
            string operaciones = "";
            foreach (KeyValuePair<string, IOperacion> entry in operaciones_definidas)
            {
                operaciones = operaciones + "IOperacion " + entry.Key + "= new Operacion_vacia(); \n";
                operaciones = operaciones + entry.Key + ".nombre=\"" + entry.Key + "\"; \n";
                operaciones = operaciones + "operaciones_definidas.Add(\"" + entry.Key + "\", " + entry.Key + "); \n";
            }

            salida = _base.Replace("[initreg]", registros);
            salida = salida.Replace("[initope]", operaciones);
            salida = salida.Replace("[ns]", _ns);

            return salida;
        }
    }
}
