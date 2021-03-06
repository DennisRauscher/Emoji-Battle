﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emojidefender;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace backend
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<PlayerRepository>();
			services.AddSignalR(o =>
			{
				o.EnableDetailedErrors = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}


			app.UseFileServer();

			app.UseSignalR(route =>
			{
				route.MapHub<GameHub>("/gamehub");
			});
		}
	}
}
