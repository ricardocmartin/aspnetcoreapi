﻿// <auto-generated />
using System;
using Banco.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banco.Services.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20191030190338_AlteraLancamento")]
    partial class AlteraLancamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Banco.Services.Models.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<decimal>("Saldo");

                    b.HasKey("Id");

                    b.ToTable("ContaCorrente");
                });

            modelBuilder.Entity("Banco.Services.Models.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContaCorrenteId");

                    b.Property<DateTime>("Data");

                    b.Property<bool>("IsCredit");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ContaCorrenteId");

                    b.ToTable("Lancamento");
                });

            modelBuilder.Entity("Banco.Services.Models.Lancamento", b =>
                {
                    b.HasOne("Banco.Services.Models.ContaCorrente", "ContaCorrente")
                        .WithMany("Lancamentos")
                        .HasForeignKey("ContaCorrenteId");
                });
#pragma warning restore 612, 618
        }
    }
}
