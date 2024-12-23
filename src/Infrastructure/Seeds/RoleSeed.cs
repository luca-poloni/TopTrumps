using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Seeds
{
    public class RoleSeed : IEntityTypeConfiguration<ApplicationRoleIdentity>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleIdentity> builder)
        {
            builder.HasData(
                new ApplicationRoleIdentity
                {
                    Id = "74a1977c-1e26-42c3-87d3-4e75f17e15ff",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }, 
                new ApplicationRoleIdentity
                {
                    Id = "50f59785-fef9-4955-9166-cefa4740a6e9",
                    Name = "User",
                    NormalizedName = "USER"
                });
        }
    }
}
