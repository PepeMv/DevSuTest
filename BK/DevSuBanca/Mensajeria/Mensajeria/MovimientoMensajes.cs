namespace Mensajeria
{
    public class NuevoMovimientoMe
    {
        public DateTime Fecha { get; set; }
        public bool EsCredito { get; set; }
        public decimal Valor { get; set; }
        public int CuentaId { get; set; }


        public NuevoMovimientoMe(DateTime fecha,
                               bool esCredito,
                               decimal valor,
                               int cuentaId)
        {
            Fecha = fecha;
            EsCredito = esCredito;
            Valor = valor;
            CuentaId = cuentaId;
        }
    }

    public class ActualizaMovimientoMe
    {

        public int IdentificadorMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public bool EsCredito { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public int CuentaId { get; set; }

        public ActualizaMovimientoMe(int identificadorMovimiento,
                                   DateTime fecha,
                                   bool esCredito,
                                   decimal valor,
                                   decimal saldo,
                                   int cuentaId)
        {
            IdentificadorMovimiento = identificadorMovimiento;
            Fecha = fecha;
            EsCredito = esCredito;
            Valor = valor;
            Saldo = saldo;
            CuentaId = cuentaId;
        }
    }

    public class EliminaMovimientoMe
    {
        public int IdentificadorMovimiento { get; set; }

        public EliminaMovimientoMe(int identificadorMovimiento)
        {
            IdentificadorMovimiento = identificadorMovimiento;
        }
    }


    public class ResumenMovimiento
    {

        public int IdentificadorMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public int CuentaId { get; set; }

        public ResumenMovimiento(int identificadorMovimiento,
                                   DateTime fecha,
                                   string tipoMovimiento,
                                   decimal valor,
                                   decimal saldo,
                                   int cuentaId)
        {
            IdentificadorMovimiento = identificadorMovimiento;
            Fecha = fecha;
            TipoMovimiento = tipoMovimiento;
            Valor = valor;
            Saldo = saldo;
            CuentaId = cuentaId;
        }
    }


    public class DameMovimientosCuentaRangoFechasMe
    {
        public int IdentificadorCuenta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }


        public DameMovimientosCuentaRangoFechasMe(int identificadorCuenta, DateTime fechaInicio, DateTime fechaFin)
        {
            IdentificadorCuenta = identificadorCuenta;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}
