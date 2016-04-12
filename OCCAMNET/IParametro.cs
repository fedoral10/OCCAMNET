using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    public interface IParametro
    {

         commons.tipo TIPO { get; }
         string identificador { get; set; }

         int valor { get; set; }
    }
}
