using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FrontendModule.Templates;
using FrontendModule.Handlers;

namespace FrontendModule
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
                .ConfigureMauiHandlers((handlers) =>
            {
                handlers.AddHandler(typeof(GradientLabel), typeof(GradientLabelHandler));
            })
                .UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}