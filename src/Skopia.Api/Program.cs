using Skopia.Infrastructure.Configuration;
using Skopia.Infrastructure.Persistence;
using Skopia.Infrastructure.Repositories.Mongo;
using Skopia.Core.Repositories;
using Skopia.Core.Services;
using Skopia.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

MongoMappings.Register();

// bind settings
var mongoSettings = new MongoSettings();
builder.Configuration.GetSection("Mongo").Bind(mongoSettings);
builder.Services.AddSingleton(mongoSettings);

// registrar MongoContext
builder.Services.AddSingleton<IMongoContext, MongoContext>();

// registrar repositórios Mongo
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// serviços de domínio (suas implementações permanecem)
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

