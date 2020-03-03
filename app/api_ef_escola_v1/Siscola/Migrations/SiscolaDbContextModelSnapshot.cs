﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Siscola.Infra.Data;

namespace Siscola.Migrations
{
    [DbContext(typeof(SiscolaDbContext))]
    partial class SiscolaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Siscola.Dominio.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UF")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Siscola.Dominio.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalhes")
                        .HasMaxLength(1000);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Siscola.Dominio.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalhes")
                        .HasMaxLength(1000);

                    b.Property<int>("EspecialidadeId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeId");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("Siscola.Dominio.DisciplinaCurso", b =>
                {
                    b.Property<int>("DisciplinaId");

                    b.Property<int>("CursoId");

                    b.HasKey("DisciplinaId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("DisciplinaCurso");
                });

            modelBuilder.Entity("Siscola.Dominio.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<int>("CidadeId");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Numero")
                        .HasMaxLength(10);

                    b.Property<int>("PessoaFisicaId");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("PessoaFisicaId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Siscola.Dominio.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("Siscola.Dominio.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId");

                    b.Property<int>("CursoId");

                    b.Property<DateTime>("DataDaMatricula");

                    b.Property<string>("RA")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<int>("TurmaId");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("CursoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("Siscola.Dominio.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("NomeCivil")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("NomeSocial")
                        .HasMaxLength(100);

                    b.Property<string>("RG")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("PessoaFisica");
                });

            modelBuilder.Entity("Siscola.Dominio.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataDeAbertura");

                    b.Property<string>("NomeFantasia")
                        .HasMaxLength(100);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("PessoaJuridica");
                });

            modelBuilder.Entity("Siscola.Dominio.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaFisicaId");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Siscola.Dominio.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Siscola.Dominio.Disciplina", b =>
                {
                    b.HasOne("Siscola.Dominio.Especialidade", "Especialidade")
                        .WithMany("Disciplinas")
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Siscola.Dominio.DisciplinaCurso", b =>
                {
                    b.HasOne("Siscola.Dominio.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Siscola.Dominio.Disciplina", "Disciplina")
                        .WithMany("Cursos")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Siscola.Dominio.Endereco", b =>
                {
                    b.HasOne("Siscola.Dominio.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Siscola.Dominio.PessoaFisica", "PessoaFisica")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaFisicaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Siscola.Dominio.Matricula", b =>
                {
                    b.HasOne("Siscola.Dominio.PessoaFisica", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Siscola.Dominio.Curso", "Curso")
                        .WithMany("Matriculas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Siscola.Dominio.Turma", "Turma")
                        .WithMany("Matriculas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}