﻿// <auto-generated />
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
    [Migration("20230712182231_Create-Generos")]
    partial class CreateGeneros
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
#pragma warning restore 612, 618
        }
    }
}
