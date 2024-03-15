using CodeBE_TEL.Models;
using CodeBE_TEL.Repositories;
using CodeBE_TEL.Services.BoardService;
using CodeBE_TEL.Services.ClassEventService;
using CodeBE_TEL.Services.ClassroomService;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3001");
            policy.WithMethods("POST", "PUT", "DELETE");
            policy.WithHeaders("Content-Type");
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IBoardValidator, BoardValidator>();
builder.Services.AddScoped<IClassroomService, ClassroomService>();
builder.Services.AddScoped<IClassroomValidator, ClassroomValidator>();
builder.Services.AddScoped<IClassEventService, ClassEventService>();
builder.Services.AddScoped<IClassEventValidator, ClassEventValidator>();
builder.Services.AddScoped<IUOW, UOW>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

