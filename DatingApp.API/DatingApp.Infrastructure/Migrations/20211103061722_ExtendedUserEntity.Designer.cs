// <auto-generated />
using System;
using DatingApp.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatingApp.Infrastructure.Migrations
{
    [DbContext(typeof(DatingAppDbContext))]
    [Migration("20211103061722_ExtendedUserEntity")]
    partial class ExtendedUserEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = 1,
                            Created = new DateTime(2021, 11, 3, 7, 17, 21, 441, DateTimeKind.Local).AddTicks(4536),
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastActive = new DateTime(2021, 11, 3, 7, 17, 21, 448, DateTimeKind.Local).AddTicks(1134),
                            PasswordHash = "cGFzc3dvcmQ=ZGF0aW5nYXBw",
                            PasswordSalt = "ZGF0aW5nYXBw",
                            UserName = "Dave"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2021, 11, 3, 7, 17, 21, 448, DateTimeKind.Local).AddTicks(7019),
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastActive = new DateTime(2021, 11, 3, 7, 17, 21, 448, DateTimeKind.Local).AddTicks(7089),
                            PasswordHash = "cGFzc3dvcmQ=ZGF0aW5nYXBw",
                            PasswordSalt = "ZGF0aW5nYXBw",
                            UserName = "Bob"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2021, 11, 3, 7, 17, 21, 448, DateTimeKind.Local).AddTicks(7113),
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastActive = new DateTime(2021, 11, 3, 7, 17, 21, 448, DateTimeKind.Local).AddTicks(7124),
                            PasswordHash = "cGFzc3dvcmQ=ZGF0aW5nYXBw",
                            PasswordSalt = "ZGF0aW5nYXBw",
                            UserName = "Tom"
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
                });

            modelBuilder.Entity("DatingApp.Database.Photo", b =>
                {
                    b.HasOne("DatingApp.Database.AppUser", "AppUser")
                        .WithMany("Photos")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("DatingApp.Database.AppUser", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
