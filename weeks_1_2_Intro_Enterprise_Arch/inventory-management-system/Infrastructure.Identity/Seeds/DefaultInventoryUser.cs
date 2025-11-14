using Infrastructure.Identity.Entities;
using Inventory.Domain.enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultInventoryUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "user@inventory.com",  
                Email = "user@inventory.com",
                FirstName = "Jane",
                LastName = "Smith",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "User123!");
                await userManager.AddToRoleAsync(defaultUser, Roles.InventoryUser.ToString());
            }
        }
    }
}
