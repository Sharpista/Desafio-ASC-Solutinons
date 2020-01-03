﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheAmazingSchool.Models;

namespace TheAmazingSchool.Migrations
{
    [DbContext(typeof(TheAmazingSchoolContext))]
    [Migration("20191208022406_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TheAmazingSchool.Models.Dominio.Entidades.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Matricula")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("MediaPonderada")
                        .HasColumnType("double");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("PrimeiraNota")
                        .HasColumnType("double");

                    b.Property<double>("SegundaNota")
                        .HasColumnType("double");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TerceiraNota")
                        .HasColumnType("double");

                    b.Property<Guid?>("TurmaId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("TheAmazingSchool.Models.Dominio.Entidades.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("NumeroDaTurma")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("TheAmazingSchool.Models.Dominio.Entidades.Aluno", b =>
                {
                    b.HasOne("TheAmazingSchool.Models.Dominio.Entidades.Turma", null)
                        .WithMany("ListaDeAlunos")
                        .HasForeignKey("TurmaId");
                });
#pragma warning restore 612, 618
        }
    }
}
