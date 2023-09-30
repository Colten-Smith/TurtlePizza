using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Capstone.DAO;
using Capstone.Security;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Capstone.DAO.Interfaces;

namespace Capstone
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
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            string connectionString = Configuration.GetConnectionString("Project");

            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(Configuration["JwtSecret"]);
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap[JwtRegisteredClaimNames.Sub] = "sub";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    NameClaimType = "name"
                };
            });

            // Dependency Injection configuration
            services.AddSingleton<ITokenGenerator>(tk => new JwtGenerator(Configuration["JwtSecret"]));
            services.AddSingleton<IPasswordHasher>(ph => new PasswordHasher());
            services.AddTransient<IUserDao>(m => new UserSqlDao(connectionString));
            services.AddTransient<ICheeseDao>(chd => new CheeseSqlDao(connectionString));
            services.AddTransient<ICrustDao>(crd => new CrustSqlDao(connectionString));
            services.AddTransient<ISauceDao>(sd => new SauceSqlDao(connectionString));
            services.AddTransient<ISideDao>(sd => new SideSqlDao(connectionString));
            services.AddTransient<IDrinkDao>(dd => new DrinkSQLDao(connectionString));
            services.AddTransient<ISizeDao>(szd => new SizeSqlDao(connectionString));
            services.AddTransient<ICrustDao>(cd => new CrustSqlDao(connectionString));
            services.AddTransient<IAddressDao>(ad => new AddressSqlDao(connectionString));
            services.AddTransient<IPaymentDao>(pyd => new PaymentSqlDao(connectionString));
            services.AddTransient<IToppingDao>(td => new ToppingSqlDao(connectionString));

            services.AddTransient<IPizzaDao>(pd => new PizzaSqlDao(connectionString, pd.GetRequiredService<ICrustDao>(), 
                pd.GetRequiredService<ISauceDao>(), pd.GetRequiredService<ISizeDao>()));

            services.AddTransient<IOrderDao>(od => new OrderSqlDao(connectionString, od.GetRequiredService<IPizzaDao>(), 
                od.GetRequiredService<ISideDao>(), od.GetRequiredService<IDrinkDao>()));

            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = Configuration["APIVersion"],
                    Title = "Capstone Starter API",
                    Description = "For TE Capstone"
                });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer token is required for access.",
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                        },new List<string>()
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Capstone Starter API");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
