﻿// <auto-generated />
using System;
using ControleEstoque.Infra.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleEstoque.Infra.Migrations
{
    [DbContext(typeof(ControleEstoqueDbContext))]
    [Migration("20240228183604_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.Estoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("SaldoQuantidade")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoCadastro")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TipoProdutoId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TipoQuantidadeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("TipoQuantidadeId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.TipoProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoProdutos");
                });

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.TipoQuantidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TipoQuantidades");
                });

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.Estoque", b =>
                {
                    b.HasOne("ControleEstoque.Dominio.Classes.Produto", "Produto")
                        .WithMany("Estoque")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.Fornecedor", b =>
                {
                    b.HasOne("ControleEstoque.Dominio.Classes.TipoProduto", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProduto");
                });

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.Produto", b =>
                {
                    b.HasOne("ControleEstoque.Dominio.Classes.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleEstoque.Dominio.Classes.TipoQuantidade", "TipoQuantidade")
                        .WithMany()
                        .HasForeignKey("TipoQuantidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("TipoQuantidade");
                });

            modelBuilder.Entity("ControleEstoque.Dominio.Classes.Produto", b =>
                {
                    b.Navigation("Estoque");
                });
#pragma warning restore 612, 618
        }
    }
}
