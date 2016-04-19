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

       /* private static LinkedList<Memoria> _memoria_ram;
        private static Stack<int> _pila;
        private static List<Registro> _registros;*/

        public static Dictionary<string, IOperacion> _operaciones_definidas { get; set; }
        public static Dictionary<string, Registro> _registros_definidos { get; set; }
        public static Dictionary<string, Memoria> _memoria_definida { get; set; }

        public static char[] _operadores = { '=', '(', ')', '*', '+', '-', '^', '%' };
        /*public static Registro getRegistro(string nombre)
        {
            Registro retorno = null;
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
        }*/

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

        public static List<string> SplitAndKeep(string s, char[] delims)
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
        public static string[] SplitAndKeepArray(string s, char[] delims)
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
            return retorno.ToArray<string>();
        }
    }
}
