// DiLifetimesDemo/Program.cs
using DiLifetimesDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// --- REGISTRO DE SERVICIOS ---
// Transient: Siempre una nueva instancia
builder.Services.AddTransient<TransientService>();

// Scoped: Una instancia por solicitud HTTP (request)
builder.Services.AddScoped<ScopedService>();

// Singleton: Una instancia para toda la vida de la aplicación
builder.Services.AddSingleton<SingletonService>();
// -----------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
