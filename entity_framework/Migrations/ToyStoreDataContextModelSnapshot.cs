﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using entity_framework;

namespace entity_framework.Migrations
{
    [DbContext(typeof(ToyStoreDataContext))]
    partial class ToyStoreDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImageToy", b =>
                {
                    b.Property<int>("ImagesId")
                        .HasColumnType("int");

                    b.Property<int>("ToysId")
                        .HasColumnType("int");

                    b.HasKey("ImagesId", "ToysId");

                    b.HasIndex("ToysId");

                    b.ToTable("ImageToy");
                });

            modelBuilder.Entity("ProfileToy", b =>
                {
                    b.Property<int>("ProfilesId")
                        .HasColumnType("int");

                    b.Property<int>("ToysId")
                        .HasColumnType("int");

                    b.HasKey("ProfilesId", "ToysId");

                    b.HasIndex("ToysId");

                    b.ToTable("ProfileToy");
                });

            modelBuilder.Entity("entities.DTO.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("images");
                });

            modelBuilder.Entity("entities.DTO.ProductComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentRate")
                        .HasColumnType("int");

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ToyId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToyId");

                    b.HasIndex("UserId");

                    b.ToTable("product_comments");
                });

            modelBuilder.Entity("entities.DTO.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("profiles");
                });

            modelBuilder.Entity("entities.DTO.Toy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Subject")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("toys");
                });

            modelBuilder.Entity("entities.DTO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ImageToy", b =>
                {
                    b.HasOne("entities.DTO.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("entities.DTO.Toy", null)
                        .WithMany()
                        .HasForeignKey("ToysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfileToy", b =>
                {
                    b.HasOne("entities.DTO.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("entities.DTO.Toy", null)
                        .WithMany()
                        .HasForeignKey("ToysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("entities.DTO.ProductComment", b =>
                {
                    b.HasOne("entities.DTO.Toy", "Toy")
                        .WithMany("ProductComment")
                        .HasForeignKey("ToyId");

                    b.HasOne("entities.DTO.User", "User")
                        .WithMany("ProductsComments")
                        .HasForeignKey("UserId");

                    b.Navigation("Toy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("entities.DTO.Profile", b =>
                {
                    b.HasOne("entities.DTO.Image", "Image")
                        .WithOne("Profile")
                        .HasForeignKey("entities.DTO.Profile", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("entities.DTO.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("entities.DTO.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("entities.DTO.Image", b =>
                {
                    b.Navigation("Profile");
                });

            modelBuilder.Entity("entities.DTO.Toy", b =>
                {
                    b.Navigation("ProductComment");
                });

            modelBuilder.Entity("entities.DTO.User", b =>
                {
                    b.Navigation("ProductsComments");

                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
