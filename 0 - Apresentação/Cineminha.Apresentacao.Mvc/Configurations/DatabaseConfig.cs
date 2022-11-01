using Cineminha.Infraestrutura.Dados.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Cineminha.Apresentacao.Mvc.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<CineminhaContexto>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}