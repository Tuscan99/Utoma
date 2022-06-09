using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Utoma.Models
{
    public static class IdentitySampleData
    {
        private const string adminUserName = "Admin";
        private const string adminPassword = "Abcd1234!";
        public static async void FillUpUser (IApplicationBuilder app)
        {
            //UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = (UserManager<IdentityUser>)scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>));
                IdentityUser user = await userManager.FindByIdAsync(adminUserName);
                if (user == null)
                {
                    user = new IdentityUser("Admin");
                    await userManager.CreateAsync(user, adminPassword);
                }
            }

        }
    }
}
