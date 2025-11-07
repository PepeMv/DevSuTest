using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contexto
{
    public class SaldoNegativoException : Exception
    {
        public SaldoNegativoException(string? message) : base(message)
        {
        }
    }

}
