using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    public class commons
    {

        private static LinkedList<Memoria> _memoria_ram;
        private static Stack<int> _pila;
        private static List<reg> _registros;

        public static Dictionary<string, IOperacion> _operaciones_definidas { get; set; }
        public static Dictionary<string, reg> _registros_definidos { get; set; }
        public static Dictionary<string, Memoria> _memoria_definida { get; set; }


        public static reg getRegistro(string nombre)
        {
            reg retorno = null;
            retorno = _registros.Find(x => x.nombre == nombre);
            return retorno;
        }

        public static void push(int valor)
        {
            _pila.Push(valor);
        }
        public static int pop()
        {
            return _pila.Pop();
        }

        /*public static void addMemoria(XMemoria m) {
            _memoria_ram.AddLast(m);
        }*/

        public static string[] getLines(string file) {
            return File.ReadAllLines(file);
        }

        public enum tipo
        {
            REGISTRO,
            INMEDIATO,
            MEMORIA
        }

        public static string limpia_codigo(string linea)
        {
            return linea.Trim().Replace("\t", "");
        }
    }
}
