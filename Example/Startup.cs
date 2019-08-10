using iLouminate.AssemblyFactory.Example.Factory;
using iLouminate.AssemblyFactory.Example.Services.Authenticators;
using iLouminate.AssemblyFactory.Example.Services.Encoders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iLouminate.AssemblyFactory.Example
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
			services.AddSingleton<IEncoderFactory, EncoderFactory>();
			services.AddSingleton<IAuthenticatorFactory, AuthenticatorFactory>();

			// Added for test purposes showcasing Scoped & Transient values.
			services.AddScoped<IWindowsAuthenticatorService, WindowsAuthenticatorService>();
			services.AddScoped<IFacebookAuthenticatorService, FacebookAuthenticatorService>();
			services.AddScoped<IChromeAuthenticatorService, ChromeAuthenticatorService>();
			services.AddScoped<ISha256Service, Sha256Service>();
			services.AddTransient<IMd5Service, Md5Service>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
