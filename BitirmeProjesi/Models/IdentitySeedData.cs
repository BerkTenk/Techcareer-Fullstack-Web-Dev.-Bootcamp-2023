using BitirmeProjesi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Models
{
    public static class IdentitySeedData{

        private const string adminUser = "admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app){
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

            if(context.Database.GetAppliedMigrations().Any()){
                context.Database.Migrate();
            }

            var UserManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var user = await UserManager.FindByIdAsync(adminUser);

            if(user == null){
                user = new IdentityUser{
                    UserName = "Ahmet Kaya",
                    Email = "admin@ahmetkaya.com",
                    PhoneNumber = "12345678912"
                };

                await UserManager.CreateAsync(user,adminPassword);
            }

        }


    }
}