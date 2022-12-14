using Cineminha.Infraestrutura.CrossCutting.IoC;

namespace Cineminha.Apresentacao.Mvc.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootstrapper.RegisterServices(services);
        }
    }
}