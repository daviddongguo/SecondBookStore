﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using David.SecondBook.OnlineStore.WebApi.Data;
using David.SecondBook.OnlineStore.Domain.Abstract;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace David.SecondBook.OnlineStore.WebApi
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
            services.AddMvc()
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            // Injection;
            // services.AddSingleton<IProductsRepository, EFDbProductsRepository>();
            services.AddDbContextPool<ProductsDbContext>( 
                        options => options.UseMySql(Configuration.GetConnectionString("secondBookStoreConnection"), 
                        mySqlOptions =>
                        {
                            mySqlOptions.ServerVersion(new Version(5, 6, 40), ServerType.MySql)
                                        .CharSetBehavior(CharSetBehavior.AppendToAllColumns)
                                        .AnsiCharSet(CharSet.Latin1)
                                        .UnicodeCharSet(CharSet.Utf8mb4)
                                        .DisableBackslashEscaping(); ; // replace with your Server Version and Type
                        }
                                                    ));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
