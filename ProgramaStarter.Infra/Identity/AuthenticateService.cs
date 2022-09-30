using Microsoft.AspNetCore.Identity;
using ProgramaStarter.Domain.Account;

namespace ProgramaStarter.Infra.Data.Identity;
public class AuthenticateService : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthenticateService(SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email,
            password, false, lockoutOnFailure: false);

        return result.Succeeded;
    }
    public async Task<string> RegisterUser(string email, string password)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        var result = await _userManager.CreateAsync(applicationUser, password);
        
        string newId = "";

        if (result.Succeeded)
        {
            newId = applicationUser.Id;
        }
        
        return newId;
    }

    public async Task UpdateUser(string id, string email)
    {
        var user = await _userManager.FindByIdAsync(id);
        user.Email = email;
        user.UserName = email;
        user.NormalizedEmail = email.ToUpper();
        user.NormalizedUserName = email.ToUpper();

        var result = await _userManager.UpdateAsync(user);
    }

    public async Task RemoveUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        var result = await _userManager.DeleteAsync(user);
    }

    //teste de atribuição de claims a um usuário
    //public async Task AplicarRoleAdmin (string email)
    //{
    //    var usuario = await _userManager.FindByEmailAsync(email);
    //    await _userManager.AddClaimAsync(usuario, new Claim("Admin", "true"));
    //}
    //public async Task RemoverRoleAdmin(string email)
    //{
    //    var usuario = await _userManager.FindByEmailAsync(email);
    //    await _userManager.RemoveClaimAsync(usuario, new Claim("Admin", "true"));
    //}

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}
