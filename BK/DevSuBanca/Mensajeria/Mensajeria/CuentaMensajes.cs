namespace Mensajeria
{
    public class NuevaCuentaMe
    {
        public string NumeroCuenta { get; set; }
        public int ClienteId { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }


        public NuevaCuentaMe(string numeroCuenta,
                           int clienteId,
                           string tipoCuenta,
                           decimal saldoInicial,
                           bool estado)
        {
            NumeroCuenta = numeroCuenta;
            ClienteId = clienteId;
            TipoCuenta = tipoCuenta;
            SaldoInicial = saldoInicial;
            Estado = estado;
        }
    }


    public class ActualizarCuentaMe
    {
        public int IdentificadorCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public int ClienteId { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }


        public ActualizarCuentaMe(int identificadorCuenta,
                                string numeroCuenta,
                                int clienteId,
                                string tipoCuenta,
                                decimal saldoInicial,
                                bool estado)
        {
            IdentificadorCuenta = identificadorCuenta;
            NumeroCuenta = numeroCuenta;
            ClienteId = clienteId;
            TipoCuenta = tipoCuenta;
            SaldoInicial = saldoInicial;
            Estado = estado;
        }
    }

    public class EliminaCuentaMe
    {
        public int IdentificadorCuenta { get; set; }

        public EliminaCuentaMe(int identificadorCuenta)
        {
            IdentificadorCuenta = identificadorCuenta;
        }
    }


    public class ResumenCuenta
    {
        public int IdentificadorCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public int ClienteId { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public string NombreCliente { get; set; }


        public ResumenCuenta(int identificadorCuenta,
                                string numeroCuenta,
                                int clienteId,
                                string tipoCuenta,
                                decimal saldoInicial,
                                bool estado,
                                string nombreCliente)
        {
            IdentificadorCuenta = identificadorCuenta;
            NumeroCuenta = numeroCuenta;
            ClienteId = clienteId;
            TipoCuenta = tipoCuenta;
            SaldoInicial = saldoInicial;
            Estado = estado;
            NombreCliente = nombreCliente;
        }
    }


    public class DameCuentasPorIdClienteMe
    {
        public int IdentificadorCliente { get; set; }

        public DameCuentasPorIdClienteMe(int identificadorCliente)
        {
            IdentificadorCliente = identificadorCliente;
        }
    }
}
