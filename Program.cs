using RazerChroma;

namespace Program
{
    class BotAPI
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            Chroma instance = new();
            instance.InitChroma();
            var muted = false;

            app.MapGet("/mutestatus", () =>
            {
                return muted;
            });

            app.MapPost("/mutestatus/{mute}", (bool mute) =>
            {
                if (mute != muted)
                {
                    instance.setEffect(ChromaSDK.Keyboard.RZKEY.RZKEY_INSERT, mute);
                    muted = mute;
                }

                return Results.NoContent();
            });

            app.Run();
        }
    }
        
}


