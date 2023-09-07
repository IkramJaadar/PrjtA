﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrjtA;

#nullable disable

namespace PrjtA.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PrjtA.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PrjtA.Models.Coiffeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RememberMe")
                        .HasColumnType("bit");

                    b.Property<string>("Specialite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coiffeurs");
                });

            modelBuilder.Entity("PrjtA.Models.Payement", b =>
                {
                    b.Property<int>("Num")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Num"), 1L, 1);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePayement")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumCompte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Prix")
                        .HasColumnType("float");

                    b.Property<int?>("RendezVousId")
                        .HasColumnType("int");

                    b.HasKey("Num");

                    b.HasIndex("ClientId");

                    b.HasIndex("RendezVousId")
                        .IsUnique()
                        .HasFilter("[RendezVousId] IS NOT NULL");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PrjtA.Models.RendezVous", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Etat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("Horraire")
                        .HasColumnType("time");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicesId");

                    b.ToTable("RendezVous");
                });

            modelBuilder.Entity("PrjtA.Models.Service", b =>
                {
                    b.Property<int>("NumS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumS"), 1L, 1);

                    b.Property<int?>("CoiffeurId")
                        .HasColumnType("int");

                    b.Property<string>("NomS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Prix")
                        .HasColumnType("real");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("NumS");

                    b.HasIndex("CoiffeurId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PrjtA.Models.Sliders", b =>
                {
                    b.Property<int>("Num")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Num"), 1L, 1);

                    b.Property<int?>("CoiffeurId")
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Num");

                    b.HasIndex("CoiffeurId");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("PrjtA.Models.Payement", b =>
                {
                    b.HasOne("PrjtA.Models.Client", "Client")
                        .WithMany("payments")
                        .HasForeignKey("ClientId");

                    b.HasOne("PrjtA.Models.RendezVous", "rendezVous")
                        .WithOne("payement")
                        .HasForeignKey("PrjtA.Models.Payement", "RendezVousId");

                    b.Navigation("Client");

                    b.Navigation("rendezVous");
                });

            modelBuilder.Entity("PrjtA.Models.RendezVous", b =>
                {
                    b.HasOne("PrjtA.Models.Service", "services")
                        .WithMany("RendezVous")
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("services");
                });

            modelBuilder.Entity("PrjtA.Models.Service", b =>
                {
                    b.HasOne("PrjtA.Models.Coiffeur", "coiffeur")
                        .WithMany("Services")
                        .HasForeignKey("CoiffeurId");

                    b.Navigation("coiffeur");
                });

            modelBuilder.Entity("PrjtA.Models.Sliders", b =>
                {
                    b.HasOne("PrjtA.Models.Coiffeur", "coiffeur")
                        .WithMany("Sliders")
                        .HasForeignKey("CoiffeurId");

                    b.Navigation("coiffeur");
                });

            modelBuilder.Entity("PrjtA.Models.Client", b =>
                {
                    b.Navigation("payments");
                });

            modelBuilder.Entity("PrjtA.Models.Coiffeur", b =>
                {
                    b.Navigation("Services");

                    b.Navigation("Sliders");
                });

            modelBuilder.Entity("PrjtA.Models.RendezVous", b =>
                {
                    b.Navigation("payement");
                });

            modelBuilder.Entity("PrjtA.Models.Service", b =>
                {
                    b.Navigation("RendezVous");
                });
#pragma warning restore 612, 618
        }
    }
}
