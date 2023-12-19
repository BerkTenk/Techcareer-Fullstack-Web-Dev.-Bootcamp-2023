using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UserIdentity.Models
{
    public static class IdentitySeedData{
        private const string adminUser = "admin";
        private const string adminPassword = "Admin-123";
        public static async void IdentityTestUser(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();
            if(context.Database.GetAppliedMigrations().Any()){
                context.Database.Migrate();
            }
            var UserManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var user = await UserManager.FindByIdAsync(adminUser);
            if(user == null){
                user = new AppUser{
                    FullName = "Ahmet Kaya",
                    Email = "admin@admin.com",
                    PhoneNumber = "12345678912"
                };
                await UserManager.CreateAsync(user,adminPassword);
            }

        }
        
    } 
}