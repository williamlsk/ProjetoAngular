// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjetoAngular.Persistence.Context;

namespace ProjetoAngular.Persistence.Migrations
{
    [DbContext(typeof(ProjetoAngularContext))]
    [Migration("20221204215959_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ProjetoAngular.Domain.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantidadePessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tema")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Lote");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.Palestrante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiniCurriculo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Palestrante");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventoId", "PalestranteId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("PalestranteEvento");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("RedeSocial");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.Lote", b =>
                {
                    b.HasOne("ProjetoAngular.Domain.Evento", "Evento")
                        .WithMany("Lote")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("ProjetoAngular.Domain.Evento", "Evento")
                        .WithMany("PalestranteEvento")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoAngular.Domain.Palestrante", "Palestrante")
                        .WithMany("PalestranteEvento")
                        .HasForeignKey("PalestranteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProjetoAngular.Domain.Evento", "Evento")
                        .WithMany("RedeSocial")
                        .HasForeignKey("EventoId");

                    b.HasOne("ProjetoAngular.Domain.Palestrante", "Palestrante")
                        .WithMany("RedeSocial")
                        .HasForeignKey("PalestranteId");

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.Evento", b =>
                {
                    b.Navigation("Lote");

                    b.Navigation("PalestranteEvento");

                    b.Navigation("RedeSocial");
                });

            modelBuilder.Entity("ProjetoAngular.Domain.Palestrante", b =>
                {
                    b.Navigation("PalestranteEvento");

                    b.Navigation("RedeSocial");
                });
#pragma warning restore 612, 618
        }
    }
}
