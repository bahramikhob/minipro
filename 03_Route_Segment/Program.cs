using UrlRoutingSamples.CustomConstraints;

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

//app.MapGet("/io/{filename}.{extentsion}/t", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }
//});
//app.MapGet("/{Segment01}/{Segmetn02}/{Segment03=ARO}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});
//app.MapGet("/{Segment01}/{Segmetn02}/{Segment03?}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});
//app.MapGet("/{Segment01}/{Segmetn02}/{Segment03}/{*catchall}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});
//app.MapGet("/{Segment01:minlength(2):maxlength(6)}/{Segmetn02:bool}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});


builder.Services.Configure<RouteOptions>(opts =>
{
    opts.ConstraintMap.Add("nc",
    typeof(CodeMeliConstraint));
});


//app.MapGet("/cm/{codemelli:nc}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});


//روت شبیه به هم
//create a Exception 

//app.MapGet("/cm/{age:int}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//})


//app.MapGet("/cm/{price:double}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});

//روت شبیه به هم و اولویت بندی ان با
//order


//app.MapGet("/cm/{age:int}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//}).Add(c => ((RouteEndpointBuilder)c).Order = 1);
//app.MapGet("/cm/{price:double}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//}).Add(c => ((RouteEndpointBuilder)c).Order = 2);


// Fallback تعریف

//app.MapFallback(async context =>
//{
//    await context.Response.WriteAsync($"Fallback works");

//});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.Run();
