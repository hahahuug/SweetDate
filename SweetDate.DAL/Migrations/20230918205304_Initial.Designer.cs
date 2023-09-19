﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SweetDate.DAL;

#nullable disable

namespace SweetDate.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230918205304_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SweetDate.Domain.Entity.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LookingGender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Person", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Age = 20,
                            Avatar = "https://sun9-52.userapi.com/impg/UD9bs5yJxjnU18NeIbnmVhxmBuNC8HngUZxJrQ/EUBmctN6jyw.jpg?size=1808x2160&quality=95&sign=3b8bc51a9f84de9f0d1bf8f2e973c480&type=album",
                            City = "Казань",
                            Country = "Россия",
                            Description = "lala",
                            Gender = "Woman",
                            LookingGender = "Man",
                            Tg = "@kh_alsu",
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("SweetDate.Domain.Entity.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Login = "alsu@gmail.com",
                            Name = "Alsu",
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            Username = "hahahuug"
                        });
                });

            modelBuilder.Entity("SweetDate.Domain.Entity.Person", b =>
                {
                    b.HasOne("SweetDate.Domain.Entity.User", "User")
                        .WithOne("Person")
                        .HasForeignKey("SweetDate.Domain.Entity.Person", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SweetDate.Domain.Entity.User", b =>
                {
                    b.Navigation("Person")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}