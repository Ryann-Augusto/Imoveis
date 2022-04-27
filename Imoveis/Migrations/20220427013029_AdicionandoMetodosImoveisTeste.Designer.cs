﻿// <auto-generated />
using Imoveis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Imoveis.Migrations
{
    [DbContext(typeof(_DbContext))]
    [Migration("20220427013029_AdicionandoMetodosImoveisTeste")]
    partial class AdicionandoMetodosImoveisTeste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Imoveis.Models.Imovel", b =>
                {
                    b.Property<int>("ImovelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BroImovel")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CEPImovel")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("CddImovel")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ImovelDsc")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("ImovelVlr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumQrtImovel")
                        .HasColumnType("int");

                    b.Property<int>("NumVagImovel")
                        .HasColumnType("int");

                    b.Property<string>("RuaImovel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipImovel")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("UFImovel")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ImovelId");

                    b.ToTable("imovel");
                });

            modelBuilder.Entity("Imoveis.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<int>("ImovelId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.HasIndex("ImovelId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Imoveis.Models.Usuarios", b =>
                {
                    b.HasOne("Imoveis.Models.Imovel", "Imovel")
                        .WithMany("Usuarios")
                        .HasForeignKey("ImovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("Imoveis.Models.Imovel", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
