using InventoryHub.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InventoryService>();
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.PropertyNamingPolicy = null; // Keep PascalCase if needed
});

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
