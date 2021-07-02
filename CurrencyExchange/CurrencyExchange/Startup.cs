using CurrencyExchange.Contracts.Querys;
using CurrencyExchange.Contracts.UseCases;
using CurrencyExchange.DataAccess;
using CurrencyExchange.UseCases;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
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
                    options.DefaultChallengeScheme = FacebookDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddFacebook(options =>
            {
                options.AppId = Configuration["FacebookAppId:AppId"];
                options.AppSecret = Configuration["FacebookAppSecret:AppSecret"];
            }).AddCookie();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
