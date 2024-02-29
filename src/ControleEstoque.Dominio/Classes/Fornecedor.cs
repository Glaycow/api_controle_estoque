using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Base;
using ControleEstoque.Dominio.ViewModelResults.Categoria;
using ControleEstoque.Dominio.ViewModelResults.Fornecedor;

namespace ControleEstoque.Dominio.Classes;

public class Fornecedor : ClasseBase
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
    public List<FornecedorCategoria> Categorias { get; set; }

    public FornecedorViewModelResults Converter()
    {
        return new FornecedorViewModelResults {
            Id = Id,
            Nome = Nome,
            Categorias = Categorias.Select(cat => new CategoriaViewModelResults()
            {
                Id = cat.CategoriaId,
            }).ToList()
        }; 
    }
}