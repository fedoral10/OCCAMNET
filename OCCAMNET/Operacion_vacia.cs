using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    class Operacion_vacia : IOperacion
    {
        

        public string nombre
        {
            get; set;
        }

        public IParametro[] parametros
        {
            get ;set;
        }

        public Func<int> ejecutar()
        {
            throw new NotImplementedException();
        }

        public Func<int> ejecutar2()
        {
            throw new NotImplementedException();
        }

        int IOperacion.ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}
