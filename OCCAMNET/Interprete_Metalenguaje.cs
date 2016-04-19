using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    class Interprete_Metalenguaje
    {

        Dictionary<string,IOperacion> _operaciones_definidas;
        Dictionary<string, Registro> _registros_definidos;
        Dictionary<string, Memoria> _memoria_definida;

        private string _ns = "Prueba";

        public void test()
        {
            this._operaciones_definidas = new Dictionary<string, IOperacion>();
            this._registros_definidos = new Dictionary<string, Registro>();
            this._memoria_definida = new Dictionary<string, Memoria>();

            commons._memoria_definida = _memoria_definida;
            commons._registros_definidos = _registros_definidos;
            commons._operaciones_definidas = _operaciones_definidas;

            string archivo = @"C:\Users\Potosme\Desktop\hamat\ParaCompilador\SalidasOcam\definicion de metarepertorios.txt";


            List<string> clases = new List<string>();
            string[] lineas =  commons.getLines(archivo);
            //foreach (string linea in lineas)
            for(int lcont = 0; lcont  < lineas.Length; lcont++)
            {
                string lower_line= lineas[lcont].ToLower();
                /*Definicion de tokens*/
                if (lower_line.StartsWith("#definir "))
                {
                    definir(lower_line);
                }
                else
                /*comentarios*/
                if (lower_line.StartsWith(".") || lower_line.StartsWith(";")||lower_line.StartsWith("//") || lower_line == "\n" ||string.IsNullOrEmpty(lower_line))
                {
                    //consumir
                }
                else
                {
                    //si existe la operacion y la esta definiendo
                    string[] arr = lower_line.Split(' ');
                    if (this._operaciones_definidas.ContainsKey(arr[0]))
                    {
                        string clase = define_cuerpo_funcion(lineas,this._operaciones_definidas[arr[0]],ref lcont);
                        clases.Add(clase);
                    }
                    else
                    {
                        //si no corresponde a nada
                        throw new Exception("Instruccion desconocida en linea "+lcont+1);
                    }
                }
            }

            commonBuilder builderCommon = new commonBuilder("OCCAMNET");
            builderCommon.operaciones_definidas = _operaciones_definidas;
            builderCommon.registros_definidos = _registros_definidos;
            string comm = builderCommon.getCommonClass();
        }

        private string define_cuerpo_funcion(string[] lineas,IOperacion operacion,ref int lcont)
        {
            /*
            R# registro
            # inmediato
            [M] memoria
            */
            string clase = null;
            lcont++;
            string[] test = lineas[lcont].Split(' ');
            if (test[0] != "{")
            {
                throw new Exception("Definicion de operacion esperada {");
            }
           
            while (true)
            {
                //string[] arr = lineas[lcont].Split(' ');
                string[] arr = commons.SplitAndKeepArray(lineas[lcont], commons._operadores);
                //
                if (arr.Length == 1)
                {

                    if (arr[0] == "}")
                    {
                        break;
                    }
                }
                else
                {
                    /*Dictionary<string, IParametro> parametros = new Dictionary<string, IParametro>();
                    //Operanos y operadores
                    foreach (string token in arr)
                    {
                        IParametro parametro;
                        switch (token)
                        {
                            case "R#":
                                parametro = new Registro();
                                parametro.identificador = "r#";
                            break;
                            case "[#]":
                                parametro = new Memoria();
                                parametro.identificador = "[#]";
                                break;
                            case "#":
                                parametro = new Inmediato();
                                parametro.identificador = "#";
                                break;
                            default:
                                throw new Exception("token desconocido");
                        }

                        parametros.Add(parametro.identificador, parametro);
                    }*/

                    FunctionBuilder fBuilder = new FunctionBuilder(lineas[lcont]);
                    string funcion = fBuilder.getFunction();
                    Builders.CSBuilder cs = new Builders.CSBuilder(operacion.nombre, funcion, _ns);

                    clase = cs.getClase();


                }
                
                lcont++;
            }

            /*
            constantes
                PILA.PUSH(int)
                PILA.POP(int)
                [M]
                R#
                #
            */
            return clase;
        }

        private bool existeParametro(string nombre)
        {
            if (this._registros_definidos.ContainsKey(nombre))
                return true;
            else
                return false;
        }
        

        private void definir(string linea)
        {
            string[] arr = linea.ToLower().Split(' ');
            if (arr.Length < 3)
            {
                throw new Exception("fuck you te faltan parametros");
            }
            switch (arr[1])
            {
                case "#operacion":
                    IOperacion op = new Operacion_vacia();
                    op.nombre = arr[2];
                    this._operaciones_definidas.Add(op.nombre,op);
                break;
                case "#registro":
                    Registro reg = new Registro(arr[2].Replace(";",""));
                    this._registros_definidos.Add(reg.nombre, reg);
                break;
                default:
                    throw new Exception("instruccion desconocida");
            }
        }
    }
}
