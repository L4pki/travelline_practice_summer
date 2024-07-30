using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddScoped<ITheaterRepositories, EFTheaterRepositories>();
builder.Services.AddScoped<IAuthorRepositories, EFAuthorRepositories>();
builder.Services.AddScoped<IPlayRepositories, EFPlayRepositories>();
builder.Services.AddScoped<ICompositionRepositories, EFCompositionRepsitories>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString( "Theater" );

builder.Services.AddDbContext<TheaterDbContext>( o =>
{
    o.UseSqlServer( connectionString, ob => ob.MigrationsAssembly( typeof( TheaterDbContext ).Assembly.FullName ) );
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
