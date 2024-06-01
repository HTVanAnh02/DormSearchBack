﻿// <auto-generated />
using System;
using DormSearchBe.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DormSearchBe.Infrastructure.Migrations
{
    [DbContext(typeof(DormSearch_DbContext))]
    partial class DormSearch_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Areas", b =>
                {
                    b.Property<Guid>("AreasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AreasName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AreasId");

                    b.ToTable("Areass", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Chat_Group", b =>
                {
                    b.Property<Guid>("Chat_Group_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserSend_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Chat_Group_Id");

                    b.HasIndex("UserId");

                    b.ToTable("Chat_Groups", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.City", b =>
                {
                    b.Property<Guid>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CityId");

                    b.ToTable("Citys", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Favorites", b =>
                {
                    b.Property<Guid>("FavoritesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HousesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFavorites")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavoritesId");

                    b.ToTable("Favorites", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Houses", b =>
                {
                    b.Property<Guid>("HousesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acreage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressHouses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AreasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateSubmitted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FavoritesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HousesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RatingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomstyleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HousesId");

                    b.HasIndex("AreasId");

                    b.HasIndex("CityId");

                    b.HasIndex("FavoritesId");

                    b.HasIndex("RatingsId");

                    b.HasIndex("RoomstyleId");

                    b.ToTable("Houses", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Message", b =>
                {
                    b.Property<Guid?>("MessagesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Messages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserSend")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessagesId");

                    b.ToTable("Messages", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Notification", b =>
<<<<<<< HEAD
=======

                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Notification_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotificationId");

                    b.HasIndex("HouseId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Permission", b =>
>>>>>>> cd0e9262c216de8458ac450333745c976b95506c
                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Notification_CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotificationId");

                    b.HasIndex("HouseId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Ratings", b =>
                {
                    b.Property<Guid>("RatingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HousesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsFeedback")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("RatingsDateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RatingsId");

                    b.ToTable("Ratings", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Refresh_Token", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RefreshTokenExpiration")
                        .HasColumnType("int");

                    b.Property<DateTime>("Refresh_TokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Roomstyle", b =>
                {
                    b.Property<Guid>("RoomstyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomstyleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoomstyleId");

                    b.ToTable("Roomstyles", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FavoritesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HousesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Is_Active")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RatingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("createdBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("deletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("deletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("updatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("FavoritesId");

                    b.HasIndex("HousesId");

                    b.HasIndex("MessageId");

                    b.HasIndex("RatingsId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Chat_Group", b =>
                {
                    b.HasOne("DormSearchBe.Domain.Entity.User", "User")
                        .WithMany("Chat_Groups")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Houses", b =>
                {
                    b.HasOne("DormSearchBe.Domain.Entity.Areas", "Areas")
                        .WithMany("Houses")
                        .HasForeignKey("AreasId");

                    b.HasOne("DormSearchBe.Domain.Entity.City", "City")
                        .WithMany("Houses")
                        .HasForeignKey("CityId");

                    b.HasOne("DormSearchBe.Domain.Entity.Favorites", null)
                        .WithMany("Houses")
                        .HasForeignKey("FavoritesId");

                    b.HasOne("DormSearchBe.Domain.Entity.Ratings", null)
                        .WithMany("Houses")
                        .HasForeignKey("RatingsId");

                    b.HasOne("DormSearchBe.Domain.Entity.Roomstyle", "Roomstyles")
                        .WithMany("Houses")
                        .HasForeignKey("RoomstyleId");

                    b.Navigation("Areas");

                    b.Navigation("City");

                    b.Navigation("Roomstyles");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Notification", b =>
                {
                    b.HasOne("DormSearchBe.Domain.Entity.Houses", "Houses")
                        .WithMany("Notifications")
                        .HasForeignKey("HouseId");

                    b.HasOne("DormSearchBe.Domain.Entity.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("Houses");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Refresh_Token", b =>
                {
                    b.HasOne("DormSearchBe.Domain.Entity.User", "User")
                        .WithMany("Refresh_Tokens")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.User", b =>
                {
                    b.HasOne("DormSearchBe.Domain.Entity.Favorites", "Favorites")
                        .WithMany("Users")
                        .HasForeignKey("FavoritesId");

                    b.HasOne("DormSearchBe.Domain.Entity.Houses", "Houses")
                        .WithMany("Users")
                        .HasForeignKey("HousesId");

                    b.HasOne("DormSearchBe.Domain.Entity.Message", "Messages")
                        .WithMany("Users")
                        .HasForeignKey("MessageId");

                    b.HasOne("DormSearchBe.Domain.Entity.Ratings", "Ratings")
                        .WithMany("Users")
                        .HasForeignKey("RatingsId");

                    b.HasOne("DormSearchBe.Domain.Entity.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Favorites");

                    b.Navigation("Houses");

                    b.Navigation("Messages");

                    b.Navigation("Ratings");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Areas", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.City", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Favorites", b =>
                {
                    b.Navigation("Houses");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Houses", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Message", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Ratings", b =>
                {
                    b.Navigation("Houses");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.Roomstyle", b =>
                {
                    b.Navigation("Houses");
                });

            modelBuilder.Entity("DormSearchBe.Domain.Entity.User", b =>
                {
                    b.Navigation("Chat_Groups");

                    b.Navigation("Notifications");

                    b.Navigation("Refresh_Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
