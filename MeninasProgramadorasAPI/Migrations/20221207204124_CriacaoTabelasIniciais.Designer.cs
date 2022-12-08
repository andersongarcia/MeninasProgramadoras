﻿// <auto-generated />
using System;
using MeninasProgramadorasAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MeninasProgramadorasAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221207204124_CriacaoTabelasIniciais")]
    partial class CriacaoTabelasIniciais
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Aluna", b =>
                {
                    b.Property<string>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("BeecrowdId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
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
                        .HasColumnType("varchar(11)");

                    b.Property<int>("PresencaAberturaId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaNumero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunaCPF");

                    b.HasIndex("PresencaAberturaId");

                    b.HasIndex("TurmaNumero");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.RegistroPresenca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlunaCPF")
                        .HasColumnType("varchar(11)");

                    b.Property<int?>("AvaliacaoId")
                        .HasColumnType("int");

                    b.Property<int?>("AvaliacaoId1")
                        .HasColumnType("int");

                    b.Property<int>("NumeroEvento")
                        .HasColumnType("int");

                    b.Property<DateTime>("Registro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TipoDeEvento")
                        .HasColumnType("int");

                    b.Property<int>("TurmaNumero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunaCPF");

                    b.HasIndex("AvaliacaoId");

                    b.HasIndex("AvaliacaoId1");

                    b.HasIndex("TurmaNumero");

                    b.ToTable("RegistrosPresencas");
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
                        .HasForeignKey("AlunaCPF");

                    b.HasOne("MeninasProgramadorasAPI.Models.RegistroPresenca", "PresencaAbertura")
                        .WithMany()
                        .HasForeignKey("PresencaAberturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeninasProgramadorasAPI.Models.Turma", "Turma")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("TurmaNumero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluna");

                    b.Navigation("PresencaAbertura");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.RegistroPresenca", b =>
                {
                    b.HasOne("MeninasProgramadorasAPI.Models.Aluna", "Aluna")
                        .WithMany()
                        .HasForeignKey("AlunaCPF");

                    b.HasOne("MeninasProgramadorasAPI.Models.Avaliacao", null)
                        .WithMany("PresencasAulas")
                        .HasForeignKey("AvaliacaoId");

                    b.HasOne("MeninasProgramadorasAPI.Models.Avaliacao", null)
                        .WithMany("PresencasMonitorias")
                        .HasForeignKey("AvaliacaoId1");

                    b.HasOne("MeninasProgramadorasAPI.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaNumero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluna");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Avaliacao", b =>
                {
                    b.Navigation("PresencasAulas");

                    b.Navigation("PresencasMonitorias");
                });

            modelBuilder.Entity("MeninasProgramadorasAPI.Models.Turma", b =>
                {
                    b.Navigation("Avaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
