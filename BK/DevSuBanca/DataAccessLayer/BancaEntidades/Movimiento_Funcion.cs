namespace BancaEntidades
{
    public partial class Movimiento
    {

        public const string DEBITO = "Debito";
        public const string CREDITO = "Credito";
        public const decimal MAXIMO_RETIRO = 1000;

        public Movimiento AfectaSaldo(bool esCredito, decimal saldo)
        {
            var valorAfectacion = esCredito ? saldo : saldo * -1;

            if (!esCredito)
            {
                var retirosHoy =
                    this
                    .Cuenta
                    .Movimientos
                    .Where(x => x.TipoMovimiento == DEBITO &&
                                x.Fecha == this.Fecha &&
                                x.Id != this.Id)
                    .Sum(x => x.Valor);

                if ((retirosHoy + valorAfectacion + this.Cuenta.SaldoInicial) < (MAXIMO_RETIRO * -1))
                    throw new Exception("Cupo Diario Excedido");
            }

            this.Valor = valorAfectacion;

            var valorParaSaldo =
                this
                .Cuenta
                .Movimientos
                .Where(x => x.Id != this.Id)
                .Sum(x => x.Valor);

            if ((valorParaSaldo + valorAfectacion + this.Cuenta.SaldoInicial) < 0)
                throw new Exception("Saldo menor a 0");

            this.Saldo = valorParaSaldo + valorAfectacion + this.Cuenta.SaldoInicial;

            return this;
        }
    }
}
