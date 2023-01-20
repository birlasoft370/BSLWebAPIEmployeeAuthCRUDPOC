using CommandHandler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;
using RepositoryHandler.JsonFile;
using RepositoryHandler.MsSql.EF;
using RepositoryHandler.MsSql.EF.User;
using System.Reflection;

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
builder.Services.AddAutoMapper(typeof(QueryHandler.GetAllEmployee.EmployeQueryHandler).GetTypeInfo().Assembly);


builder.Services.AddMediatR(typeof(QueryHandler.GetAllEmployee.EmployeQueryHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(AddEmployeeCommandHandler).GetTypeInfo().Assembly);

builder.Services.AddTransient<IGetEmployees, GetEmployees>();
builder.Services.AddTransient<IGetEmployeeById, GetEmployeeById>();

builder.Services.AddTransient<IAddEmployee, AddEmployee>();
builder.Services.AddTransient<IUpdateEmployee, UpdateEmployee>();
builder.Services.AddTransient<IDeleteEmployee, DeleteEmployee>();
builder.Services.AddTransient<IEmployeeOperation, EmployeejsonFileOperation>();//   EmployeeOperation

//Users
builder.Services.AddTransient<IValidateUser, ValidateUser>();
builder.Services.AddTransient<IUserOperation,UserjsonFileOperation>();//    UserOperation

builder.Services.AddTransient<IGetUser, GetUser>();
builder.Services.AddTransient<IGetUserById, GetUserById>();

builder.Services.AddTransient<IAddUser, AddUser>();
builder.Services.AddTransient<IUpdateUser, UpdateUser>();
builder.Services.AddTransient<IDeleteUser, DeleteUser>();

//Department
builder.Services.AddTransient<IDepartmentOperation, DepartmentJsonFileOperation>(); //DepartmentOperation

builder.Services.AddTransient<IGetDepartments, GetDepartments>();
builder.Services.AddTransient<IGetDepartmentById, GetDepartmentById>();

builder.Services.AddTransient<IAddDepartment, AddDepartment>();
builder.Services.AddTransient<IUpdateDepartment, UpdateDepartment>();
builder.Services.AddTransient<IDeleteDepartment, DeleteDepartment>();


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
