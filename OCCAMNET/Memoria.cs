using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    public class Memoria : IParametro
    {
        public string identificador
        {
            get;
            set;
        }

        public commons.tipo TIPO
        {
            get
            {
                return commons.tipo.MEMORIA;
            }
        }

        public int valor
        {
            get;
            set;
        }
    }
}
