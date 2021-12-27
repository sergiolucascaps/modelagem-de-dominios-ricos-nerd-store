using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(p => p.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
                .ForMember(p => p.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
                .ForMember(p => p.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));
        }
    }
}
