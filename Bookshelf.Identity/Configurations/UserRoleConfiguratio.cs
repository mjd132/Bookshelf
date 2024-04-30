using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Identity.Configurations;

public class UserRoleConfiguratio : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(new IdentityUserRole<string>
        {
            RoleId="CA116AFA-3F26-4BDC-AA76-8C924DE5A8B9",
            UserId="60C36B21-E1B8-4657-BDF2-7DD4C7E8746C"
        },new IdentityUserRole<string>()
        {
           RoleId="CA116AFA-3F26-4BDC-AA76-8C924DE5A8B9",
           UserId="54EFE6C5-2508-4FE5-A324-31D123637CDF"

        },new IdentityUserRole<string>()
        {
           RoleId="D4EDF13D-4866-4A67-A3EC-410AA4320F88",
           UserId="143C7A36-5E4C-4B67-94B8-EB3C874C2C45"

        });
    }
}