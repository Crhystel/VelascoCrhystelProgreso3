using Microsoft.Extensions.Logging;
using VelascoCrhystelProgreso3.Repositories;
using VelascoCrhystelProgreso3.ViewModels;

namespace VelascoCrhystelProgreso3
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<CVConexionDBRepository>();
            builder.Services.AddSingleton<CVAeropuertoRepository>();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<CVAeroPuertoViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
