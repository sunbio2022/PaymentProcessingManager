﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentProcessingManager.DBContexts;

namespace PaymentProcessingManager.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20220201075625_User&Groups")]
    partial class UserGroups
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("PaymentProcessingManager.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("UserGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PaymentProcessingManager.Model.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
