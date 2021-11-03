﻿// <auto-generated />
using System;
using DatingApp.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatingApp.Infrastructure.Migrations
{
    [DbContext(typeof(DatingAppDbContext))]
    partial class DatingAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatingApp.Database.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnownAs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime2");

                    b.Property<string>("LookingFor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 7,
                            City = "Byrnedale",
                            Country = "Dominican Republic",
                            Created = new DateTime(2021, 11, 3, 8, 51, 5, 500, DateTimeKind.Local).AddTicks(9590),
                            DateOfBirth = new DateTime(2018, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Interests = "Interests test",
                            Introduction = "test introduction",
                            KnownAs = "Dave",
                            LastActive = new DateTime(2021, 11, 3, 8, 51, 5, 501, DateTimeKind.Local).AddTicks(950),
                            LookingFor = "test looking for",
                            PasswordHash = "System.Byte[]",
                            PasswordSalt = "System.Byte[]",
                            UserName = "Dave"
                        },
                        new
                        {
                            Id = 8,
                            City = "Thatcher",
                            Country = "S. Georgia and S. Sandwich Isls.",
                            Created = new DateTime(2021, 11, 3, 8, 51, 5, 502, DateTimeKind.Local).AddTicks(6246),
                            DateOfBirth = new DateTime(2014, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Interests = "Interests test",
                            Introduction = "test introduction",
                            KnownAs = "Bob",
                            LastActive = new DateTime(2021, 11, 3, 8, 51, 5, 502, DateTimeKind.Local).AddTicks(6256),
                            LookingFor = "test looking for",
                            PasswordHash = "System.Byte[]",
                            PasswordSalt = "System.Byte[]",
                            UserName = "Bob"
                        },
                        new
                        {
                            Id = 9,
                            City = "Mostar",
                            Country = "BiH",
                            Created = new DateTime(2021, 11, 3, 8, 51, 5, 502, DateTimeKind.Local).AddTicks(7056),
                            DateOfBirth = new DateTime(2002, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Female",
                            Interests = "Interests test",
                            Introduction = "test introduction",
                            KnownAs = "Rossa",
                            LastActive = new DateTime(2021, 11, 3, 8, 51, 5, 502, DateTimeKind.Local).AddTicks(7065),
                            LookingFor = "test looking for",
                            PasswordHash = "System.Byte[]",
                            PasswordSalt = "System.Byte[]",
                            UserName = "Rossa"
                        });
                });

            modelBuilder.Entity("DatingApp.Database.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppUserId = 7,
                            IsMain = true,
                            PublicId = "11",
                            Url = "https://randomuser.me/api/portraits/men/95.jpg"
                        },
                        new
                        {
                            Id = 2,
                            AppUserId = 8,
                            IsMain = true,
                            PublicId = "12",
                            Url = "https://randomuser.me/api/portraits/men/97.jpg"
                        },
                        new
                        {
                            Id = 3,
                            AppUserId = 9,
                            IsMain = true,
                            PublicId = "13",
                            Url = "https://randomuser.me/api/portraits/women/6.jpg"
                        });
                });

            modelBuilder.Entity("DatingApp.Database.Photo", b =>
                {
                    b.HasOne("DatingApp.Database.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });
#pragma warning restore 612, 618
        }
    }
}
