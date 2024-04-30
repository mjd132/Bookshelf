using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Identity.Configurations;

public class RoleCofiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id="D4EDF13D-4866-4A67-A3EC-410AA4320F88",
                Name="Employee",
                NormalizedName="EMPLOYEE"

            },
            new IdentityRole
            {
                Id="91F05C11-E96F-4B4E-9F0A-203C4A98936C",
                Name="User",
                NormalizedName="USER"
            },
            new IdentityRole
            {
                Id="CA116AFA-3F26-4BDC-AA76-8C924DE5A8B9",
                Name="Administrator",
                NormalizedName="ADMINISTRATOR"
            }
            );
    }
}
