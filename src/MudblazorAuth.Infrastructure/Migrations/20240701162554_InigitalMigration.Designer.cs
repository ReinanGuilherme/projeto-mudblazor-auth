﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MudblazorAuth.Infrastructure.Database;

#nullable disable

namespace MudblazorAuth.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240701162554_InigitalMigration")]
    partial class InigitalMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MudblazorAuth.Domain.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("IdProfile")
                        .HasColumnType("bigint")
                        .HasColumnName("idprofile");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.HasIndex("IdProfile")
                        .HasDatabaseName("ix_accounts_idprofile");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("MudblazorAuth.Domain.Entities.Page", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit")
                        .HasColumnName("isprivate");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_pages");

                    b.ToTable("pages");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IsPrivate = false,
                            Url = "/SignIn"
                        },
                        new
                        {
                            Id = 2L,
                            IsPrivate = false,
                            Url = "/Register"
                        },
                        new
                        {
                            Id = 3L,
                            IsPrivate = true,
                            Url = "/Home"
                        },
                        new
                        {
                            Id = 4L,
                            IsPrivate = true,
                            Url = "/Counter"
                        },
                        new
                        {
                            Id = 5L,
                            IsPrivate = true,
                            Url = "/Weather"
                        },
                        new
                        {
                            Id = 6L,
                            IsPrivate = true,
                            Url = "/ProfilePermissionsPage"
                        },
                        new
                        {
                            Id = 7L,
                            IsPrivate = true,
                            Url = "/Users"
                        },
                        new
                        {
                            Id = 8L,
                            IsPrivate = true,
                            Url = "/AccessDenied"
                        });
                });

            modelBuilder.Entity("MudblazorAuth.Domain.Entities.Profile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_profiles");

                    b.ToTable("profiles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Admin"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "User"
                        });
                });

            modelBuilder.Entity("MudblazorAuth.Domain.Entities.ProfilePage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("IdPage")
                        .HasColumnType("bigint")
                        .HasColumnName("idpage");

                    b.Property<long>("IdProfile")
                        .HasColumnType("bigint")
                        .HasColumnName("idprofile");

                    b.HasKey("Id")
                        .HasName("pk_profilepages");

                    b.HasIndex("IdPage")
                        .HasDatabaseName("ix_profilepages_idpage");

                    b.HasIndex("IdProfile")
                        .HasDatabaseName("ix_profilepages_idprofile");

                    b.ToTable("profilepages");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IdPage = 3L,
                            IdProfile = 1L
                        },
                        new
                        {
                            Id = 2L,
                            IdPage = 4L,
                            IdProfile = 1L
                        },
                        new
                        {
                            Id = 3L,
                            IdPage = 5L,
                            IdProfile = 1L
                        },
                        new
                        {
                            Id = 4L,
                            IdPage = 6L,
                            IdProfile = 1L
                        },
                        new
                        {
                            Id = 5L,
                            IdPage = 7L,
                            IdProfile = 1L
                        },
                        new
                        {
                            Id = 6L,
                            IdPage = 8L,
                            IdProfile = 1L
                        },
                        new
                        {
                            Id = 7L,
                            IdPage = 3L,
                            IdProfile = 2L
                        },
                        new
                        {
                            Id = 8L,
                            IdPage = 4L,
                            IdProfile = 2L
                        },
                        new
                        {
                            Id = 9L,
                            IdPage = 5L,
                            IdProfile = 2L
                        });
                });

            modelBuilder.Entity("MudblazorAuth.Domain.Entities.Account", b =>
                {
                    b.HasOne("MudblazorAuth.Domain.Entities.Profile", "Profile")
                        .WithMany("Accounts")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_accounts_profiles_idprofile");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MudblazorAuth.Domain.Entities.ProfilePage", b =>
                {
                    b.HasOne("MudblazorAuth.Domain.Entities.Page", "Page")
                        .WithMany("ProfilePages")
                        .HasForeignKey("IdPage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_profilepages_pages_idpage");

                    b.HasOne("MudblazorAuth.Domain.Entities.Profile", "Profile")
                        .WithMany("ProfilePages")
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_profilepages_profiles_idprofile");

                    b.Navigation("Page");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("MudblazorAuth.Domain.Entities.Page", b =>
                {
                    b.Navigation("ProfilePages");
                });

            modelBuilder.Entity("MudblazorAuth.Domain.Entities.Profile", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("ProfilePages");
                });
#pragma warning restore 612, 618
        }
    }
}