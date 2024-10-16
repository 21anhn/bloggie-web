using Bloggie.Web.Data;
using Bloggie.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using dotenv.net;
using Microsoft.AspNetCore.Identity;

namespace Bloggie.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Load the .env file before the app starts
            DotEnv.Load();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            builder.Services.AddDbContext<BloggieDbContext>(options => options.
            UseSqlServer(builder.Configuration.GetConnectionString("BloggieDbConnectionString")));

            builder.Services.AddDbContext<AuthDbContext>(options => options.
            UseSqlServer(builder.Configuration.GetConnectionString("BloggieAuthDbConnectionString")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>();

            //Use this to config Username, Password
            /*builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.
                options.User.
            })*/

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/AccessDenied";
            });

            builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            builder.Services.AddScoped<IImageRepository, ImageRepositoryCloudinary>();
            builder.Services.AddScoped<ITagRepository, TagRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllers();

            app.Run();
        }
    }
}
