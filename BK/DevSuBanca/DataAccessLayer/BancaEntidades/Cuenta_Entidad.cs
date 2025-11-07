using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancaEntidades
{
    [Table("cuenta")]
    public class Cuenta : EntidadBase
    {

        private ILazyLoader LazyLoader { get; set; }

        public Cuenta() { }

        public Cuenta(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }


        [Column("NumeroCuenta")]
        public string NumeroCuenta { get; set; }

        [Required]
        [Column("ClienteId")]
        public int ClienteId { get; set; }


        [Column("TipoCuenta")]
        public string TipoCuenta { get; set; }


        [Column("SaldoInicial")]
        public decimal SaldoInicial { get; set; }


        [Column("Estado")]
        public bool Estado { get; set; }



        private Cliente? _cliente;
        [ForeignKey(nameof(ClienteId))]
        public virtual Cliente? Cliente
        {
            get => LazyLoader.Load(this, ref _cliente);
            set => _cliente = value;
        }       


        private ICollection<Movimiento>? _movimientos;

        [InverseProperty("Cuenta")]
        public virtual ICollection<Movimiento>? Movimientos
        {
            get => LazyLoader.Load(this, ref _movimientos);
            set => _movimientos = value;
        }


        public Cuenta(string numeroCuenta,
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
}
