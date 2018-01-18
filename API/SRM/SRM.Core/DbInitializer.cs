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

            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role {  Name = UserRole.Starosta, NormalizedName = UserRole.Starosta.ToUpper() },
                    new Role {  Name = UserRole.Student, NormalizedName = UserRole.Student.ToUpper() }
                };
                context.Roles.AddRange(roles);
            }
            if (!context.Users.Any())
            {
                //password = Haslo?123
                var passwordHash = "AQAAAAEAACcQAAAAEM6tqldIOG06fEG2Tt7wtcdtoIxypznKeXP1+xVwi9cLaR1/Nbs8svMU/KNI9N+3BQ==";
                var admin = new User
                {
                    Email = "admin@admin.com",
                    PasswordHash = passwordHash,
                    RoleId = 1
                };
                context.Users.Add(admin);
            }
            if (!context.Chats.Any())
            {
                var mainChat = new Chat
                {
                    Name = "STARchat"
                };
                context.Chats.Add(mainChat);
            }
            context.SaveChanges();
        }
    }
}