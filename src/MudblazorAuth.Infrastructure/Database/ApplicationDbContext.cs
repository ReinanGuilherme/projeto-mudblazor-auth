using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudblazorAuth.Domain.Entities;

namespace MudblazorAuth.Infrastructure.Database
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Profile> Profiles { get; set; }
		public DbSet<ProfilePage> ProfilePages { get; set; }
		public DbSet<Page> Page { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ConfigureTableAndColumnNamesLowercase(modelBuilder);

			modelBuilder.Entity<Account>(entity =>
			{
				entity.ToTable("accounts");
				entity.HasKey(e => e.Id).HasName("accounts_id_primary");
				entity.Property(e => e.Username).IsRequired().HasColumnName("user_name").HasMaxLength(255);
				entity.Property(e => e.Password).IsRequired().HasColumnName("password").HasMaxLength(255);
				entity.HasOne(e => e.Profile)
					  .WithMany(p => p.Accounts)
					  .HasForeignKey(e => e.IdProfile)
					  .HasConstraintName("accounts_profile_id_foreign");
				// Ensure UserName is unique
				entity.HasIndex(e => e.Username).IsUnique().HasDatabaseName("accounts_user_name_unique");
			});

			modelBuilder.Entity<Profile>(entity =>
			{
				entity.ToTable("profiles");
				entity.HasKey(e => e.Id).HasName("profiles_id_primary");
				entity.Property(e => e.Description).IsRequired().HasColumnName("description").HasMaxLength(255);
			});

			modelBuilder.Entity<Page>(entity =>
			{
				entity.ToTable("pages");
				entity.HasKey(e => e.Id).HasName("pages_id_primary");
				entity.Property(e => e.Url).IsRequired().HasColumnName("url").HasMaxLength(255);
				entity.Property(e => e.IsPrivate).IsRequired().HasColumnName("is_authenticated");
			});

			modelBuilder.Entity<ProfilePage>(entity =>
			{
				entity.ToTable("profile_pages");
				entity.HasKey(e => e.Id).HasName("profile_id_pages_primary");
				entity.HasOne(e => e.Profile)
					  .WithMany(p => p.ProfilePages)
					  .HasForeignKey(e => e.IdProfile)
					  .HasConstraintName("profile_pages_id_profile_foreign");
				entity.HasOne(e => e.Page)
					  .WithMany(p => p.ProfilePages)
					  .HasForeignKey(e => e.IdPage)
					  .HasConstraintName("profile_pages_page_id_foreign");
			});

			SeedData(modelBuilder); // Seed database with predefined information.
		}

		// Configure all table and column names to be lowercase
		private void ConfigureTableAndColumnNamesLowercase(ModelBuilder modelBuilder)
		{
			// Configure all table and column names to be lowercase
			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{
				entity.SetTableName(entity.GetTableName()!.ToLower());

				foreach (var property in entity.GetProperties())
				{
					property.SetColumnName(property.GetColumnName().ToLower());
				}

				foreach (var key in entity.GetKeys())
				{
					key.SetName(key.GetName()!.ToLower());
				}

				foreach (var key in entity.GetForeignKeys())
				{
					key.SetConstraintName(key.GetConstraintName()!.ToLower());
				}

				foreach (var index in entity.GetIndexes())
				{
					index.SetDatabaseName(index.GetDatabaseName()!.ToLower());
				}
			}
		}

		private void SeedData(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Profile>().HasData(
				new Profile { Id = 1, Description = "Admin" },
				new Profile { Id = 2, Description = "User" }
			);

			modelBuilder.Entity<Page>().HasData(
				new Page { Id = 1, Url = "/page1", IsPrivate = true },
				new Page { Id = 2, Url = "/page2", IsPrivate = true },
				new Page { Id = 3, Url = "/page3", IsPrivate = false }
			);

			modelBuilder.Entity<ProfilePage>().HasData(
				new ProfilePage { Id = 1, IdProfile = 1, IdPage = 1 },
				new ProfilePage { Id = 2, IdProfile = 1, IdPage = 2 },
				new ProfilePage { Id = 3, IdProfile = 1, IdPage = 3 },
				new ProfilePage { Id = 4, IdProfile = 2, IdPage = 3 }
			);
		}
	}
}
