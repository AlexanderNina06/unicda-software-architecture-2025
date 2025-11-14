using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Configurations
{
    public class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            #region properties

            builder
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            #endregion

            #region indexes

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            #endregion

            builder.ToTable("User", "Identity");
        }
    }
}
