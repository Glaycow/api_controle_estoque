using System.ComponentModel.DataAnnotations;
using ControleEstoque.Dominio.Enum;

namespace ControleEstoque.Api.ViewModel.LancamentoEstoque;

public class LancamentoEstoqueAlterarViewModel
{
    
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public DateTime DataLancamento { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    [Range(0.01, 9999999.99, ErrorMessage = "Valor maximo permitido é entre {0} é {1}")]
    public decimal Valor { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public TipoLancamento TipoCadastro { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public int Quantidade { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid EstoqueId { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid ProdutoId { get; set; }

    public Dominio.Classes.LancamentoEstoque Converter()
    {
        return new Dominio.Classes.LancamentoEstoque
        {
            Id = Id,
            DataLancamento = DataLancamento,
            EstoqueId = EstoqueId,
            ProdutoId = ProdutoId,
            TipoCadastro = TipoCadastro,
            Quantidade = Quantidade,
            Valor = Valor
        };    
    }
}