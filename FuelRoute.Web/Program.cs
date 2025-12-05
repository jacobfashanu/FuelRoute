var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); // Registers Razor Pages as the UI framework
builder.Services.AddHttpClient("FuelRouteAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5218"); // your API URL
}); // Creates a client for making BackendAPI calls

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
