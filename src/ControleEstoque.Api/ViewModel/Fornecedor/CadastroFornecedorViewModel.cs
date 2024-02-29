using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Classes;

namespace ControleEstoque.Api.ViewModel.Fornecedor;

public class CadastroFornecedorViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }

    public List<Guid> Categorias { get; set; }

    public Dominio.Classes.Fornecedor ConverterModel()
    {
        var fornecedor = new Dominio.Classes.Fornecedor()
        {
            Nome = Nome,
        };
        fornecedor.Categorias = Categorias.Select(catId => new FornecedorCategoria()
        {
            FornecedorId = fornecedor.Id,
            CategoriaId = catId
        }).ToList();
        return fornecedor;
    }
}