﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_AE3.Models;

namespace WebAPI_AE3.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    partial class PlaceMyBetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebAPI_AE3.Models.Apuesta", b =>
                {
                    b.Property<int>("ApuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MercadoId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<double>("cuota")
                        .HasColumnType("double");

                    b.Property<double>("dinero")
                        .HasColumnType("double");

                    b.Property<string>("fecha")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("tipoCuota")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("tipoMercado")
                        .HasColumnType("double");

                    b.HasKey("ApuestaId");

                    b.HasIndex("MercadoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Apuestas");

                    b.HasData(
                        new
                        {
                            ApuestaId = 1,
                            MercadoId = 1,
                            UsuarioId = "Carla@gmail.com",
                            cuota = 1.75,
                            dinero = 125.0,
                            fecha = "2020-03-13",
                            tipoCuota = "over",
                            tipoMercado = 2.1000000000000001
                        },
                        new
                        {
                            ApuestaId = 2,
                            MercadoId = 2,
                            UsuarioId = "Irene@gmail.com",
                            cuota = 1.1000000000000001,
                            dinero = 100.0,
                            fecha = "2020-04-14",
                            tipoCuota = "under",
                            tipoMercado = 3.2999999999999998
                        });
                });

            modelBuilder.Entity("WebAPI_AE3.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Fecha")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Local")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Visitante")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("EventoId");

                    b.ToTable("Eventos");

                    b.HasData(
                        new
                        {
                            EventoId = 1,
                            Fecha = "2020-07-20",
                            Local = "Madrid",
                            Visitante = "Betis"
                        },
                        new
                        {
                            EventoId = 2,
                            Fecha = "2020-04-19",
                            Local = "Valencia",
                            Visitante = "PSG"
                        });
                });

            modelBuilder.Entity("WebAPI_AE3.Models.Mercado", b =>
                {
                    b.Property<int>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CuotaOver")
                        .HasColumnType("double");

                    b.Property<double>("CuotaUnder")
                        .HasColumnType("double");

                    b.Property<double>("DineroOver")
                        .HasColumnType("double");

                    b.Property<double>("DineroUnder")
                        .HasColumnType("double");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<double>("TipoMercado")
                        .HasColumnType("double");

                    b.HasKey("MercadoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Mercados");

                    b.HasData(
                        new
                        {
                            MercadoId = 1,
                            CuotaOver = 1.5,
                            CuotaUnder = 7.0999999999999996,
                            DineroOver = 250.0,
                            DineroUnder = 100.0,
                            EventoId = 1,
                            TipoMercado = 2.5
                        },
                        new
                        {
                            MercadoId = 2,
                            CuotaOver = 2.2999999999999998,
                            CuotaUnder = 1.6000000000000001,
                            DineroOver = 150.0,
                            DineroUnder = 50.0,
                            EventoId = 1,
                            TipoMercado = 1.5
                        });
                });

            modelBuilder.Entity("WebAPI_AE3.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Apellido")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = "Carla@gmail.com",
                            Apellido = "Arbiol",
                            Edad = 30,
                            Nombre = "Carla"
                        },
                        new
                        {
                            UsuarioId = "Irene@gmail.com",
                            Apellido = "Gomez",
                            Edad = 12,
                            Nombre = "Irene"
                        });
                });

            modelBuilder.Entity("WebAPI_AE3.Models.Apuesta", b =>
                {
                    b.HasOne("WebAPI_AE3.Models.Mercado", "Mercado")
                        .WithMany("Apuestas")
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI_AE3.Models.Usuario", "Usuario")
                        .WithMany("Apuestas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("WebAPI_AE3.Models.Mercado", b =>
                {
                    b.HasOne("WebAPI_AE3.Models.Evento", "Evento")
                        .WithMany("Mercados")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
