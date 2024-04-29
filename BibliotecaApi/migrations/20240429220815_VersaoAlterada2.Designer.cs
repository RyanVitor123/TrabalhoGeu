﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaApi.Migrations
{
    [DbContext(typeof(BancoDeDados))]
    [Migration("20240429220815_VersaoAlterada2")]
    partial class VersaoAlterada2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Emprestimo", b =>
                {
                    b.Property<int>("EmprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("EmprestimoId");

                    b.HasIndex("LivroId")
                        .IsUnique();

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnoPublicacao")
                        .HasColumnType("int");

                    b.Property<string>("Autor")
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext");

                    b.HasKey("LivroId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Emprestimo", b =>
                {
                    b.HasOne("Livro", "Livro")
                        .WithOne("Emprestimos")
                        .HasForeignKey("Emprestimo", "LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Usuario", "Usuario")
                        .WithOne("Emprestimos")
                        .HasForeignKey("Emprestimo", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Livro", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Navigation("Emprestimos");
                });
#pragma warning restore 612, 618
        }
    }
}
