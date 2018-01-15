using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SRM.Core;
using SRM.Core.Entities.Identity;
using SRM.Services;
using SRM.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SRM.Authorization;
using SRM.Common.Configurations;

namespace SRM
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.MaxModelValidationErrors = 50);
            services.AddDbContext<DefaultDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add Identity services to the services container.
            services.AddIdentity<User, Role>()
              .AddEntityFrameworkStores<DefaultDbContext>();

            services.Configure<EmailConfiguration>(Configuration.GetSection("EmailConfiguration"));

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = AuthorizationHelper.GetJwtBearerOptions();
                options.RequireHttpsMetadata = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DefaultDbContext dataContext)
        {
            DbInitializer.Initialize(dataContext);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
