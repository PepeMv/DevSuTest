using BancaEntidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contexto
{
    public static class Extensiones
    {
        public static async Task<TEntidad> GuardaEnContextoAsync<TEntidad>(this TEntidad entidad, BancaContexto dbContexo) where TEntidad : EntidadBase
        {
            await dbContexo.Set<TEntidad>().AddAsync(entidad);
            return entidad;
        }

        public static async Task<Unit> GuardaEnContextoAsyncUnit<TEntidad>(this TEntidad entidad, BancaContexto dbContexo) where TEntidad : EntidadBase
        {
            await dbContexo.Set<TEntidad>().AddAsync(entidad);
            return Unit.Value;
        }



        public static TEntidad GuardaEnContexto<TEntidad>(this TEntidad entidad, BancaContexto dbContexo) where TEntidad : EntidadBase
        {
            dbContexo.Set<TEntidad>().Add(entidad);
            return entidad;
        }


        public static TInput Actualiza<TInput>(this TInput input, Action<TInput> accion) where TInput : EntidadBase
        {
            accion(input);
            return input;
        }

        public static IQueryable<TEntidad> DameRegistrosSinFiltro<TEntidad>(this BancaContexto contexo) where TEntidad : EntidadBase
        => contexo
           .Set<TEntidad>();


        public static IQueryable<TEntidad> DameRegistros<TEntidad>(this BancaContexto contexo, Expression<Func<TEntidad, bool>> expression) where TEntidad : EntidadBase
        => contexo
           .Set<TEntidad>()
           .Where(expression);           


    }
}
