using FluentValidation;

namespace ControleEstoque.Dominio.Classes.Validacoes;

public class CategoriaValidation : AbstractValidator<Categoria>
{
    public CategoriaValidation(bool alteracao = false)
    {
         
    }
}