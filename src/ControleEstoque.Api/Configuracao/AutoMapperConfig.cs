using AutoMapper;
using ControleEstoque.Api.ViewModel.Categoria;
using ControleEstoque.Api.ViewModel.Fornecedor;
using ControleEstoque.Api.ViewModel.TipoQuantidade;
using ControleEstoque.Dominio.Classes;

namespace ControleEstoque.Api.Configuracao;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<TipoQuantidade, CadastroTipoQuantidadeViewModel>().ReverseMap();
        CreateMap<TipoQuantidade, AlterarTipoQuantidadeViewModel>().ReverseMap();
        
        CreateMap<Categoria, CadastroCategoriaViewModel>().ReverseMap();
        CreateMap<Categoria, AlterarCategoriaViewModel>().ReverseMap();
        
        CreateMap<Fornecedor, CadastroFornecedorViewModel>().ReverseMap();
        CreateMap<Fornecedor, AlterarFornecedorViewModel>().ReverseMap();
    }
}