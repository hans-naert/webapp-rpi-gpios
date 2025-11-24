using System.Device.Gpio;
using razor_web_app.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<GpioController>(
    s =>
    {
        var controller = new GpioController();
        // Initialize GPIO pins here if needed
        controller.OpenPin(18, PinMode.Output);
        return controller;
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapHub<ChatHub>("/chathub");
app.Run();
