using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    class Operacion_MOV : IOperacion
    {

        public string nombre{get; set;}

        public IParametro[] parametros { get; set; }


        public int ejecutar()
        {
            int retorno = 0;
            try
            {
                if (parametros[0].TIPO == commons.tipo.MEMORIA && parametros[1].TIPO == commons.tipo.INMEDIATO)
                {
                    Memoria m = new Memoria();
                    m.identificador = parametros[0].identificador;
                    m.valor = parametros[1].valor;
                    commons._memoria_definida.Add(m.identificador,m);
                }
                else {
                    if (parametros[0].TIPO == commons.tipo.REGISTRO && parametros[1].TIPO == commons.tipo.INMEDIATO)
                    {
                       /* Registro reg = commons.getRegistro(parametros[0].identificador);
                        if (reg == null)
                        {
                            throw new Exception("No existe ese registro");
                        }
                        else
                        {
                            reg.valor = parametros[1].valor;
                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                retorno =1;
            }
            return retorno;
        }

        public int asignacion_simple()
        {
            int retorno = 0;
            try
            {
                if (parametros[0].TIPO == commons.tipo.MEMORIA && parametros[1].TIPO == commons.tipo.INMEDIATO)
                {
                    Memoria m;
                    if (commons._memoria_definida.ContainsKey(parametros[0].identificador))
                    {
                        m = commons._memoria_definida[parametros[0].identificador];
                        m.valor = parametros[1].valor;
                    }
                    else
                    {
                        m = new Memoria();
                        m.identificador = parametros[0].identificador;
                        m.valor = parametros[1].valor;
                    }
                }
                else
                {
                    if (parametros[0].TIPO == commons.tipo.REGISTRO && parametros[1].TIPO == commons.tipo.INMEDIATO)
                    {
                        if (commons._registros_definidos.ContainsKey(parametros[0].identificador))
                        {
                            commons._registros_definidos[parametros[0].identificador].valor = parametros[1].valor;
                        }
                        else
                        {
                            throw new Exception("Registro no definido");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                retorno = 1;
            }
            return retorno;
        }

        public Func<int> ejecutar2()
        {
            throw new NotImplementedException();
        }
    }
}
