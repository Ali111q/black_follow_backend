using System.Reflection;
using System.Reflection.Emit;
using BackEndStructuer.Entities;
using GaragesStructure.DATA.DTOs;
using GaragesStructure.Entities;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore;

namespace GaragesStructure.DATA
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<AppUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }


        // here to add
public DbSet<FinancialMovement> FinancialMovements { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }
        public DbSet<Categories> Categoriess { get; set; }
        public DbSet<LoginLogger> LoginLoggers { get; set; }

        public DbSet<Country> Countries { get; set; }


        public DbSet<Notifications> Notifications { get; set; }

        // public DbSet<DriverVehicle> DriverVehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<AppUser>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<SubCategory>().HasOne<Categories>(S => S.Categories).WithMany(C => C.SubCategories)
                .HasForeignKey(S => S.CategoriesId);
            modelBuilder.Entity<Service>().HasOne<SubCategory>(S => S.SubCategory).WithMany(C => C.Services)
                .HasForeignKey(S => S.SubCategoryId);
            modelBuilder.Entity<Order>().HasOne<Service>(S => S.Service).WithMany(C => C.Orders)
                .HasForeignKey(S => S.ServiceId);

            modelBuilder.Entity<FinancialMovement>().HasOne<AppUser>(S => S.User).WithMany(C => C.FinancialMovements)
                .HasForeignKey(S => S.UserId);

            modelBuilder.Entity<Role>().HasData(
                new List<Role>()
                {
                    new Role()
                    {
                        Id = Guid.Parse("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                        Name = "User",
                    },
                    new Role()
                    {
                        Id = Guid.Parse("395849e7-033a-4ca0-8f7c-fc03d0943dab"),
                        Name = "Admin",
                    }
                }
            );

            modelBuilder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = Guid.Parse("395849e7-033a-4ca0-8f7c-fc03d0eeedaa"),
                Email = "bbbeat114@gmail.com",
                FullName = "ali",
                Username = "ali",
                Password = BCrypt.Net.BCrypt.HashPassword("10109989"),
                RoleId = Guid.Parse("395849e7-033a-4ca0-8f7c-fc03d0943daa"),
                
            });
            var categoryId = Guid.Parse("395849e7-033a-4ca0-8f7c-fc03d0eecdaa");
            modelBuilder.Entity<Categories>().HasData(new Categories()
            {
                Id =categoryId ,
                Name = "Facebook",
                Icon = "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png"
            });
            var subCategoryId = Guid.Parse("395849e7-033a-4ca0-8f7c-fc03d0eeadaa");
            modelBuilder.Entity<SubCategory>().HasData(new SubCategory()
            {
                Id = subCategoryId ,
                Name = "Facebook",
                CategoriesId = categoryId,
                Icon = "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png"

            });

            var serviceId = Guid.Parse("395849e7-033a-4ca0-8f7c-fc03d0eefdaa");

            modelBuilder.Entity<Service>().HasData(new Service()
            {
             Id   = Guid.NewGuid(),
             SubCategoryId = subCategoryId,
             Icon = "Attachments/364800c2-c094-46cb-add5-7dc3f416403d.png",
             ServiceId = "982",
             Minimum = "50",
             Maximum = "100000",
             Name = "add  followers",
             Description = "add followers",
            });
            // new DbInitializer(modelBuilder).Seed();

        }
        

        public virtual async Task<int> SaveChangesAsync(Guid? userId = null)
        {
            // await OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync();
            return result;
        }

        // private async Task OnBeforeSaveChanges(Guid? userId)
        // {
        //     try
        //     {
        //         ChangeTracker.DetectChanges();
        //
        //         var auditEntries = new List<AuditEntry>();
        //
        //         foreach (var entry in ChangeTracker.Entries()
        //                      .Where(e => e.Entity is not Audit &&
        //                                  (e.State is
        //                                      EntityState.Added or
        //                                      EntityState.Modified or
        //                                      EntityState.Deleted) &&
        //                                  e.Entity.GetType().GetCustomAttribute<AuditTrailAttribute>() != null))
        //         {
        //             var auditEntry = new AuditEntry(entry)
        //             {
        //                 TableName = entry.Metadata.GetTableName(),
        //                 UserId = userId
        //             };
        //
        //             foreach (var property in entry.Properties)
        //             {
        //                 if (property.Metadata.IsPrimaryKey())
        //                 {
        //                     auditEntry.KeyValues[property.Metadata.Name] = property.CurrentValue;
        //                     continue;
        //                 }
        //
        //                 if (entry.State == EntityState.Added)
        //                 {
        //                     auditEntry.AuditType = AuditType.Create;
        //                     auditEntry.NewValues[property.Metadata.Name] = property.CurrentValue;
        //                 }
        //                 else if (entry.State == EntityState.Deleted)
        //                 {
        //                     auditEntry.AuditType = AuditType.Delete;
        //                     auditEntry.OldValues[property.Metadata.Name] =
        //                         entry.GetDatabaseValues()[property.Metadata] ?? DBNull.Value;
        //                 }
        //
        //                 else if (entry.State == EntityState.Modified && property.IsModified)
        //                 {
        //                     auditEntry.AuditType = AuditType.Update;
        //                     auditEntry.OldValues[property.Metadata.Name] =
        //                         entry.GetDatabaseValues()[property.Metadata] ?? DBNull.Value;
        //                     auditEntry.NewValues[property.Metadata.Name] = property.CurrentValue;
        //                 }
        //             }
        //
        //             auditEntries.Add(auditEntry);
        //         }
        //
        //         var databaseValues = await Task.WhenAll(auditEntries
        //             .Where(e => e.AuditType != AuditType.Create)
        //             .Select(async entry => new
        //             {
        //                 Entry = entry,
        //                 DatabaseValues = await entry.Entry.GetDatabaseValuesAsync()
        //             }));
        //
        //         foreach (var item in databaseValues)
        //         {
        //             var auditEntry = item.Entry;
        //             foreach (var property in auditEntry.Entry.Properties)
        //             {
        //                 var propertyName = property.Metadata.Name;
        //                 if (!auditEntry.ChangedColumns.Contains(propertyName))
        //                     auditEntry.ChangedColumns.Add(propertyName);
        //
        //                 if (auditEntry.AuditType == AuditType.Delete)
        //                 {
        //                     auditEntry.OldValues[propertyName] = item.DatabaseValues[propertyName] ?? DBNull.Value;
        //                 }
        //             }
        //         }
        //
        //         var auditLogs = auditEntries
        //             .Select(auditEntry => auditEntry.ToAudit(
        //                 auditEntry.TableName,
        //                 auditEntry.Entry.OriginalValues.GetValue<Guid>("Id"),
        //                 DateTime.Now))
        //             .ToList();
        //
        //         await AuditLogs.AddRangeAsync(auditLogs);
        //     }
        //     catch (Exception e)
        //     {
        //         // Handle exceptions gracefully, log them appropriately
        //         Console.WriteLine("Exception during audit: " + e);
        //         throw;
        //     }
        // }
    }
}
