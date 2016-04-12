using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET.NPI
{

        public enum TokenType
        {
            None,
            Number,
            Variable,
            Function,
            FunctionArgumentSeparator,
            Operator,
            LeftBracket,
            RightBracket,
            String,
            Date
        }
    
}
