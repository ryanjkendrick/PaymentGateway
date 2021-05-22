﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentGateway.Server.Data;

namespace PaymentGateway.Server.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20210522154915_AddBasketTable")]
    partial class AddBasketTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("PaymentGateway.Data.Basket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("OwnedByUser")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BasketId");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("PaymentGateway.Data.Merchant", b =>
                {
                    b.Property<Guid>("MerchantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("MerchantId");

                    b.ToTable("Merchants");

                    b.HasData(
                        new
                        {
                            MerchantId = new Guid("ac0ae11d-9865-4037-a3f6-bb746b80e1ee"),
                            ImageUrl = "/images/merch-a.jpg",
                            Name = "Merchant A"
                        });
                });

            modelBuilder.Entity("PaymentGateway.Data.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BasketId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MerchantId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("BasketId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("c758e8af-0e04-4111-8fa0-4785280790cd"),
                            Amount = 9.99m,
                            Description = "You want this really cool product.",
                            ImageUrl = "/images/prod-a.jpg",
                            MerchantId = new Guid("ac0ae11d-9865-4037-a3f6-bb746b80e1ee"),
                            Name = "Product A"
                        },
                        new
                        {
                            ProductId = new Guid("c858e8af-0e04-4111-8fa0-4785280790cd"),
                            Amount = 19.99m,
                            Description = "You want this really cool product.",
                            ImageUrl = "/images/prod-b.jpg",
                            MerchantId = new Guid("ac0ae11d-9865-4037-a3f6-bb746b80e1ee"),
                            Name = "Product B"
                        });
                });

            modelBuilder.Entity("PaymentGateway.Data.Product", b =>
                {
                    b.HasOne("PaymentGateway.Data.Basket", null)
                        .WithMany("Products")
                        .HasForeignKey("BasketId");

                    b.HasOne("PaymentGateway.Data.Merchant", "Merchant")
                        .WithMany("Products")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("PaymentGateway.Data.Basket", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PaymentGateway.Data.Merchant", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
