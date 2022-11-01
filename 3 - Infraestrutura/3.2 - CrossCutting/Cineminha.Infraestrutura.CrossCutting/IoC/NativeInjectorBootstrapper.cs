using Cineminha.Aplicacao.Interfaces;
using Cineminha.Aplicacao.Servicos;
using Cineminha.Dominio.Interfaces.Repositorios;
using Cineminha.Infraestrutura.Dados.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Cineminha.Infraestrutura.CrossCutting.IoC
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFilmeAplicacao, FilmeAplicacao>();
            services.AddScoped<ISalaAplicacao, SalaAplicacao>();
            services.AddScoped<ISessaoAplicacao, SessaoAplicacao>();
            services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();

            services.AddScoped<IFilmeRepositorio, FilmeRepositorio>();
            services.AddScoped<ISalaRepositorio, SalaRepositorio>();
            services.AddScoped<ISessaoRepositorio, SessaoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}