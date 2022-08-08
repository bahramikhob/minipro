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



app.MapGet("/test123874749837/{Name}", new MavadeLazem().InvokeAsync)
   .WithMetadata(new RouteNameMetadata("mv"));

app.MapGet("/tt/{Name}", new TarzeTahie().InvokeAsync);

//test:  https://localhost:7230/tt/Kotlet


app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthorization();



app.Run();
