using Microsoft.EntityFrameworkCore;
using Data;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using Data.Privileges;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Repository
{

    //public class ApplicationRole : IdentityRole<string>, Data.Privileges.IAuditTrail<string>
    //{
    //    public ApplicationRole()
    //    {
    //        Id = Guid.NewGuid().ToString();
    //    }
    //}

    public class ApplicationContext : IdentityDbContext<IdentityUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string AnonymousUser = null;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public DbSet<Language> Languages { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Data.Document> Documents { get; set; }
        public DbSet<DocumentTranslation> DocumentTranslations { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<UserChangeHistory> UserChangeHistories { get; set; }
        public DbSet<ActionRoot> ActionRoots { get; set; }
        public DbSet<UserActionRootRestRight> UserActionRootRestRights { get; set; }
        //produktet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ErpTemp> ErpTemps { get; set; }
        //prod

        public DbSet<SendEmail> SendEmails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyGlobalFilters<bool>("IsDeleted", false);


            modelBuilder.Entity<UserLanguage>().HasKey(x => new { x.UserId, x.LanguageId });

            modelBuilder.Entity<UserLanguage>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserLanguages)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<AppUser>()
                .HasOne(bc => bc.DefaultLanguage)
                .WithMany(b => b.AppUsers)
                .HasForeignKey(bc => bc.DefaultLanguageId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserLanguage>()
                .HasOne(bc => bc.Language)
                .WithMany(c => c.UserLanguages)
                .HasForeignKey(bc => bc.LanguageId);

            modelBuilder.Entity<AppUser>();

            // Product - Category (Many-to-Many)
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            // Product - Color (Many-to-Many)
            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Colors)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Color)
                .WithMany(c => c.ProductColors)
                .HasForeignKey(pc => pc.ColorId);

            // Product - Size (Many-to-Many)
            modelBuilder.Entity<ProductSize>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.Sizes)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductSize>()
                .HasOne(ps => ps.Size)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(ps => ps.SizeId);

            // Product - Image (One-to-Many)
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId);
            modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderItems)
        .WithOne(oi => oi.Order)
        .HasForeignKey(oi => oi.OrderId);
            // Decimal property configurations
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>().Property(p => p.OldPrice).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Order>().Property(o => o.TotalPrice).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<OrderItem>().Property(oi => oi.Price).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<ErpTemp>().Property(e => e.Cmimi_me_TVSH).HasColumnType("decimal(18, 2)");

        }

        #region Seeds
        private static readonly string
            userAdminId = "9e0568ef-f131-4044-9bd9-8d49d186d278",
            administratorRoleId = "55660013-d101-427f-a62a-f6568b936af1";
        private static void seedData4UserAndRoles(ModelBuilder modelBuilder)
        {
            string Roleadminid, adminid;
            Roleadminid = administratorRoleId;


            modelBuilder.Entity<ApplicationRole>().HasData(
                  new ApplicationRole { Name = "Administrator", NormalizedName = "Administrator", Id = Roleadminid }
                );

            adminid = userAdminId;
            var user = new AppUser { Id = adminid, FirstName = "Admin", LastName = "ADMIN", Email = "admin@admin.com", NormalizedEmail = "admin@admin.COM", UserName = "admin@admin.COM", NormalizedUserName = "admin@admin.com", PhoneNumber = "+111111111111", EmailConfirmed = true, PhoneNumberConfirmed = true, SecurityStamp = Guid.NewGuid().ToString("D"), active = true };
            user.PasswordHash = (new PasswordHasher<AppUser>()).HashPassword(user, "123456");
            modelBuilder.Entity<AppUser>().HasData(user);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { UserId = adminid, RoleId = Roleadminid });
        }

        private static void Seed4Language(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "Albania", Code = "sq" },
                new Language { Id = 2, Name = "English", Code = "en" },
                new Language { Id = 3, Name = "Serbian", Code = "sr" },
                new Language { Id = 4, Name = "Turkish", Code = "tr" },
                new Language { Id = 5, Name = "Bosnian", Code = "bs" }
                );
        }


    }


    #endregion


}
public static class ExtendionMethods
{
    public static void ApplyGlobalFilters<T>(this ModelBuilder modelBilder, string propertyName, T value)
    {
        foreach (var entityType in modelBilder.Model.GetEntityTypes())
        {
            var foundProperty = entityType.FindProperty(propertyName);

            if (foundProperty != null && foundProperty.ClrType == typeof(T))
            {
                var newParam = Expression.Parameter(entityType.ClrType);

                var filter = Expression.
                    Lambda(Expression.Equal(Expression.Property(newParam, propertyName),
                    Expression.Constant(value)), newParam);

                modelBilder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }

        }
    }
}
