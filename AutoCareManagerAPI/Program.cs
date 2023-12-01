using AutoCareManagerDOMAIN.Core.Filters;
using AutoCareManagerDOMAIN.Core.Interfaces;
using AutoCareManagerDOMAIN.Infraestructure.Data;
using AutoCareManagerDOMAIN.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().
    ConfigureApiBehaviorOptions(options => { 
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AutoCareManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoCareManagerAPIContext"))
);

builder
    .Services
    .AddTransient<IUsuariosRepository, UsuariosRepository>();

builder
    .Services
    .AddTransient<IEmpleadosRepository, EmpleadosRepository>();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
