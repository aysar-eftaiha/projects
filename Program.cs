using Federation_proj.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddOpenApi();
builder.Services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFcontext>(options => options.UseNpgsql(ConnectionString));
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
options.AddPolicy("DevCors",policy => 
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
options.AddPolicy("ProdCors", policy =>
    policy.AllowAnyMethod()
        .AllowAnyMethod()
        .WithOrigins("*"));
});
builder.Services.AddScoped<StaffRepository>();
builder.Services.AddScoped<ClubRepo>();
// builder.Services.AddScoped<AddressRepo>();
builder.Services.AddScoped<FederationRepo>();

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
  //  app.MapOpenApi();
    app.UseCors("DevCors");
}
else
{
    app.UseHttpsRedirection();
    app.UseCors("ProdCors");
}
app.MapControllers(); 
app.Run();

