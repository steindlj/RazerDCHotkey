using RazerChroma;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
var muted = false;
Chroma.InitChroma();

app.MapGet("/mutestatus", () =>
{
    return muted;
});

app.MapPost("/mutestatus/{mute}", (bool mute) =>
{
    if (mute != muted)
    {
        Chroma.setEffect(ChromaSDK.Keyboard.RZKEY.RZKEY_INSERT, mute);
        muted = mute;
    }

    return Results.NoContent();
});

app.Run();


