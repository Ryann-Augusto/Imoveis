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
    [Migration("20220427131904_correcaoFKDosImoveis")]
    partial class correcaoFKDosImoveis
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

                    b.Property<string>("ImovelBro")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("imovelbro");

                    b.Property<string>("ImovelCEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasColumnName("imovelcep");

                    b.Property<string>("ImovelCdd")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("imovelcdd");

                    b.Property<string>("ImovelDsc")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("imoveldsc");

                    b.Property<int>("ImovelNumQrt")
                        .HasColumnType("int")
                        .HasColumnName("imovelnumQrt");

                    b.Property<int>("ImovelNumVag")
                        .HasColumnType("int")
                        .HasColumnName("imovelnumvag");

                    b.Property<string>("ImovelRua")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("imovelrua");

                    b.Property<string>("ImovelTip")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("imoveltip");

                    b.Property<string>("ImovelUF")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("imoveluf");

                    b.Property<decimal>("ImovelVlr")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("imovelvlr");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("usuarioid");

                    b.HasKey("ImovelId");

                    b.HasIndex("UsuarioId");

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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("senha");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Imoveis.Models.Imovel", b =>
                {
                    b.HasOne("Imoveis.Models.Usuarios", "Usuario")
                        .WithMany("Imoveis")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Imoveis.Models.Usuarios", b =>
                {
                    b.Navigation("Imoveis");
                });
#pragma warning restore 612, 618
        }
    }
}