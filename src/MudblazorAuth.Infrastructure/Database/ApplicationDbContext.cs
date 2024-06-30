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

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ConfigureTableAndColumnNamesLowercase(modelBuilder);

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
				new Page { Id = 1, Url = "/SignIn", IsPrivate = false },
				new Page { Id = 2, Url = "/SignUp", IsPrivate = false },
				//Acesso Admin e User
				new Page { Id = 3, Url = "/Home", IsPrivate = true },
				new Page { Id = 4, Url = "/Counter", IsPrivate = true },
				new Page { Id = 5, Url = "/Weather", IsPrivate = true },
				//Acessi Admnin
				new Page { Id = 6, Url = "/ProfilePermissionsPage", IsPrivate = true },
				new Page { Id = 7, Url = "/Users", IsPrivate = true },
				new Page { Id = 8, Url = "/AccessDenied", IsPrivate = true }
			);

			modelBuilder.Entity<ProfilePage>().HasData(
				new ProfilePage { Id = 1, IdProfile = 1, IdPage = 3 },
				new ProfilePage { Id = 2, IdProfile = 1, IdPage = 4 },
				new ProfilePage { Id = 3, IdProfile = 1, IdPage = 5 },
				new ProfilePage { Id = 4, IdProfile = 1, IdPage = 6 },
				new ProfilePage { Id = 5, IdProfile = 1, IdPage = 7 },
				new ProfilePage { Id = 6, IdProfile = 1, IdPage = 8 },
				new ProfilePage { Id = 7, IdProfile = 2, IdPage = 3 },
				new ProfilePage { Id = 8, IdProfile = 2, IdPage = 4 },
				new ProfilePage { Id = 9, IdProfile = 2, IdPage = 5 }
			);
		}
	}
}
