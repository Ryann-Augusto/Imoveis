﻿// <auto-generated />
using System;
using Imoveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Imoveis.Migrations
{
    [DbContext(typeof(_DbContext))]
    [Migration("20220714152515_adicionandoModelBanheiro")]
    partial class adicionandoModelBanheiro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Imoveis.Models.MdImagens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasColumnName("type");

                    b.Property<byte[]>("Dados")
                        .IsRequired()
                        .HasColumnType("longblob")
                        .HasColumnName("dados");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descricao");

                    b.Property<int>("ImovelId")
                        .HasColumnType("int")
                        .HasColumnName("imovelid");

                    b.HasKey("Id");

                    b.HasIndex("ImovelId");

                    b.ToTable("imagens");
                });

            modelBuilder.Entity("Imoveis.Models.MdImoveis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Banheiro")
                        .HasColumnType("int")
                        .HasColumnName("banheiro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<int>("Quarto")
                        .HasColumnType("int")
                        .HasColumnName("quartos");

                    b.Property<int>("Situacao")
                        .HasColumnType("int")
                        .HasColumnName("situacao");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuarioid");

                    b.Property<int>("Vagas")
                        .HasColumnType("int")
                        .HasColumnName("vagas");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("imovel");
                });

            modelBuilder.Entity("Imoveis.Models.MdUsuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Cpf_Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("cpf_cnpj");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<int>("Nivel")
                        .HasColumnType("int")
                        .HasColumnName("nivel");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("senha");

                    b.Property<int>("Situacao")
                        .HasColumnType("int")
                        .HasColumnName("situacao");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Imoveis.Models.MdImagens", b =>
                {
                    b.HasOne("Imoveis.Models.MdImoveis", "Imovel")
                        .WithMany("Imagens")
                        .HasForeignKey("ImovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("Imoveis.Models.MdImoveis", b =>
                {
                    b.HasOne("Imoveis.Models.MdUsuarios", "Usuario")
                        .WithMany("Imoveis")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Imoveis.Models.MdEndereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("MdImoveisId")
                                .HasColumnType("int");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("varchar(30)")
                                .HasColumnName("bairro");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnType("varchar(8)")
                                .HasColumnName("cep");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(45)
                                .HasColumnType("varchar(45)")
                                .HasColumnName("cidade");

                            b1.Property<string>("Complemento")
                                .IsRequired()
                                .HasMaxLength(45)
                                .HasColumnType("varchar(45)")
                                .HasColumnName("complemento");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)")
                                .HasColumnName("estado");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)")
                                .HasColumnName("numero");

                            b1.Property<string>("Referencia")
                                .IsRequired()
                                .HasMaxLength(45)
                                .HasColumnType("varchar(45)")
                                .HasColumnName("referencia");

                            b1.Property<string>("Rua")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("endereco");

                            b1.HasKey("MdImoveisId");

                            b1.ToTable("imovel");

                            b1.WithOwner()
                                .HasForeignKey("MdImoveisId");
                        });

                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Imoveis.Models.MdImoveis", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("Imoveis.Models.MdUsuarios", b =>
                {
                    b.Navigation("Imoveis");
                });
#pragma warning restore 612, 618
        }
    }
}
