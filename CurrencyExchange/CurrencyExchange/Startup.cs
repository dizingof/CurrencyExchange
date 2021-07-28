using CurrencyExchange.Contracts.Querys;
using CurrencyExchange.Contracts.UseCases;
using CurrencyExchange.DataAccess;
using CurrencyExchange.UseCases;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CurrencyExchange
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
            services.AddCors();
            services.AddScoped<IGetListCurrencyUseCase, GetListCurrencyUseCase>();
            services.AddScoped<IGetWeatherUseCase, GetWeatherUseCase>();
            services.AddScoped<IUsdRatesQuery, UsdRatesQuery>();
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/account/facebook-login"; // Must be lowercase
                }).AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["FacebookAppId:AppId"];
                facebookOptions.AppSecret = Configuration["FacebookAppSecret:AppSecret"];
                facebookOptions.Scope.Add("email");
                facebookOptions.Scope.Add("user_location");
                facebookOptions.Scope.Add("user_birthday");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
