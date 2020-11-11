using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Rzproekt.Core.Data;
using Rzproekt.Core.Extensions;
using Rzproekt.Models;
using Rzproekt.Services;

namespace Rzproekt {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Rzproekt")));

            services.AddCors();
            services.AddSignalR();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,

                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,

                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddControllers()
        .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new IntToStringExtension()));

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder => {
                builder.WithOrigins("https://publico-dev.xyz/", "https://publico-dev.xyz", "https://devmyprojects24.xyz/", "https://devmyprojects24.xyz").AllowAnyMethod().AllowAnyHeader();
            }));

            //services.Configure<FormOptions>(o =>  // currently all set to max, configure it to your needs!
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
            //    o.MultipartBoundaryLengthLimit = int.MaxValue;
            //    o.MultipartHeadersCountLimit = int.MaxValue;
            //    o.MultipartHeadersLengthLimit = int.MaxValue;
            //});

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.MaxRequestBodySize = int.MaxValue;
            //});

            //services.Configure<KestrelServerOptions>(options =>
            //{
            //    options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
            //});

            //services.Configure<FormOptions>(options =>
            //{
            //    options.ValueLengthLimit = int.MaxValue;
            //    options.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
            //    options.MultipartHeadersLengthLimit = int.MaxValue;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();                
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.Use(async (context, next) => {
            //    context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = 60000000; // unlimited I guess
            //    await next.Invoke();
            //});

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Route}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
