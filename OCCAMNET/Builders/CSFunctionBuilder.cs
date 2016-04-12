using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET.Builders
{

    class CSFunctionBuilder
    {



        private commons.tipo getTipoParametro(string parametro)
        {
            switch (parametro)
            {
                case "[M]":
                    return commons.tipo.MEMORIA;
                case "#":
                    return commons.tipo.INMEDIATO;
                case "R#":
                    return commons.tipo.REGISTRO;
                default:
                    throw new Exception("Tipo de Parametro desconocido");
            }
        }
    }
    
}
