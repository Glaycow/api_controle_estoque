using ControleEstoque.Dominio.Base;

namespace ControleEstoque.Dominio.Classes;

public class FornecedorCategoria : ClasseBase
{
    public Fornecedor Fornecedor { get; set; }
    public Categoria Categoria { get; set; }
}