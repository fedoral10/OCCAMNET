using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    public class reg
    {
        public reg(string nombre)
        {
            this.nombre = nombre;
        }

        public string nombre { get; }
        public int valor { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() == typeof(reg))
            {
                reg ob = obj as reg;
                if (ob.nombre == this.nombre)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public override string ToString()
        {
            return this.nombre;
        }
        public override int GetHashCode()
        {
            int hash = this.nombre.GetHashCode();
            hash = hash + this.valor.GetHashCode();
            return hash;
        }
    }
}
