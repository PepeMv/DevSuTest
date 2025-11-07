using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Contexto
{
    public partial class BancaContexto : DbContext
    {
        private readonly IConfiguration _configuration;

        public BancaContexto(DbContextOptions<BancaContexto> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("cs");

                optionsBuilder.UseMySql(ServerVersion.AutoDetect(connectionString), null);
            }
        }
    }
}
