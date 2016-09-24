using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Server.Entities;

namespace Server.Migrations
{
    [DbContext(typeof(PhuDinhServerContext))]
    partial class PhuDinhServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Server.Entities.Group", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("NgayTao");

                    b.Property<string>("TenGroup")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Ma");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Server.Entities.KhoHang", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TenKho")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<bool>("TrangThai");

                    b.HasKey("Ma");

                    b.ToTable("KhoHang");
                });

            modelBuilder.Entity("Server.Entities.User", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<DateTime>("NgayTao");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.HasKey("Ma");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Server.Entities.UserGroup", b =>
                {
                    b.Property<int>("Ma")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("LaChuGroup");

                    b.Property<int>("MaGroup");

                    b.Property<int>("MaUser");

                    b.HasKey("Ma");

                    b.HasIndex("MaGroup");

                    b.HasIndex("MaUser");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("Server.Entities.UserGroup", b =>
                {
                    b.HasOne("Server.Entities.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("MaGroup")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Server.Entities.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("MaUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
