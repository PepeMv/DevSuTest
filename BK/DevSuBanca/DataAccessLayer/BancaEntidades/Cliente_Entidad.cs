using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancaEntidades
{
    [Table("cliente")]
    public class Cliente : EntidadBase
    {
        private ILazyLoader LazyLoader { get; set; }

        public Cliente() { }

        public Cliente(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }



        [Required]
        [Column("PersonaId")]
        public int PersonaId { get; set; }


        [Column("Contrasenia")]
        public string Contrasenia { get; set; }


        [Column("Estado")]
        public bool Estado { get; set; }


        private Persona? _persona;
        [ForeignKey(nameof(PersonaId))]
        public virtual Persona? Persona
        {
            get => LazyLoader.Load(this, ref _persona);
            set => _persona = value;
        }



        public Cliente(string contrasenia, bool estado, Persona persona)
        {
            Contrasenia = contrasenia;
            Estado = estado;
            Persona = persona;
        }

    }

}
