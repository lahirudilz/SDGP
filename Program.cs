using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using SendGrid.Extensions.DependencyInjection;
using susFaceGen.Areas.Identity.Data;
using susFaceGen.Data;
using susFaceGen.Services;
using Azure.Identity;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("susFaceGenContextConnection") ?? throw new InvalidOperationException("Connection string 'susFaceGenContextConnection' not found.");

builder.Services.AddDbContext<susFaceGenContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<susFaceGenUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<susFaceGenContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<SendGridConfiguration>(builder.Configuration.GetSection("SendGridConfiguration"));

builder.Services.AddSendGrid(options =>
{
    options.ApiKey = Environment.GetEnvironmentVariable("SendGridAPIKey");
});

builder.Services.AddScoped<IEmailSender, EmailSenderService>();

var openAiApiKey = Environment.GetEnvironmentVariable("OpenAiApiKey");

builder.Services.AddSingleton(new OpenAiServices { OpenAiApiKey = openAiApiKey});

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(Environment.GetEnvironmentVariable("storageconnection"), preferMsi: true);
});

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    using (var context = serviceScope.ServiceProvider.GetService < susFaceGenContext> ())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
