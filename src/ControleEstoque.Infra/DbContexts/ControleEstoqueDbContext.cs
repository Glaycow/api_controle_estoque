using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.DbContexts;

public class ControleEstoqueDbContext(DbContextOptions<ControleEstoqueDbContext> options) : DbContext(options)
{
  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    } 
}