using McERPSystem.UI.Components;
using Microsoft.EntityFrameworkCore;
using McERPSystem.Services;
using McERPSystem.Services.Inventory;
using McERPSystem.Services.Clients;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<McERPSystem.Services.Orders.IOrderService, McERPSystem.Services.Orders.OrderService>();
builder.Services.AddScoped<McERPSystem.Services.Invoices.IInvoiceService, McERPSystem.Services.Invoices.InvoiceService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
