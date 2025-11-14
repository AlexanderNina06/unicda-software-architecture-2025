using Infrastructure.Identity.Entities;
using Inventory.Domain.enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultAdministrator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultAdmin = new ApplicationUser
            {
                UserName = "admin@inventory.com",
                Email = "admin@inventory.com",
                FirstName = "John",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true
            };

            var user = await userManager.FindByEmailAsync(defaultAdmin.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultAdmin, "Admin123!");
                await userManager.AddToRoleAsync(defaultAdmin, Roles.Administrator.ToString());
            }
        }
    }
}
