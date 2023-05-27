using Microsoft.AspNetCore.Identity;

namespace bmerketo_webshop.Helpers.Seed;

public class RoleSeedService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleSeedService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedRoles()
    {
        try
        {
            if (!await _roleManager.RoleExistsAsync("admin"))
                await _roleManager.CreateAsync(new IdentityRole("admin"));

            if (!await _roleManager.RoleExistsAsync("user"))
                await _roleManager.CreateAsync(new IdentityRole("user"));
        }
        catch { }
    }
}
