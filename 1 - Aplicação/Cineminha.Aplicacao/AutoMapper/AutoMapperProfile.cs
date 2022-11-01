using AutoMapper;
using Cineminha.Aplicacao.ViewModels;
using Cineminha.Dominio.Entidades;

namespace Cineminha.Aplicacao.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Filme, FilmeViewModel>().ReverseMap();
            CreateMap<Sala, SalaViewModel>().ReverseMap();
            CreateMap<Sessao, SessaoViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}