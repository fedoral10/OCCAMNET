using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    public interface IOperacion
    {
        string nombre { get; set; }
        
        IParametro[] parametros { get; set; }
        int ejecutar();
        Func<int> ejecutar2();
    }
}
