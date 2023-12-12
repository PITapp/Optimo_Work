using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Hosting;

using OptimoWork.Data;
using OptimoWork.Models;
using OptimoWork.Authentication;

namespace OptimoWork
{
  public partial class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    partial void OnConfigureServices(IServiceCollection services);

    partial void OnConfiguringServices(IServiceCollection services);

    public void ConfigureServices(IServiceCollection services)
    {
      OnConfiguringServices(services);

      services.AddOptions();
      services.AddLogging(logging =>
      {
          logging.AddConsole();
          logging.AddDebug();
      });

      services.AddCors(options =>
      {
          options.AddPolicy(
              "AllowAny",
              x =>
              {
                  x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .SetIsOriginAllowed(isOriginAllowed: _ => true)
                  .AllowCredentials();
              });
      });
      services.AddMvc(options =>
      {
          options.EnableEndpointRouting = false;

          options.OutputFormatters.Add(new OptimoWork.Data.XlsDataContractSerializerOutputFormatter());
          options.FormatterMappings.SetMediaTypeMappingForFormat("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

          options.OutputFormatters.Add(new OptimoWork.Data.CsvDataContractSerializerOutputFormatter());
          options.FormatterMappings.SetMediaTypeMappingForFormat("csv", "text/csv");
      }).AddNewtonsoftJson();

      services.AddAuthorization();
      
          services.AddOData();
          services.AddODataQueryFilter();

      services.AddHttpContextAccessor();
      var tokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = TokenProviderOptions.Key,
          ValidateIssuer = true,
          ValidIssuer = TokenProviderOptions.Issuer,
          ValidateAudience = true,
          ValidAudience = TokenProviderOptions.Audience,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
      };

      services.AddAuthentication(options =>
      {
          options.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
          options.Audience = TokenProviderOptions.Audience;
          options.ClaimsIssuer = TokenProviderOptions.Issuer;
          options.TokenValidationParameters = tokenValidationParameters;
          options.SaveToken = true;
      });
      services.AddDbContext<ApplicationIdentityDbContext>(options =>
      {
         options.UseMySql(Configuration.GetConnectionString("dbOptimoConnection"));
      });

      services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

      services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationPrincipalFactory>();


      services.AddDbContext<OptimoWork.Data.DbOptimoContext>(options =>
      {
        options.UseMySql(Configuration.GetConnectionString("dbOptimoConnection"));
      });

      OnConfigureServices(services);
    }

    partial void OnConfigure(IApplicationBuilder app);


    partial void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
    partial void OnConfiguring(IApplicationBuilder app, IWebHostEnvironment env);
    partial void OnConfigureOData(ODataConventionModelBuilder builder);

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      OnConfiguring(app, env);

      IServiceProvider provider = app.ApplicationServices.GetRequiredService<IServiceProvider>();
      app.UseCors("AllowAny");
      app.Use(async (context, next) => {
          if (context.Request.Path.Value == "/__ssrsreport" || context.Request.Path.Value == "/ssrsproxy") {
            await next();
            return;
          }
          await next();
          if ((context.Response.StatusCode == 404 || context.Response.StatusCode == 401) && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.Contains("/odata")) {
              context.Request.Path = "/index.html";
              await next();
          }
      });

      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseDeveloperExceptionPage();

      app.UseMvc(builder =>
      {
        if (env.EnvironmentName == "Development")
        {
            builder.MapRoute(name: "default",
              template: "{controller}/{action}/{id?}",
              defaults: new { controller = "Home", action = "Index" }
            );
        }

          builder.Count().Filter().OrderBy().Expand().Select().MaxTop(null).SetTimeZoneInfo(TimeZoneInfo.Utc);
        

          var oDataBuilder = new ODataConventionModelBuilder(provider);

          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.Base>("Bases");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.BaseAnreden>("BaseAnredens");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.BaseKontakte>("BaseKontaktes");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.Benutzer>("Benutzers");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.InfotexteHtml>("InfotexteHtmls");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.InventurArtikel>("InventurArtikels");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.InventurBasis>("InventurBases");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.InventurBasisStatus>("InventurBasisStatuses");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.InventurDevice>("InventurDevices");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.InventurErfassung>("InventurErfassungs");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.Notizen>("Notizens");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.Protokoll>("Protokolls");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwBase>("VwBases");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwBaseAlle>("VwBaseAlles");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwBaseKontakte>("VwBaseKontaktes");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwBaseOrte>("VwBaseOrtes");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwBasePlz>("VwBasePlzs");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwBenutzerBase>("VwBenutzerBases");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwBenutzerRollen>("VwBenutzerRollens");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwErfassungNav>("VwErfassungNavs");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwErfassungSummen>("VwErfassungSummens");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwInventurArtikel>("VwInventurArtikels");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwInventurArtikelAlle>("VwInventurArtikelAlles");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwInventurErfassung>("VwInventurErfassungs");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwInventurErfassungBdo>("VwInventurErfassungBdos");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwInventurErfassungSummen>("VwInventurErfassungSummens");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwInventurLagerorte>("VwInventurLagerortes");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwInventurLagerorteMitSummen>("VwInventurLagerorteMitSummens");
          oDataBuilder.EntitySet<OptimoWork.Models.DbOptimo.VwRollen>("VwRollens");

          this.OnConfigureOData(oDataBuilder);

          oDataBuilder.EntitySet<ApplicationUser>("ApplicationUsers");
          var usersType = oDataBuilder.StructuralTypes.First(x => x.ClrType == typeof(ApplicationUser));
          usersType.AddCollectionProperty(typeof(ApplicationUser).GetProperty("RoleNames"));
          oDataBuilder.EntitySet<IdentityRole>("ApplicationRoles");

          var model = oDataBuilder.GetEdmModel();

          builder.MapODataServiceRoute("odata/dbOptimo", "odata/dbOptimo", model);

          builder.MapODataServiceRoute("auth", "auth", model);
      });


      if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("RADZEN")) && env.IsDevelopment())
      {
        app.UseSpa(spa =>
        {
          spa.Options.SourcePath = "../client";
          spa.UseAngularCliServer(npmScript: "start -- --port 8000 --open");
        });
      }

      OnConfigure(app);
      OnConfigure(app, env);
    }
  }

  
}
