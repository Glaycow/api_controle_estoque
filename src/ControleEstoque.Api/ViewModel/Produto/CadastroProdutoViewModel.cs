﻿using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Api.ViewModel.Produto;

public class CadastroProdutoViewModel
{
    [Required(ErrorMessage = "{0} deve ser informado")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid TipoQuantidadeId { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid FornecedorId { get; set; }
    [Required(ErrorMessage = "{0} deve ser informado")]
    public Guid CategoriaId { get; set; }

    public Dominio.Classes.Produto Converter()
    {
        return new Dominio.Classes.Produto
        {
            Nome = Nome,
            TipoQuantidadeId = TipoQuantidadeId,
            FornecedorId = FornecedorId,
            CategoriaId = CategoriaId,

        };
    }
}