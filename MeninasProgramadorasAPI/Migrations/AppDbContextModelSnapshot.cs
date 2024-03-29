﻿// <auto-generated />
using System;
using MeninasProgramadorasAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeninasProgramadorasAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Aluna", b =>
                {
                    b.Property<string>("CPF")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("BeecrowdId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PrimeiroNome")
                        .HasColumnType("longtext");

                    b.HasKey("CPF");

                    b.ToTable("Alunas");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlunaCPF")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<int>("TurmaNumero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunaCPF");

                    b.HasIndex("TurmaNumero");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroExercicio")
                        .HasColumnType("int");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Resolvidos")
                        .HasColumnType("int");

                    b.Property<int>("TipoDeExercicio")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AvaliacaoId");

                    b.ToTable("Exercicios");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.RegistroPresenca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroEvento")
                        .HasColumnType("int");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TipoDeEvento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AvaliacaoId");

                    b.ToTable("Presencas");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Turma", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TotalSemanas")
                        .HasColumnType("int");

                    b.HasKey("Numero");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Avaliacao", b =>
                {
                    b.HasOne("MeninasProgramadorasAPI.Models.Aluna", "Aluna")
                        .WithMany()
                        .HasForeignKey("AlunaCPF")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeninasProgramadorasAPI.Models.Turma", "Turma")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("TurmaNumero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluna");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Exercicio", b =>
                {
                    b.HasOne("MeninasProgramadorasAPI.Models.Avaliacao", "Avaliacao")
                        .WithMany("Exercicios")
                        .HasForeignKey("AvaliacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliacao");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.RegistroPresenca", b =>
                {
                    b.HasOne("MeninasProgramadorasAPI.Models.Avaliacao", "Avaliacao")
                        .WithMany("Presencas")
                        .HasForeignKey("AvaliacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Avaliacao");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Avaliacao", b =>
                {
                    b.Navigation("Exercicios");

                    b.Navigation("Presencas");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Turma", b =>
                {
                    b.Navigation("Avaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
