namespace ControleEstoque.Dominio.Base;

public class ClasseBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}