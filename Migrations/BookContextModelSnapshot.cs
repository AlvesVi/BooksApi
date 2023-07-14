﻿// <auto-generated />
using System;
using BooksApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksApi.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdeLivros")
                        .HasColumnType("int");

                    b.Property<int>("QtdeLivrosLidos")
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

                    b.Property<int>("GeneroId")
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
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2115),
                            GeneroId = 4,
                            Titulo = "Harry Potter"
                        },
                        new
                        {
                            Id = 2,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2131),
                            GeneroId = 5,
                            Titulo = "O Pequeno Príncipe"
                        },
                        new
                        {
                            Id = 3,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2132),
                            GeneroId = 6,
                            Titulo = "A Cabana"
                        },
                        new
                        {
                            Id = 4,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2133),
                            GeneroId = 1,
                            Titulo = "A Cinco Passos de Você"
                        },
                        new
                        {
                            Id = 5,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2134),
                            GeneroId = 3,
                            Titulo = "Chá de Sumiço"
                        },
                        new
                        {
                            Id = 6,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2135),
                            GeneroId = 4,
                            Titulo = "Star Wars"
                        },
                        new
                        {
                            Id = 7,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2136),
                            GeneroId = 2,
                            Titulo = "Frankenstein"
                        },
                        new
                        {
                            Id = 8,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2137),
                            GeneroId = 1,
                            Titulo = "Orgulho e Preconceito"
                        },
                        new
                        {
                            Id = 9,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2138),
                            GeneroId = 1,
                            Titulo = "A culpa é das estrelas"
                        },
                        new
                        {
                            Id = 10,
                            Autor = "",
                            DataPublicacao = new DateTime(2023, 7, 14, 14, 27, 38, 777, DateTimeKind.Local).AddTicks(2139),
                            GeneroId = 5,
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