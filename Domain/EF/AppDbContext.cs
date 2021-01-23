using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Lib.Data.Entities;

namespace Lib.Domain.EF
{
    //public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>

    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<About> About { set; get; }
        public DbSet<Address> Address { set; get; }
        public DbSet<ShipCode> ShipCodes { set; get; }
        public DbSet<Language> Languages { set; get; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUserActions> AppUserActions { set; get; }
        public DbSet<AppUserClaim> AppUserClaims { get; set; }
        public DbSet<AppUserLogin> AppUserLogins { get; set; }
        public DbSet<AppRoleClaim> AppRoleClaims { get; set; }
        public DbSet<AppUserToken> AppUserTokens { get; set; }
        public DbSet<ListAction> ListActions { set; get; }
        public DbSet<ListController> ListControllers { set; get; }
        public DbSet<Announcement> Announcements { set; get; }
        public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }
        public DbSet<Bill> Bills { set; get; }
        public DbSet<BillDetail> BillDetails { set; get; }
        public DbSet<Blog> Blogs { set; get; }
        public DbSet<BlogTag> BlogTags { set; get; }
        public DbSet<Color> Colors { set; get; }
        public DbSet<ContactDetails> Contacts { set; get; }
        public DbSet<Feedbacks> Feedbacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Courses_Categories> ProductCategories { set; get; }
        public DbSet<CoursesTag> ProductTags { set; get; }
        public DbSet<Size> Sizes { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<WholePrice> WholePrices { get; set; }
        public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
        public DbSet<Advertistment> Advertistments { get; set; }
        public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<DichVuCategory> DichVuCategories { get; set; }
        public DbSet<DichVuTag> DichVuTags { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Province> Provinces { set; get; }
        public DbSet<District> Districts { set; get; }
        public DbSet<Ward> Wards { set; get; }
        public DbSet<Street> Streets { set; get; }
        public DbSet<EmailRegistrations> EmailRegistrations { set; get; }
        public DbSet<Payment> Payment { set; get; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<RecruitmentCategory> RecruitmentCategory { set; get; }
        public DbSet<Policies> Policies { get; set; }
        public DbSet<PolicyCategories> PolicyCategories { set; get; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<SupportCategories> SupportCategories { set; get; }
        public DbSet<Questions> Questions { set; get; }
        public DbSet<QuestionCategories> QuestionCategories { set; get; }
        public DbSet<Routes> Routes { set; get; }
        public DbSet<BlogImages> BlogImages { set; get; }
        public DbSet<RecruitmentImages> RecruitmentImages { set; get; }
        public DbSet<DichVuImages> DichVuImages { set; get; }
        public DbSet<PolicyImages> PolicyImages { set; get; }
        public DbSet<SupportImages> SupportImages { set; get; }
        public DbSet<SlideImages> SlideImages { set; get; }
        public DbSet<TrademarkImages> TrademarkImages { set; get; }
        public DbSet<TrademarkLogos> TrademarkLogos { set; get; }
        public DbSet<Courses> Courses { set; get; }
        public DbSet<ApiUrl> ApiUrl { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder /*MySqlConnectionStringBuilder*/ optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;persistsecurityinfo=True;user id=root;password=Tan@23091995;database=giasu_db;", b => b.MigrationsAssembly("Web_API"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            #region Identity Config

            builder.Entity<AppUser>().ToTable("AppUsers").HasKey(x => x.Id);

            builder.Entity<AppRole>().ToTable("AppRoles").HasKey(x => x.Id);

            builder.Entity<AppUserClaim>().ToTable("AppUserClaims").HasKey(x => x.Id);

            builder.Entity<AppUserClaim>().ToTable("AppUserClaims")
               .HasOne<AppUser>(sc => sc.AppUser)
               .WithMany(s => s.AppUserClaims)
               .HasForeignKey(sc => sc.UserId);

            builder.Entity<AppUserLogin>().ToTable("AppUserLogins").HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey });

            builder.Entity<AppUserLogin>().ToTable("AppUserLogins")
               .HasOne<AppUser>(sc => sc.AppUser)
               .WithMany(s => s.AppUserLogins)
               .HasForeignKey(sc => sc.UserId);

            builder.Entity<AppUserToken>().ToTable("AppUserTokens")
               .HasKey(x => new { x.UserId });

            //AspNetUserRole

            builder.Entity<AppUserRole>().ToTable("AppUserRoles").HasKey(sc => new { sc.UserId, sc.RoleId });

            builder.Entity<AppUserRole>().ToTable("AppUserRoles")
               .HasOne<AppUser>(sc => sc.AppUsers)
               .WithMany(s => s.AppUserRoles)
               .HasForeignKey(sc => sc.UserId);

            builder.Entity<AppUserRole>().ToTable("AppUserRoles")
              .HasOne<AppRole>(sc => sc.AppRoles)
              .WithMany(s => s.AppUserRoles)
              .HasForeignKey(sc => sc.RoleId);

            #endregion Identity Config

            builder.Entity<AppUserActions>().ToTable("AppUserActions").HasKey(sc => new { sc.IdAction, sc.IdUser });

            builder.Entity<AppUserActions>().ToTable("AppUserActions")
                .HasOne<ListAction>(sc => sc.ListAction)
                .WithMany(s => s.AspNetUserActions)
                .HasForeignKey(sc => sc.IdAction);

            builder.Entity<AppUserActions>().ToTable("AppUserActions")
                .HasOne<AppUser>(sc => sc.AppUser)
                .WithMany(s => s.AppUserActions)
                .HasForeignKey(sc => sc.IdUser);

            //builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
            //builder.Entity<IdentityUserClaim<Guid>>().HasKey(p => p.Id);

            //builder.AddConfiguration(new TagConfiguration());
            //builder.AddConfiguration(new BlogTagConfiguration());
            //builder.AddConfiguration(new ContactDetailConfiguration());
            //builder.AddConfiguration(new FooterConfiguration());
            //builder.AddConfiguration(new PageConfiguration());
            //builder.AddConfiguration(new FooterConfiguration());
            //builder.AddConfiguration(new ProductTagConfiguration());
            //builder.AddConfiguration(new SystemConfigConfiguration());
            //builder.AddConfiguration(new AdvertistmentPositionConfiguration());
            //builder.AddConfiguration(new DichVuTagConfiguration());
        }

        //public override int SaveChanges()
        //{
        //    var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

        //    //foreach (EntityEntry item in modified)
        //    //{
        //    //    var changedOrAddedItem = item.Entity as IDateTracking;
        //    //    if (changedOrAddedItem != null)
        //    //    {
        //    //        if (item.State == EntityState.Added)
        //    //        {
        //    //            changedOrAddedItem.DateCreated = DateTime.Now;
        //    //        }
        //    //        changedOrAddedItem.DateModified = DateTime.Now;
        //    //    }
        //    //}
        //    return base.SaveChanges();
        //}
    }

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    //{
    //    public AppDbContext CreateDbContext(string[] args)
    //    {
    //        Microsoft.Extensions.Configuration.IConfiguration configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
    //        .SetBasePath(Directory.GetCurrentDirectory())
    //        .AddJsonFile("appsettings.json").Build();

    //        var builder = new DbContextOptionsBuilder<AppDbContext>();
    //        var connectionString = configuration.GetConnectionString("DefaultConnection");
    //        builder.UseMySQL(connectionString);
    //        return new AppDbContext(builder.Options);
    //    }
    //}
}