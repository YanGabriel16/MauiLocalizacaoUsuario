using Microsoft.Extensions.Logging;
using ficym.Data;
using ficym.IServices.location;
using ficym.Services;
using ficym.Entities;

namespace ficym;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddScoped<ILocationService, LocationService>();
		builder.Services.AddSingleton<GeoCordinates>();
		builder.Services.AddBlazorWebViewDeveloperTools();

        return builder.Build();
	}
}
