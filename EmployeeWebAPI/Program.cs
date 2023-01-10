using AutoMapper;
using CommandHandler;
using EmployeeWebAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;
using RepositoryHandler.JsonFile;
using RepositoryHandler.MsSql.EF;
using System.Reflection;
using static QueryHandler.GetAllEmployee;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection"));
});

//builder.Services.AddTransient<IEmployeeRepository, SQLEmployeeRepository>();
//builder.Services.AddTransient<IUsersRepository, UsersRepository>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(EmployeQueryHandler).GetTypeInfo().Assembly);


builder.Services.AddMediatR(typeof(EmployeQueryHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(AddEmployeeCommandHandler).GetTypeInfo().Assembly);

builder.Services.AddTransient<IGetEmployees, GetEmployees>();
builder.Services.AddTransient<IGetEmployeeById, GetEmployeeById>();

builder.Services.AddTransient<IAddEmployee, AddEmployee>();
builder.Services.AddTransient<IUpdateEmployee, UpdateEmployee>();
builder.Services.AddTransient<IDeleteEmployee, DeleteEmployee>();

builder.Services.AddTransient<IEmployeeOperation, EmployeejsonFileOperation>();//  EmployeeOperation

//Users
builder.Services.AddTransient<IValidateUser, ValidateUser>();
builder.Services.AddTransient<IuserOperation, UserjsonFileOperation>();//  UserOperation

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
