﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using repository;

namespace repository.Migrations
{
    [DbContext(typeof(MarthaPadilhaLeiloesContext))]
    [Migration("20200502214653_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("domain.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BusinessCode");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Negotiation");

                    b.HasKey("Id");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("domain.AuctionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuctionId");

                    b.Property<int>("ComitenteId");

                    b.Property<int>("ItemId");

                    b.Property<double>("PriceNegotiated");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("ComitenteId");

                    b.HasIndex("ItemId");

                    b.ToTable("AuctionItems");
                });

            modelBuilder.Entity("domain.Comitente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Comitentes");
                });

            modelBuilder.Entity("domain.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BusinessCode");

                    b.Property<string>("Description");

                    b.Property<string>("Local");

                    b.Property<double>("PriceReference");

                    b.Property<int>("TipoItemId");

                    b.HasKey("Id");

                    b.HasIndex("TipoItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("domain.TipoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TipoItems");
                });

            modelBuilder.Entity("domain.AuctionItem", b =>
                {
                    b.HasOne("domain.Auction", "Auction")
                        .WithMany("AuctionItems")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("domain.Comitente", "Comitente")
                        .WithMany()
                        .HasForeignKey("ComitenteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("domain.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("domain.Item", b =>
                {
                    b.HasOne("domain.TipoItem", "TipoItem")
                        .WithMany()
                        .HasForeignKey("TipoItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
