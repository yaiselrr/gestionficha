﻿// <auto-generated />
using System;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Datos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231030201018_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entidades.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("numeric")
                        .HasColumnName("CANTIDAD");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("DIRECCION");

                    b.Property<bool>("EsGESTOR")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("ES_GESTOR");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("FECHA");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ORDEN");
                });

            modelBuilder.Entity("Core.Entidades.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Apellidos")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("APELLIDOS");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("IS_ADMIN");

                    b.Property<decimal?>("NInternoResp")
                        .HasColumnType("numeric")
                        .HasColumnName("N_INTERNO_RESP");

                    b.Property<string>("Nombre")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NOMBRE");

                    b.Property<string>("UsuarioRed")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("USUARIO_RED");

                    b.HasKey("Id");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Core.Entidades.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("DESCRIPCION");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR(150)")
                        .HasColumnName("NOMBRE");

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric")
                        .HasColumnName("PRECIO");

                    b.HasKey("Id");

                    b.ToTable("PRODUCTO");
                });

            modelBuilder.Entity("Core.Entidades.Orden", b =>
                {
                    b.HasOne("Core.Entidades.Persona", "Usuario")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}