using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.WebAPI.Data;
using AutoMapper;
using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace SmartSchool.WebAPI
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
            services.AddScoped<IRepository,Repository>();

            services.AddDbContext<SmartContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("SqlServer"))
                );

            services.AddControllers()
                .AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling =
                                   Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddVersionedApiExplorer(options =>

            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            }
            )
            .AddApiVersioning(options =>

            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            }
            );

            var apiProviderDescription = services.BuildServiceProvider()
                                                 .GetService<IApiVersionDescriptionProvider>();


            services.AddSwaggerGen(options =>
            {
                foreach(var description in apiProviderDescription.ApiVersionDescriptions)
                {
					options.SwaggerDoc(
					description.GroupName,
					new Microsoft.OpenApi.Models.OpenApiInfo()
					{
						Title = "SmartSchool API",
						Version = description.ApiVersion.ToString(),
                        TermsOfService = new Uri ("http://SeusTermosDeUso.com"),
                        Description = "WebAPI do SmartSchool",
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                            Name = "SmartSchool License",
                            Url = new Uri("http://mit.com")
                        },
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Lucas Ferreira Guedes",
                            Email =  "lucasferreiraguedes00@gmail.com",
                            Url = new Uri("http://programadamente.com")
                        }
					}
				);
				}
                
				var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlFullComment = Path.Combine(AppContext.BaseDirectory, xmlComments);

				options.IncludeXmlComments(xmlFullComment);

			});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescription)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    foreach(var description in apiVersionDescription.ApiVersionDescriptions)
                    {
						options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                                               description.GroupName.ToUpperInvariant());
					}
                    options.RoutePrefix = "";
                }
                );

           

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}