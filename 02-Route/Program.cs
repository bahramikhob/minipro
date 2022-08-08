using UrlRoutingSamples.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/mv/Nimroo", new MavadeLazem().InvokeAsync);
    endpoints.MapGet("/test/Nimroo", new MavadeLazem().InvokeAsync);
    endpoints.MapGet("/tt/Nimroo", new TarzeTahie().InvokeAsync);
    endpoints.MapGet("/tt/Kotlet", new TarzeTahie().InvokeAsync);

    endpoints.MapGet("/routing", async context =>
    {
        await context.Response.WriteAsync("Routing Endpoint");

    }).WithDisplayName("My Endpiont");

});



app.Run();
