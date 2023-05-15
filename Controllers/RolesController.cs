using Microsoft.AspNetCore.Identity; // RoleManager, UserManager
using Microsoft.AspNetCore.Mvc; // Controller, IActionResult
using static System.Console;
namespace GroGem.Controllers;
public class RolesController : Controller
{
    private string AdminRole = "Administrators";
    private string UserEmail = "admin@sneedmail.com";
    private readonly RoleManager<IdentityRole<Guid>> roleManager;
    private readonly UserManager<ApplicationUser> userManager;

    public RolesController(RoleManager<IdentityRole<Guid>> roleManager,
    UserManager<ApplicationUser> userManager)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
    }
    public async Task<IActionResult> Index()
    {
        if (!(await roleManager.RoleExistsAsync(AdminRole)))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(AdminRole));
        }
        var user = await userManager.FindByEmailAsync(UserEmail);
        if (user == null)
        {
            user = new();
            user.UserName = UserEmail;
            user.Email = UserEmail;
            IdentityResult result = await userManager.CreateAsync(
            user, "Pa$$w0rd");
            if (result.Succeeded)
            {
                WriteLine($"User {user.UserName} created successfully.");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    WriteLine(error.Description);
                }
            }
        }
        if (!user.EmailConfirmed)
        {
            string token = await userManager
            .GenerateEmailConfirmationTokenAsync(user);
            IdentityResult result = await userManager
            .ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                WriteLine($"User {user.UserName} email confirmed successfully.");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    WriteLine(error.Description);
                }
            }
        }
        if (!(await userManager.IsInRoleAsync(user, AdminRole)))
        {
            IdentityResult result = await userManager.AddToRoleAsync(user,
            AdminRole);
            if (result.Succeeded)
            {
                WriteLine($"User {user.UserName} added to {AdminRole} successfully.");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    WriteLine(error.Description);
                }
            }
        }
        return Redirect("/");
    }
}