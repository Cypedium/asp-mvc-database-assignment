using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_mvc_database_assignment.Models
{
    public class DbInitializer
    {
        internal static void Initialize(
            HandleStudentsDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager
            )
        {
            // Check if our database is created if not then create it
            context.Database.EnsureCreated();
            
            //Look for any Databasedata
            if (context.Roles.Any())
            {
                return; //DB has been seeded
            }

            //----------Roles seed-----------------------------------//

            IdentityRole[] identityRoles = new IdentityRole[]
            {
                new IdentityRole("Admin"),
                new IdentityRole("God")

            };
            foreach (var role in identityRoles)
            {
                roleManager.CreateAsync(role).Wait();
            }

            //--------------Users seed-------------------------------//

            IdentityUser[] identityUsers = new IdentityUser[]
            {
                new IdentityUser("Admin"),
                new IdentityUser("God")
            };

            identityUsers[0].Email = "a@a.a";
            identityUsers[1].Email = "g@g.g";

            string[] passwords = { "Qwerty!123456", "Password!123456" };

            for (int i = 0; i < identityUsers.Length; i++)
            {
                userManager.CreateAsync(identityUsers[i], passwords[i]);
            }

            //----------Role to Users seed----------------------------//




            //-------Students seeed-----------------------------------//

            var studentSeed = new Student[]
            {
                new Student(){
                    F_Name = "Kent",
                    L_Name = "Olsson",
                    E_mail = "kent.olsson@gmail.com"
                },
                new Student(){
                    F_Name = "Max",
                    L_Name = "Olsson",
                    E_mail = "max.olsson@gmail.com"
                },
                new Student(){
                    F_Name = "Tindra",
                    L_Name = "Snövit",
                    E_mail = "tindra.snövit@gmail.com"
                },
            };

            foreach (Student student in studentSeed)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();           
        }
    }
}
