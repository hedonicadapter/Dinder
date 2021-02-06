﻿// <auto-generated />
using DinderDL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DinderDL.Migrations
{
    [DbContext(typeof(UserEntityContext))]
    partial class UserEntityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DinderDL.Models.FilesEntity", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte>("Filedata")
                        .HasColumnType("tinyint");

                    b.Property<string>("Filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("FileID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("FilesEntity");
                });

            modelBuilder.Entity("DinderDL.Models.Friendship", b =>
                {
                    b.Property<int>("FriendshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Friend1ID")
                        .HasColumnType("int");

                    b.Property<int>("Friend2ID")
                        .HasColumnType("int");

                    b.Property<bool>("FriendStatus")
                        .HasColumnType("bit");

                    b.HasKey("FriendshipID");

                    b.HasIndex("Friend1ID");

                    b.HasIndex("Friend2ID");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("DinderDL.Models.PostsEntity", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("DinderDL.Models.UserEntity", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DinderDL.Models.UserPosts", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "PostID");

                    b.HasIndex("PostID");

                    b.ToTable("UserPosts");
                });

            modelBuilder.Entity("DinderDL.Models.FilesEntity", b =>
                {
                    b.HasOne("DinderDL.Models.UserEntity", "User")
                        .WithOne("File")
                        .HasForeignKey("DinderDL.Models.FilesEntity", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DinderDL.Models.Friendship", b =>
                {
                    b.HasOne("DinderDL.Models.UserEntity", "Friend1")
                        .WithMany("Friendship1")
                        .HasForeignKey("Friend1ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DinderDL.Models.UserEntity", "Friend2")
                        .WithMany("Friendship2")
                        .HasForeignKey("Friend2ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Friend1");

                    b.Navigation("Friend2");
                });

            modelBuilder.Entity("DinderDL.Models.UserPosts", b =>
                {
                    b.HasOne("DinderDL.Models.PostsEntity", "Post")
                        .WithMany("UserPosts")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DinderDL.Models.UserEntity", "User")
                        .WithMany("UserPosts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DinderDL.Models.PostsEntity", b =>
                {
                    b.Navigation("UserPosts");
                });

            modelBuilder.Entity("DinderDL.Models.UserEntity", b =>
                {
                    b.Navigation("File");

                    b.Navigation("Friendship1");

                    b.Navigation("Friendship2");

                    b.Navigation("UserPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
