using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TrophyFish.Model;

namespace TrophyFish.Model.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170521194841_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TrophyFish.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar")
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<byte>("StatusID");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("StatusID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrophyFish.Model.CloudDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("CloudDict");
                });

            modelBuilder.Entity("TrophyFish.Model.CountryDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("CountryDict");
                });

            modelBuilder.Entity("TrophyFish.Model.Fish", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<short?>("AirTemp");

                    b.Property<DateTime>("CatchDate");

                    b.Property<byte?>("CloudID");

                    b.Property<byte>("CountryID");

                    b.Property<byte>("FisheryTypeID");

                    b.Property<short?>("Length");

                    b.Property<string>("LureBaitDesc")
                        .HasMaxLength(50);

                    b.Property<byte?>("LureBaitID");

                    b.Property<byte?>("MethodID");

                    b.Property<byte?>("MoonPhase");

                    b.Property<byte?>("PrecipitationID");

                    b.Property<short?>("Pressure");

                    b.Property<byte?>("PressureChangeID");

                    b.Property<byte>("SpecieID");

                    b.Property<byte>("StatusID");

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.Property<byte?>("WaterLevelID");

                    b.Property<short?>("WaterTemp");

                    b.Property<short?>("Weight");

                    b.Property<byte?>("WindDirID");

                    b.Property<byte?>("WindSpeed");

                    b.HasKey("ID");

                    b.HasIndex("CloudID");

                    b.HasIndex("CountryID");

                    b.HasIndex("FisheryTypeID");

                    b.HasIndex("LureBaitID");

                    b.HasIndex("MethodID");

                    b.HasIndex("PrecipitationID");

                    b.HasIndex("PressureChangeID");

                    b.HasIndex("SpecieID");

                    b.HasIndex("StatusID");

                    b.HasIndex("UserID");

                    b.HasIndex("WaterLevelID");

                    b.HasIndex("WindDirID");

                    b.ToTable("Fish");
                });

            modelBuilder.Entity("TrophyFish.Model.FisheryTypeDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("FisheryTypeDict");
                });

            modelBuilder.Entity("TrophyFish.Model.FishStatusDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("FishStatusDict");
                });

            modelBuilder.Entity("TrophyFish.Model.LureBaitDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("LureBaitDict");
                });

            modelBuilder.Entity("TrophyFish.Model.MethodDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("MethodDict");
                });

            modelBuilder.Entity("TrophyFish.Model.PrecipitationDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("PrecipitationDict");
                });

            modelBuilder.Entity("TrophyFish.Model.PressureChangeDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("PressureChangeDict");
                });

            modelBuilder.Entity("TrophyFish.Model.SpecieDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("SpecieDict");
                });

            modelBuilder.Entity("TrophyFish.Model.UserStatusDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("UserStatusDict");
                });

            modelBuilder.Entity("TrophyFish.Model.WaterLevelDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("WaterLevelDict");
                });

            modelBuilder.Entity("TrophyFish.Model.WindDirectionDict", b =>
                {
                    b.Property<byte>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("ID");

                    b.ToTable("WindDirectionDict");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TrophyFish.Model.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TrophyFish.Model.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrophyFish.Model.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrophyFish.Model.ApplicationUser", b =>
                {
                    b.HasOne("TrophyFish.Model.UserStatusDict", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrophyFish.Model.Fish", b =>
                {
                    b.HasOne("TrophyFish.Model.CloudDict", "Cloud")
                        .WithMany()
                        .HasForeignKey("CloudID");

                    b.HasOne("TrophyFish.Model.CountryDict", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrophyFish.Model.FisheryTypeDict", "FisheryType")
                        .WithMany()
                        .HasForeignKey("FisheryTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrophyFish.Model.LureBaitDict", "LureBait")
                        .WithMany()
                        .HasForeignKey("LureBaitID");

                    b.HasOne("TrophyFish.Model.MethodDict", "Method")
                        .WithMany()
                        .HasForeignKey("MethodID");

                    b.HasOne("TrophyFish.Model.PrecipitationDict", "Precipitation")
                        .WithMany()
                        .HasForeignKey("PrecipitationID");

                    b.HasOne("TrophyFish.Model.PressureChangeDict", "PressureChange")
                        .WithMany()
                        .HasForeignKey("PressureChangeID");

                    b.HasOne("TrophyFish.Model.SpecieDict", "Specie")
                        .WithMany()
                        .HasForeignKey("SpecieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrophyFish.Model.FishStatusDict", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrophyFish.Model.ApplicationUser", "User")
                        .WithMany("Fishes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrophyFish.Model.WaterLevelDict", "WaterLevel")
                        .WithMany()
                        .HasForeignKey("WaterLevelID");

                    b.HasOne("TrophyFish.Model.WindDirectionDict", "WindDirection")
                        .WithMany()
                        .HasForeignKey("WindDirID");
                });
        }
    }
}
