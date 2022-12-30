using car_gallery_app.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace car_gallery_app {
    public class Startup {
        public void Configure(IServiceCollection services) {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy= SameSiteMode.None;
            });

            services.AddScoped<CarService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}
