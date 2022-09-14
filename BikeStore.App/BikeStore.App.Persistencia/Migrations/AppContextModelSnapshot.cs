﻿// <auto-generated />
using System;
using BikeStore.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeStore.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BikeStore.App.Dominio.ConstanciaRecibido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InventarioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrabajadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InventarioId");

                    b.HasIndex("TrabajadorId");

                    b.ToTable("ConstanciaRecibidos");
                });

            modelBuilder.Entity("BikeStore.App.Dominio.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Existencias")
                        .HasColumnType("int");

                    b.Property<int>("NumeroRefCompra")
                        .HasColumnType("int");

                    b.Property<double>("PrecioUniCompra")
                        .HasColumnType("float");

                    b.Property<double>("PrecioUniVenta")
                        .HasColumnType("float");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("BikeStore.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("BikeStore.App.Dominio.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("BikeStore.App.Dominio.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CantidadProducto")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventarioId")
                        .HasColumnType("int");

                    b.Property<int>("TrabajadorId")
                        .HasColumnType("int");

                    b.Property<int>("ValorVenta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("BikeStore.App.Dominio.Cliente", b =>
                {
                    b.HasBaseType("BikeStore.App.Dominio.Persona");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("BikeStore.App.Dominio.Usuario", b =>
                {
                    b.HasBaseType("BikeStore.App.Dominio.Persona");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Usuario");
                });

            modelBuilder.Entity("BikeStore.App.Dominio.Trabajador", b =>
                {
                    b.HasBaseType("BikeStore.App.Dominio.Usuario");

                    b.Property<int>("Salario")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Trabajador");
                });

            modelBuilder.Entity("BikeStore.App.Dominio.ConstanciaRecibido", b =>
                {
                    b.HasOne("BikeStore.App.Dominio.Inventario", "Inventario")
                        .WithMany()
                        .HasForeignKey("InventarioId");

                    b.HasOne("BikeStore.App.Dominio.Trabajador", "Trabajador")
                        .WithMany()
                        .HasForeignKey("TrabajadorId");

                    b.Navigation("Inventario");

                    b.Navigation("Trabajador");
                });
#pragma warning restore 612, 618
        }
    }
}
