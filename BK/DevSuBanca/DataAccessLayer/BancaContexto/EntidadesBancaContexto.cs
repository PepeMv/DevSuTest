using BancaEntidades;
using Microsoft.EntityFrameworkCore;

namespace Contexto
{
    public partial class BancaContexto
    {
        private DbSet<Persona>? Personas { get; set; }
        private DbSet<Cliente>? Clientes { get; set; }
        private DbSet<Cuenta>? Cuentas { get; set; }
        private DbSet<Movimiento>? Movimientos { get; set; }

    }
}
