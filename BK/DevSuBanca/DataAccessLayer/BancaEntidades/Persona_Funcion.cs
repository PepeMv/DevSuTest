using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaEntidades
{
    public partial class Persona
    {

        public Cliente CreaCliente(string contrasenia, bool estado)
        {
            return 
                new Cliente(contrasenia, estado, this);

        }
    }
}
