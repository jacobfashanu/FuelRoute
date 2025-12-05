var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient("FuelRouteAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5218"); // your API URL
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();   // important for css/js/images

app.UseRouting();

app.UseAuthorization();

// 👇 THIS enables Razor Pages routing
app.MapRazorPages();

app.Run();
