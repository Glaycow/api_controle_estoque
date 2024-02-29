﻿namespace ControleEstoque.Dominio.Interfaces.Produto;

public interface IProdutoServico : IDisposable
{
    Task<Classes.Produto> CadastrarProdutoAsync(Classes.Produto produto);
    Task<Classes.Produto> AlterarProdutoAsync(Classes.Produto produto);
    Task ExcluirProdutoAsync(Guid idProduto);
}