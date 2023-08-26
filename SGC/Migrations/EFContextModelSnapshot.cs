﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGC.db;

#nullable disable

namespace SGC.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SGC.Models.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FIOOnwer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("SGC.Models.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountApartments")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("SGC.Models.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocalityPrefixId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalityPrefixId");

                    b.ToTable("Locality");
                });

            modelBuilder.Entity("SGC.Models.LocalityPrefix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocalityPrefix");
                });

            modelBuilder.Entity("SGC.Models.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetPrefixId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.HasIndex("StreetPrefixId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("SGC.Models.StreetPrefix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StreetPrefixes");
                });

            modelBuilder.Entity("SGC.Models.Apartment", b =>
                {
                    b.HasOne("SGC.Models.Home", "Home")
                        .WithMany("Apartments")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("SGC.Models.Home", b =>
                {
                    b.HasOne("SGC.Models.Street", "Street")
                        .WithMany("Homes")
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("SGC.Models.Locality", b =>
                {
                    b.HasOne("SGC.Models.LocalityPrefix", "LocalityPrefix")
                        .WithMany("Localities")
                        .HasForeignKey("LocalityPrefixId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalityPrefix");
                });

            modelBuilder.Entity("SGC.Models.Street", b =>
                {
                    b.HasOne("SGC.Models.Locality", "Locality")
                        .WithMany("Street")
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGC.Models.StreetPrefix", "StreetPrefix")
                        .WithMany("Street")
                        .HasForeignKey("StreetPrefixId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locality");

                    b.Navigation("StreetPrefix");
                });

            modelBuilder.Entity("SGC.Models.Home", b =>
                {
                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("SGC.Models.Locality", b =>
                {
                    b.Navigation("Street");
                });

            modelBuilder.Entity("SGC.Models.LocalityPrefix", b =>
                {
                    b.Navigation("Localities");
                });

            modelBuilder.Entity("SGC.Models.Street", b =>
                {
                    b.Navigation("Homes");
                });

            modelBuilder.Entity("SGC.Models.StreetPrefix", b =>
                {
                    b.Navigation("Street");
                });
#pragma warning restore 612, 618
        }
    }
}
