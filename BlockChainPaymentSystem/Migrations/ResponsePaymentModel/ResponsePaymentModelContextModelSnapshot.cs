﻿// <auto-generated />
using System;
using BlockChainPaymentSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlockChainPaymentSystem.Migrations.ResponsePaymentModel
{
    [DbContext(typeof(ResponsePaymentModelContext))]
    partial class ResponsePaymentModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("BlockChainPaymentSystem.Models.JsonModels.ResponsePaymentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("actually_paid")
                        .HasColumnType("float");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("ipn_callback_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("order_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("order_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("outcome_amount")
                        .HasColumnType("float");

                    b.Property<string>("outcome_currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pay_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("pay_amount")
                        .HasColumnType("float");

                    b.Property<string>("pay_currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payin_extra_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payment_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("payment_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price_amount")
                        .HasColumnType("float");

                    b.Property<string>("price_currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("purchase_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ResponsePaymentModel");
                });
#pragma warning restore 612, 618
        }
    }
}
