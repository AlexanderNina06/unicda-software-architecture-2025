using Inventory.Domain.enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.Administrator.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Administrator.ToString()));
            }

            if (!await roleManager.RoleExistsAsync(Roles.InventoryUser.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.InventoryUser.ToString()));
            }
        }
    }
}
