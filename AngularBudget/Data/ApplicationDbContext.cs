using AngularBudget.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AngularBudget.Data
{
    public class ApplicationDbContext : CustomApiAuthorizationDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Frequency>()
                .HasData(
                    new Frequency
                    {
                        FrequencyId = 1,
                        FrequencyName = "Days"
                    },
                    new Frequency
                    {
                        FrequencyId = 2,
                        FrequencyName = "Weeks"
                    },
                    new Frequency
                    {
                        FrequencyId = 3,
                        FrequencyName = "Months"
                    }
                );


            modelBuilder.Entity<Regularity>()
                .HasData(
                    new Regularity
                    {
                        RegularityId = 1,
                        RegularityName = "One Time"
                    },
                    new Regularity
                    {
                        RegularityId = 2,
                        RegularityName = "Recurring"
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}