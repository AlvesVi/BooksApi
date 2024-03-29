﻿// <auto-generated />
using System;
using BooksApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksApi.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20230714015743_add_livros_e_lista_de_livros")]
    partial class add_livros_e_lista_de_livros
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BooksApi.Model.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Romance"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Terror"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Comédia"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Ação e aventura"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Infantil"
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Ficção Cristã"
                        });
                });

            modelBuilder.Entity("BooksApi.Model.ListadeLeitura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Descricao")
                        .HasColumnType("int");

                    b.Property<int>("QtdeLivros")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ListasdeLeitura");
                });

            modelBuilder.Entity("BooksApi.Model.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EditoraId")
                        .HasColumnType("int");

                    b.Property<int>("GerenoId")
                        .HasColumnType("int");

                    b.Property<int?>("QuantidadePaginas")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Livros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 4,
                            Titulo = "Harry Potter"
                        },
                        new
                        {
                            Id = 2,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 5,
                            Titulo = "O Pequeno Príncipe"
                        },
                        new
                        {
                            Id = 3,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 6,
                            Titulo = "A Cabana"
                        },
                        new
                        {
                            Id = 4,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 1,
                            Titulo = "A Cinco Passos de Você"
                        },
                        new
                        {
                            Id = 5,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 3,
                            Titulo = "Chá de Sumiço"
                        },
                        new
                        {
                            Id = 6,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 4,
                            Titulo = "Star Wars"
                        },
                        new
                        {
                            Id = 7,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 2,
                            Titulo = "Frankenstein"
                        },
                        new
                        {
                            Id = 8,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 1,
                            Titulo = "Orgulho e Preconceito"
                        },
                        new
                        {
                            Id = 9,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 1,
                            Titulo = "A culpa é das estrelas"
                        },
                        new
                        {
                            Id = 10,
                            Autor = "",
                            DataPublicacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GerenoId = 5,
                            Titulo = "A pequena sereia"
                        });
                });

            modelBuilder.Entity("BooksApi.Model.LivrodaLista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Lido")
                        .HasColumnType("bit");

                    b.Property<int>("ListaId")
                        .HasColumnType("int");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LivrosdaLista");
                });
#pragma warning restore 612, 618
        }
    }
}
