using ControleEstoque.Dominio.Classes;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.DbContexts;

public class ControleEstoqueDbContext(DbContextOptions<ControleEstoqueDbContext> options) : DbContext(options)
{
    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<TipoQuantidade> TipoQuantidades { get; set; }
    public virtual DbSet<Fornecedor> Fornecedores { get; set; }
    public virtual DbSet<LancamentoEstoque> FornecedorCategoria { get; set; }
    public virtual DbSet<Produto> Produtos { get; set; }
    public virtual DbSet<Estoque> Estoques { get; set; }
    public virtual DbSet<LancamentoEstoque> LancamentoEstoques { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    } 
}