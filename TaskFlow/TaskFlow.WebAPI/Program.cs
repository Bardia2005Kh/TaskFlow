using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.AutoMapperProfiles;
using TaskFlow.Application.IRepository;
using TaskFlow.Infra.Data;
using TaskFlow.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injecting DbContext
builder.Services.AddDbContext<TaskFlowDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Injecting Repository Interfaces
builder.Services.AddScoped<ITaskRepository, TaskItemRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// Injecting AutoMapper
builder.Services.AddAutoMapper(typeof(Profiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
