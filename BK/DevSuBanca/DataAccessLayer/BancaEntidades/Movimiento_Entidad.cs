using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancaEntidades
{
    [Table("movimiento")]
    public partial class Movimiento : EntidadBase
    {

        private ILazyLoader LazyLoader { get; set; }

        //public Movimiento() { }

        // Constructor con lazy loader (EF lo inyecta automáticamente)
        protected Movimiento(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }


        [Column("Fecha")]
        public DateTime Fecha { get; set; }


        [Column("TipoMovimiento")]
        public string TipoMovimiento { get; set; }


        [Column("Valor")]
        public decimal Valor { get; set; } = 0;


        [Column("Saldo")]
        public decimal Saldo { get; set; } = 0;


        [Required]
        [Column("CuentaId")]
        public int CuentaId { get; set; }


        private Cuenta? _cuenta;
        [ForeignKey(nameof(CuentaId))]
        public virtual Cuenta? Cuenta
        {
            get => LazyLoader.Load(this, ref _cuenta);
            set => _cuenta = value;
        }


        public Movimiento(DateTime fecha,
                          bool esCredito,
                          int cuentaId)
        {
            Fecha = fecha;
            TipoMovimiento = esCredito ? CREDITO : DEBITO;
            CuentaId = cuentaId;
        }
    }
}
