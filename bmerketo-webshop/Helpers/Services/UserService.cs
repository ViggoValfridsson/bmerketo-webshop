using bmerketo_webshop.Helpers.Repositories;
using bmerketo_webshop.Helpers.Seed;
using bmerketo_webshop.Models.Entities;
using bmerketo_webshop.Models.Identity;
using bmerketo_webshop.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bmerketo_webshop.Helpers.Services;

public class UserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AddressRepo _addressRepo;
    private readonly RoleSeedService _seed;

    public UserService(UserManager<AppUser> userManager, AddressRepo addressRepo, RoleSeedService seed)
    {
        _userManager = userManager;
        _addressRepo = addressRepo;
        _seed = seed;
    }

    public async Task<bool> UserExists(Expression<Func<AppUser, bool>> predicate)
    {
        return await _userManager.Users.AnyAsync(predicate);
    }

    public async Task<bool> SignUp(SignUpViewModel model)
    {
        try
        {
            await _seed.SeedRoles();

            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            AddressEntity? address = await _addressRepo.GetAsync(x => x.City == model.City && x.PostalCode == model.PostalCode && x.StreetName == model.StreetName);

            if (address == null)
                address = await _addressRepo.CreateAsync(model);

            AppUser user = model;
            user.AddressId = address!.Id;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }

            return false;
        }
   
        catch { return false; }
    }
}
