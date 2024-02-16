using Infogem.Utils;
using InfoGem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["Infogem:DefaultConnection"] ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
// builder.Services.AddIdentity<AppUser, IdentityRole>()
// .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentityApiEndpoints<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole<Guid>>()//Roles
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddRepositoryAndServiceLayers();// Extension method under Extensions/IServiceCollectionExtensions.cs
builder.Services.AddProblemDetails();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.CustomMapIdentityApi<AppUser>();
app.UseAuthentication();
app.UseAuthorization();
// app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();

app.Run();