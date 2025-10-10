using System.Diagnostics;
using RaceAdmin.WebClient.Components;

namespace RaceAdmin.WebClient
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseAntiforgery();

			app.MapStaticAssets();
			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode();

			IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.Build();

			var url = configuration["Kestrel:Endpoints:Http:Url"];

			app.Start();

			// Launch the default browser pointed to the url on startup.
			Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });

			app.WaitForShutdown();
		}
	}
}
