using AutoMapper;
using ControleEstoque.Api.ViewModel.TipoQuantidade;
using ControleEstoque.Dominio.Classes;

namespace ControleEstoque.Api.Configuracao;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<TipoQuantidade, TipoQuantidadeViewModel>().ReverseMap();
    }
}