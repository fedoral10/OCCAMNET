using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET
{
    public class Registro:IParametro
    {
        public Registro(string nombre)
        {
            this.nombre = nombre;
        }

        public Registro()
        {

        }


        public string nombre { get; set; }

        public int valor { get; set; }

        public Dictionary<string, IParametro> parametros
        {
            get;
            set;
        }

        public commons.tipo TIPO
        {
            get { return commons.tipo.REGISTRO; }
        }

        public string identificador
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() == typeof(Registro))
            {
                Registro ob = obj as Registro;
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
