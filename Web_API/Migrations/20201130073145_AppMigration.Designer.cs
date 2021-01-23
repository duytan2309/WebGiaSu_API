using System;
using Lib.Domain.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Web_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201130073145_AppMigration")]
    partial class AppMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lib.Data.Entities.About", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<double?>("Lat")
                        .HasColumnType("double");

                    b.Property<double?>("Lng")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Other")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("About");
                });

            modelBuilder.Entity("Lib.Data.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<int>("StreetId")
                        .HasColumnType("int");

                    b.Property<int>("WardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Lib.Data.Entities.Advertistment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("PositionId")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Advertistments");
                });

            modelBuilder.Entity("Lib.Data.Entities.AdvertistmentPage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AdvertistmentPages");
                });

            modelBuilder.Entity("Lib.Data.Entities.AdvertistmentPosition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("PageId")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("AdvertistmentPositions");
                });

            modelBuilder.Entity("Lib.Data.Entities.Announcement", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Content")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<byte[]>("UserId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Lib.Data.Entities.AnnouncementUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AnnouncementId")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<bool?>("HasRead")
                        .HasColumnType("bit");

                    b.Property<byte[]>("UserId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.ToTable("AnnouncementUsers");
                });

            modelBuilder.Entity("Lib.Data.Entities.AppRole", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("Lib.Data.Entities.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<byte[]>("RoleId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUser", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserActions", b =>
                {
                    b.Property<long>("IdAction")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("IdUser")
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsAllowed")
                        .HasColumnType("bit");

                    b.HasKey("IdAction", "IdUser");

                    b.HasIndex("IdUser");

                    b.ToTable("AppUserActions");
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<byte[]>("UserId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserLogin", b =>
                {
                    b.Property<byte[]>("UserId")
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "ProviderKey");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserRole", b =>
                {
                    b.Property<byte[]>("UserId")
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("RoleId")
                        .HasColumnType("varbinary(16)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserToken", b =>
                {
                    b.Property<byte[]>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("Lib.Data.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("AdminId")
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("BillStatus")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<byte[]>("CustomerId")
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("CustomerMessage")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("CustomerMobile")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<long>("ShipCodeId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShipCodeId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Lib.Data.Entities.BillDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("PromotionPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusGuarantee")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("Lib.Data.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<bool?>("HotFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("text");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Lib.Data.Entities.BlogCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("text");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("text");

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("BlogCategory");
                });

            modelBuilder.Entity("Lib.Data.Entities.BlogImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Path")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogImages");
                });

            modelBuilder.Entity("Lib.Data.Entities.BlogTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("TagId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("TagId");

                    b.ToTable("BlogTags");
                });

            modelBuilder.Entity("Lib.Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Lib.Data.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Lib.Data.Entities.ContactDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<double?>("Lat")
                        .HasColumnType("double");

                    b.Property<double?>("Lng")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Other")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("Lib.Data.Entities.Courses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryId")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int?>("Courses_CategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("text");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("text");

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("VAT")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Courses_CategoriesId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Lib.Data.Entities.CoursesTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<string>("TagId")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CoursesId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("Lib.Data.Entities.Courses_Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("text");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("text");

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Course_Categories");
                });

            modelBuilder.Entity("Lib.Data.Entities.Diary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Diary");
                });

            modelBuilder.Entity("Lib.Data.Entities.DichVu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<bool?>("HotFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("text");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("DichVu");
                });

            modelBuilder.Entity("Lib.Data.Entities.DichVuCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("text");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("text");

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("DichVuCategory");
                });

            modelBuilder.Entity("Lib.Data.Entities.DichVuImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("DichVuId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("DichVuId");

                    b.ToTable("DichVuImages");
                });

            modelBuilder.Entity("Lib.Data.Entities.DichVuTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DichVuId")
                        .HasColumnType("int");

                    b.Property<string>("TagId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DichVuId");

                    b.HasIndex("TagId");

                    b.ToTable("DichVuTags");
                });

            modelBuilder.Entity("Lib.Data.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("District");
                });

            modelBuilder.Entity("Lib.Data.Entities.EmailRegistrations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EmailRegistrations");
                });

            modelBuilder.Entity("Lib.Data.Entities.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("DetailPage")
                        .HasColumnType("int");

                    b.Property<byte[]>("IdUser")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TypePage")
                        .HasColumnType("text");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FAQ");
                });

            modelBuilder.Entity("Lib.Data.Entities.Feedbacks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Message")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Lib.Data.Entities.Footer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("Lib.Data.Entities.Function", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("GroupAlias")
                        .HasColumnType("text");

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<string>("IconCss")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("Lib.Data.Entities.Language", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Resources")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Lib.Data.Entities.ListAction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ActionName")
                        .HasColumnType("text");

                    b.Property<string>("Discription")
                        .HasColumnType("text");

                    b.Property<long>("IdController")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdController");

                    b.ToTable("ListAction");
                });

            modelBuilder.Entity("Lib.Data.Entities.ListController", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ControllerName")
                        .HasColumnType("text");

                    b.Property<string>("Discription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ListController");
                });

            modelBuilder.Entity("Lib.Data.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("GroupAlias")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Target")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Lib.Data.Entities.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("GroupAlias")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdPages")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Lib.Data.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TypePay")
                        .HasColumnType("int");

                    b.Property<byte[]>("UserId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("VerificationNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Lib.Data.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("CanCreate")
                        .HasColumnType("bit");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("CanRead")
                        .HasColumnType("bit");

                    b.Property<bool>("CanUpdate")
                        .HasColumnType("bit");

                    b.Property<string>("FunctionId")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<byte[]>("RoleId")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Lib.Data.Entities.Policies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("Lib.Data.Entities.PolicyCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("text");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("text");

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PolicyCategories");
                });

            modelBuilder.Entity("Lib.Data.Entities.PolicyImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Path")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("PolicyImages");
                });

            modelBuilder.Entity("Lib.Data.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Rank")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("Lib.Data.Entities.QuestionCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<byte[]>("IdUser")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuestionCategories");
                });

            modelBuilder.Entity("Lib.Data.Entities.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<byte[]>("IdUser")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Lib.Data.Entities.Recruitment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recruitment");
                });

            modelBuilder.Entity("Lib.Data.Entities.RecruitmentCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("text");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("text");

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("RecruitmentCategories");
                });

            modelBuilder.Entity("Lib.Data.Entities.RecruitmentImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Path")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("RecruitmentId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecruitmentId");

                    b.ToTable("RecruitmentImages");
                });

            modelBuilder.Entity("Lib.Data.Entities.Routes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoIdPages")
                        .HasColumnType("text");

                    b.Property<string>("SeoNameAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoPages")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Lib.Data.Entities.ShipCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Carriers")
                        .HasColumnType("text");

                    b.Property<decimal>("CollectionFee")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("datetime");

                    b.Property<int>("IdAddress")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ShipCode");
                });

            modelBuilder.Entity("Lib.Data.Entities.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Lib.Data.Entities.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int>("GroupOrder")
                        .HasColumnType("int")
                        .HasMaxLength(25);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("Lib.Data.Entities.SlideImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Path")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("SlideId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SlideImages");
                });

            modelBuilder.Entity("Lib.Data.Entities.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Rank")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("WardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("WardId");

                    b.ToTable("Street");
                });

            modelBuilder.Entity("Lib.Data.Entities.Support", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Image")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoAlias")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoDescription")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Support");
                });

            modelBuilder.Entity("Lib.Data.Entities.SupportCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("HomeOrder")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SeoAlias")
                        .HasColumnType("text");

                    b.Property<string>("SeoDescription")
                        .HasColumnType("text");

                    b.Property<string>("SeoKeywords")
                        .HasColumnType("text");

                    b.Property<string>("SeoPageTitle")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SupportCategories");
                });

            modelBuilder.Entity("Lib.Data.Entities.SupportImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Path")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("SupportId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SupportId");

                    b.ToTable("SupportImages");
                });

            modelBuilder.Entity("Lib.Data.Entities.SystemConfig", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Value1")
                        .HasColumnType("text");

                    b.Property<int?>("Value2")
                        .HasColumnType("int");

                    b.Property<bool?>("Value3")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Value4")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Value5")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("Lib.Data.Entities.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Lib.Data.Entities.TrademarkImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Path")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("TrademarkId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TrademarkImages");
                });

            modelBuilder.Entity("Lib.Data.Entities.TrademarkLogos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Path")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("TrademarkId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TrademarkLogos");
                });

            modelBuilder.Entity("Lib.Data.Entities.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Ward");
                });

            modelBuilder.Entity("Lib.Data.Entities.WholePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("FromQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ToQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoursesId");

                    b.ToTable("WholePrices");
                });

            modelBuilder.Entity("Lib.Data.Entities.Advertistment", b =>
                {
                    b.HasOne("Lib.Data.Entities.AdvertistmentPosition", "AdvertistmentPosition")
                        .WithMany("Advertistments")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("Lib.Data.Entities.AdvertistmentPosition", b =>
                {
                    b.HasOne("Lib.Data.Entities.AdvertistmentPage", "AdvertistmentPage")
                        .WithMany("AdvertistmentPositions")
                        .HasForeignKey("PageId");
                });

            modelBuilder.Entity("Lib.Data.Entities.Announcement", b =>
                {
                    b.HasOne("Lib.Data.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.AnnouncementUser", b =>
                {
                    b.HasOne("Lib.Data.Entities.Announcement", "Announcement")
                        .WithMany("AnnouncementUsers")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserActions", b =>
                {
                    b.HasOne("Lib.Data.Entities.ListAction", "ListAction")
                        .WithMany("AspNetUserActions")
                        .HasForeignKey("IdAction")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.AppUser", "AppUser")
                        .WithMany("AppUserActions")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserClaim", b =>
                {
                    b.HasOne("Lib.Data.Entities.AppUser", "AppUser")
                        .WithMany("AppUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserLogin", b =>
                {
                    b.HasOne("Lib.Data.Entities.AppUser", "AppUser")
                        .WithMany("AppUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.AppUserRole", b =>
                {
                    b.HasOne("Lib.Data.Entities.AppRole", "AppRoles")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.AppUser", "AppUsers")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Bill", b =>
                {
                    b.HasOne("Lib.Data.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Lib.Data.Entities.ShipCode", "ShipCode")
                        .WithMany()
                        .HasForeignKey("ShipCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.BillDetail", b =>
                {
                    b.HasOne("Lib.Data.Entities.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Blog", b =>
                {
                    b.HasOne("Lib.Data.Entities.BlogCategory", "BlogCategory")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.BlogCategory", b =>
                {
                    b.HasOne("Lib.Data.Entities.Menu", "Menu")
                        .WithMany("BlogCategories")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("Lib.Data.Entities.BlogImages", b =>
                {
                    b.HasOne("Lib.Data.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.BlogTag", b =>
                {
                    b.HasOne("Lib.Data.Entities.Blog", "Blog")
                        .WithMany("BlogTags")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("Lib.Data.Entities.Courses", b =>
                {
                    b.HasOne("Lib.Data.Entities.Courses_Categories", null)
                        .WithMany("Courses")
                        .HasForeignKey("Courses_CategoriesId");
                });

            modelBuilder.Entity("Lib.Data.Entities.CoursesTag", b =>
                {
                    b.HasOne("Lib.Data.Entities.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("Lib.Data.Entities.DichVu", b =>
                {
                    b.HasOne("Lib.Data.Entities.DichVuCategory", "DichVuCategory")
                        .WithMany("DichVus")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.DichVuCategory", b =>
                {
                    b.HasOne("Lib.Data.Entities.Menu", "Menu")
                        .WithMany("DichVuCategories")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("Lib.Data.Entities.DichVuImages", b =>
                {
                    b.HasOne("Lib.Data.Entities.DichVu", "DichVu")
                        .WithMany()
                        .HasForeignKey("DichVuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.DichVuTag", b =>
                {
                    b.HasOne("Lib.Data.Entities.DichVu", "DichVu")
                        .WithMany("DichVuTags")
                        .HasForeignKey("DichVuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("Lib.Data.Entities.District", b =>
                {
                    b.HasOne("Lib.Data.Entities.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.ListAction", b =>
                {
                    b.HasOne("Lib.Data.Entities.ListController", "ListController")
                        .WithMany("ListActions")
                        .HasForeignKey("IdController")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Permission", b =>
                {
                    b.HasOne("Lib.Data.Entities.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.AppRole", "AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Policies", b =>
                {
                    b.HasOne("Lib.Data.Entities.PolicyCategories", "PolicyCategory")
                        .WithMany("Policies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.PolicyImages", b =>
                {
                    b.HasOne("Lib.Data.Entities.Policies", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Questions", b =>
                {
                    b.HasOne("Lib.Data.Entities.QuestionCategories", "QuestionCategories")
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Recruitment", b =>
                {
                    b.HasOne("Lib.Data.Entities.RecruitmentCategory", "TuyenDungCategory")
                        .WithMany("Recruitments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.RecruitmentCategory", b =>
                {
                    b.HasOne("Lib.Data.Entities.Menu", "Menu")
                        .WithMany("RecruitmenCategories")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("Lib.Data.Entities.RecruitmentImages", b =>
                {
                    b.HasOne("Lib.Data.Entities.Recruitment", "Recruitment")
                        .WithMany()
                        .HasForeignKey("RecruitmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Street", b =>
                {
                    b.HasOne("Lib.Data.Entities.District", "District")
                        .WithMany("Streets")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.Ward", "Ward")
                        .WithMany("Streets")
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Support", b =>
                {
                    b.HasOne("Lib.Data.Entities.SupportCategories", "SupportCategory")
                        .WithMany("Supports")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.SupportImages", b =>
                {
                    b.HasOne("Lib.Data.Entities.Support", "Support")
                        .WithMany()
                        .HasForeignKey("SupportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.Ward", b =>
                {
                    b.HasOne("Lib.Data.Entities.District", "District")
                        .WithMany("Wards")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lib.Data.Entities.Province", "Province")
                        .WithMany("Wards")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lib.Data.Entities.WholePrice", b =>
                {
                    b.HasOne("Lib.Data.Entities.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
