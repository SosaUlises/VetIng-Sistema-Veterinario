using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VetIngSistemaVeterinario.Data;
using VetIngSistemaVeterinario.Modelo.Identity;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexi�n
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Registrar el contexto con Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity con Usuario y Rol personalizados
builder.Services.AddIdentity<Usuario, Rol>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
// seeder de identity
using (var scope = app.Services.CreateScope()) // Creamos un scope manual para acceder a los servicios
{
    var services = scope.ServiceProvider;

    // Llamamos al seeder para que cree roles y el usuario admin si no existen
    await IdentitySeeder.SeedRolesAndAdminAsync(services);
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();