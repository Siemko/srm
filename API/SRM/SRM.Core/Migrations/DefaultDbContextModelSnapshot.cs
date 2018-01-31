﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SRM.Core;
using System;

namespace SRM.Core.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SRM.Core.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("SRM.Core.Entities.ChatUser", b =>
                {
                    b.Property<int>("ChatId");

                    b.Property<int>("UserId");

                    b.HasKey("ChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("SRM.Core.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Activated");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<int?>("MaxNumberOfPerson");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SRM.Core.Entities.EventCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("SRM.Core.Entities.EventUser", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<int>("UserId");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("SRM.Core.Entities.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SRM.Core.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<Guid?>("ResetPasswordGuid");

                    b.Property<int>("RoleId");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("StudentGroupId");

                    b.Property<string>("StudentNumber")
                        .HasMaxLength(10);

                    b.Property<string>("Surname")
                        .HasMaxLength(30);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("StudentGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SRM.Core.Entities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChatId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SRM.Core.Entities.StudentGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("StudentGroups");
                });

            modelBuilder.Entity("SRM.Core.Entities.ChatUser", b =>
                {
                    b.HasOne("SRM.Core.Entities.Chat", "Chat")
                        .WithMany("ChatUsers")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SRM.Core.Entities.Identity.User", "User")
                        .WithMany("ChatUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SRM.Core.Entities.Event", b =>
                {
                    b.HasOne("SRM.Core.Entities.EventCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SRM.Core.Entities.EventUser", b =>
                {
                    b.HasOne("SRM.Core.Entities.Event", "Event")
                        .WithMany("EventUsers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SRM.Core.Entities.Identity.User", "User")
                        .WithMany("EventUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SRM.Core.Entities.Identity.User", b =>
                {
                    b.HasOne("SRM.Core.Entities.Identity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SRM.Core.Entities.StudentGroup", "StudentGroup")
                        .WithMany()
                        .HasForeignKey("StudentGroupId");
                });

            modelBuilder.Entity("SRM.Core.Entities.Message", b =>
                {
                    b.HasOne("SRM.Core.Entities.Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SRM.Core.Entities.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
