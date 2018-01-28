using SRM.Common.Constants;
using SRM.Core.Entities;
using SRM.Core.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace SRM.Core
{
    public class DbInitializer
    {
        public static void Initialize(DefaultDbContext context)
        {
            //context.Migrate();

            var roles = new List<Role>
                {
                    new Role {  Name = UserRole.Starosta, NormalizedName = UserRole.Starosta.ToUpper() },
                    new Role {  Name = UserRole.Student, NormalizedName = UserRole.Student.ToUpper() }
                };

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                //password = Haslo?123
                var passwordHash = "AQAAAAEAACcQAAAAEM6tqldIOG06fEG2Tt7wtcdtoIxypznKeXP1+xVwi9cLaR1/Nbs8svMU/KNI9N+3BQ==";
                var admin = new User
                {
                    Email = "admin@admin.com",
                    PasswordHash = passwordHash,
                    RoleId = roles[0].Id
                };
                context.Users.Add(admin);
                context.SaveChanges();
            }
            if (!context.Chats.Any())
            {
                var mainChat = new Chat
                {
                    Name = "STARchat"
                };
                context.Chats.Add(mainChat);
                context.SaveChanges();
            }
        }
    }
}