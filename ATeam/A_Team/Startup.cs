using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using A_Team.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace A_Team
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //GlobalConfiguration.Configuration
            //.UseSqlServerStorage(@"Data Source =.; database = ATeam;  Integrated Security=True; ");
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            //{
            //    Authorization = new[] { new HangFireAuthorizationFilter() }
            //});

            //RecurringJob.AddOrUpdate(() => Debug.WriteLine("ff") , Cron.Hourly);
            //app.UseHangfireDashboard();
            //app.UseHangfireServer();
            //var rm = new System.Resources.ResourceManager(typeof(Pages.Templates));
            //System.Resources.ResourceSet rs = rm.GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, true, true);
            //DateTime currentdate = new DateTime();
            //currentdate = DateTime.Now;
            //DateTime deadline = new DateTime();
            //deadline = currentdate.AddDays(7);
            //Interfaces.IEmailInteractor emailInteractor = new Email();
            //List<IEmail> emails = new List<IEmail>();
            //var email = new Data.EmailModel
            //{
            //    Country = "Germany",
            //    //EmailTo = contact.Email,
            //    EmailSubject = "testt",
            //    EmailBody = string.Format(rs.GetString("EmailBody"), string.Format("{0}. of {1}, {2}.", currentdate.Day, currentdate.ToString("MMMM"), currentdate.Year)
            //       , string.Format("{0}. of {1}, {2}.", deadline.Day, deadline.ToString("MMMM"), deadline.Year)),
            //    EmailFrom = rs.GetString("EmailFrom"),
            //    EmailTo = "sjabyelharamein@kpmg.com",
            //    //emailTemplate.CC = rs.GetString("CC"),
            //    SMTPServer = rs.GetString("SMTPServer")
            //};
            //emails.Add(email);
            //emailInteractor.SendMails(emails);
       
            Rules.RunRules();

            app.UseMvc();
        }
    }
}
