﻿// <auto-generated />
using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreDemo.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCoreDemo.Data.Model.Bar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Bar", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Bar1"
                        });
                });

            modelBuilder.Entity("EFCoreDemo.Data.Model.Foo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BarId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.ToTable("Foo", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BarId = 1,
                            Name = "Foo1"
                        },
                        new
                        {
                            Id = 2,
                            BarId = 1,
                            Name = "Foo2"
                        });
                });

            modelBuilder.Entity("EFCoreDemo.Data.Model.Foo", b =>
                {
                    b.HasOne("EFCoreDemo.Data.Model.Bar", "Bar")
                        .WithMany("Foos")
                        .HasForeignKey("BarId")
                        .IsRequired();

                    b.Navigation("Bar");
                });

            modelBuilder.Entity("EFCoreDemo.Data.Model.Bar", b =>
                {
                    b.Navigation("Foos");
                });
#pragma warning restore 612, 618
        }
    }
}