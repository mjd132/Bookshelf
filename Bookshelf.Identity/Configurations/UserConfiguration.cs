using Bookshelf.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(new ApplicationUser
        {
            Id= "54EFE6C5-2508-4FE5-A324-31D123637CDF",
            Email="admin@admin.admin",
            NormalizedEmail="ADMIN@ADMIN.ADMIN",
            Name="Admin",
            UserName="Admin",
            NormalizedUserName="ADMIN",
            PasswordHash=hasher.HashPassword(null,"AdminPASS"),
            EmailConfirmed=true,
        },new ApplicationUser
        {
            Id= "143C7A36-5E4C-4B67-94B8-EB3C874C2C45" ,
            Email="emp@emp.emp",
            NormalizedEmail="EMP@EMP.EMP",
            Name="Employee",
            UserName="Emp",
            NormalizedUserName="EMP",
            PasswordHash=hasher.HashPassword(null,"EmpPASS"),
            EmailConfirmed=true,
        },new ApplicationUser
        {
            Id="60C36B21-E1B8-4657-BDF2-7DD4C7E8746C",
            Email="majid.abbasi.ce@gmail.com",
            NormalizedEmail="MAJID.ABBASI.CE@GMAIL.COM",
            Name="Majid Abbasi",
            UserName="Majid_Abbasi",
            NormalizedUserName="MAJID_ABBASI",
            PasswordHash=hasher.HashPassword(null,"majidadmin"),
            EmailConfirmed=true,
        });
    }
}
