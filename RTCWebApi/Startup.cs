using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RTCWebApi.Model.Common;
using RTCWebApi.Model.Entities.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RTCWebApi
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RTCWebApi", Version = "v1" });
            });

            string[] ogirins = Configuration.GetSection($"Cors:Ogirins").Get<string[]>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins(ogirins)
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 1, "ok");
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });

            //services.Configure<FormOptions>(x =>
            //{
            //    x.ValueLengthLimit = int.MaxValue;
            //    x.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
            //    x.MultipartHeadersLengthLimit = int.MaxValue;
            //});

            services.Configure<FormOptions>(options =>
            {
                // Kích thước tối đa mỗi phần form (field/file) 
                options.MultipartBodyLengthLimit = Int32.MaxValue;

                // Nếu file < 1 MB thì vẫn buffer hết trong RAM trước khi viết ra
                options.MemoryBufferThreshold = 1 * 1024 * 1024;
                // (Tuỳ chọn) nếu có rất nhiều fields, tăng số fields tối đa
                options.ValueCountLimit = 1000;

                // (Tuỳ chọn) tăng độ dài tối đa tên key/value nếu cần
                options.ValueLengthLimit = 64 * 1024;

            });

            //services.AddAuthentication(IISDefaults.AuthenticationScheme);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RTCWebApi v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("MyPolicy");

            //Using static files
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Config.Path())),
            //    RequestPath = new PathString("/api/Upload")
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("PathDownloadVersion")),
            //    RequestPath = new PathString("/api/NewVersion")
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("PathPaymentOrder")),
            //    RequestPath = new PathString("/api/paymentorder")
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("PathSignImage")),
            //    RequestPath = new PathString("/api/imagesign")
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("PathExcercise")),
            //    RequestPath = new PathString("/api/excercise")
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("PathDemo")),
            //    RequestPath = new PathString("/api/demo")
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("PathProjectSolution")),
            //    RequestPath = new PathString("/api/project")
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("PathVehicleBooking")),
            //    RequestPath = new PathString("/api/datxe")
            //});

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Configuration.GetValue<string>("PathImageCourse")),
            //    RequestPath = new PathString("/api/imagecourse")
            //});

            List<PathStaticFile> listPaths = Configuration.GetSection("PathStaticFiles").Get<List<PathStaticFile>>();
            foreach (var item in listPaths)
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(item.PathFull),
                    RequestPath = new PathString($"/api/{item.PathName}")
                });
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public class PathStaticFile
        {
            public string PathName { get; set; }
            public string PathFull { get; set; }
        }
    }
}
