﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using purchasing_coffee.Models.Data;

#nullable disable

namespace purchasing_coffee.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240304172028_Initial Migraation")]
    partial class InitialMigraation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("purchasing_coffee.Models.Entities.Coffee", b =>
                {
                    b.Property<int>("CoffeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoffeeId"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("CoffeeId");

                    b.ToTable("coffees");
                });

            modelBuilder.Entity("purchasing_coffee.Models.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("coffeeId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<float>("total_price")
                        .HasColumnType("real");

                    b.HasKey("OrderId");

                    b.HasIndex("coffeeId")
                        .IsUnique();

                    b.ToTable("orders");
                });

            modelBuilder.Entity("purchasing_coffee.Models.Entities.Order", b =>
                {
                    b.HasOne("purchasing_coffee.Models.Entities.Coffee", "Coffee")
                        .WithOne("order")
                        .HasForeignKey("purchasing_coffee.Models.Entities.Order", "coffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");
                });

            modelBuilder.Entity("purchasing_coffee.Models.Entities.Coffee", b =>
                {
                    b.Navigation("order");
                });
#pragma warning restore 612, 618
        }
    }
}
