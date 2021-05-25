﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentGateway.Data;

namespace PaymentGateway.Server.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20210525004255_AddCheckoutTables")]
    partial class AddCheckoutTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("PaymentGateway.Data.Models.BankResponse", b =>
                {
                    b.Property<Guid>("BankResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("BankResponseId");

                    b.HasIndex("InvoiceId")
                        .IsUnique();

                    b.ToTable("BankResponses");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.Basket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<bool>("Fufilled")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnedByUser")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BasketId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.BasketItem", b =>
                {
                    b.Property<Guid>("BasketItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid?>("BasketId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("BasketItemId");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.Invoice", b =>
                {
                    b.Property<Guid>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BankResponseId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cvv")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExpiryMonth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExpiryYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOnCard")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip")
                        .HasColumnType("TEXT");

                    b.HasKey("InvoiceId");

                    b.HasIndex("BasketId")
                        .IsUnique();

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.Merchant", b =>
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

            modelBuilder.Entity("PaymentGateway.Data.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<decimal>("Amount")
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

            modelBuilder.Entity("PaymentGateway.Data.Models.BankResponse", b =>
                {
                    b.HasOne("PaymentGateway.Data.Models.Invoice", "Invoice")
                        .WithOne("BankResponse")
                        .HasForeignKey("PaymentGateway.Data.Models.BankResponse", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.BasketItem", b =>
                {
                    b.HasOne("PaymentGateway.Data.Models.Basket", null)
                        .WithMany("Items")
                        .HasForeignKey("BasketId");

                    b.HasOne("PaymentGateway.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.Invoice", b =>
                {
                    b.HasOne("PaymentGateway.Data.Models.Basket", "Basket")
                        .WithOne("Invoice")
                        .HasForeignKey("PaymentGateway.Data.Models.Invoice", "BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.Product", b =>
                {
                    b.HasOne("PaymentGateway.Data.Models.Merchant", "Merchant")
                        .WithMany("Products")
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.Basket", b =>
                {
                    b.Navigation("Invoice");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.Invoice", b =>
                {
                    b.Navigation("BankResponse");
                });

            modelBuilder.Entity("PaymentGateway.Data.Models.Merchant", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
