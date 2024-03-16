using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static System.DateTime;

namespace ControleEstoque.Api.ViewModel.LancamentoEstoque;

public class LancamentoEstoqueQueryViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid ProdutoId { get; set; }
    
    [Required(ErrorMessage = "Data de início obrigatória")]
    [DataType(DataType.Date)]
    public string DataLancamento { get; set; }
    internal DateTime Data { get; private set; }

    public void ConverterData()
    {
        TryParse(DataLancamento.ToString(CultureInfo.InvariantCulture), out var data);
        Data = data;
    }
}