using Bogkatalog.Web.Components;
using Bogkatalog.Web.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
// Lokale data er bevidst valgt som udgangspunkt. Senere kalder vi et REST API.
builder.Services.AddScoped<BookRepository>();
var app = builder.Build();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();

