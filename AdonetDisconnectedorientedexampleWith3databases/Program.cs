using AdonetDisconnectedorientedexampleWith3databases.Data;
using AdonetDisconnectedorientedexampleWith3databases.Interfaces;
using AdonetDisconnectedorientedexampleWith3databases.Repositorys;
using AdonetDisconnectedorientedexampleWith3databases.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//dependency injection is a design pattern that allows us to achieve loose coupling between the different layers of an application.
//To implement the depency injection  we need to update the depencies here in the program.cs file of the web api project and we need to register the service and repository interfaces and their implementations in the dependency injection container of the application using the AddScoped method   builder object.
//to implement the dependec
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();//register the connection factory interface and its implementation in the dependency injection container of the application using the AddSingleton method   builder object. The AddSingleton method is used to register a service with a singleton lifetime, which means that a single instance of the service will be created and shared throughout the application's lifetime.

//we need to register for the Employee repository and order service also in the dependency injection container of the application using the AddScoped method   builder object.
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register the repository interface and its implementation in the dependency injection container of the application using the AddScoped method   builder object.
builder.Services.AddScoped<IEmployeeService, EmployeeService>();//register the service interface and its implementation in the dependency injection container of the application using the AddScoped method   builder object.


//we need to register for the department repository and order service also in the dependency injection container of the application using the AddScoped method   builder object.
builder.Services.AddScoped<IDepartmentRepository, DepertmentRepository>();//register the repository interface and its implementation in the dependency injection container of the application using the AddScoped method   builder object.
builder.Services.AddScoped<IDepartmentService, DepartmentServices>();//register the service interface and its implementation in the dependency injection container of the application using the AddScoped method   builder object.


//we need to register for the order repository and order service also in the dependency injection container of the application using the AddScoped method   builder object.
builder.Services.AddScoped<IOrderRepository, OrderRepository>();//register the repository interface and its implementation in the dependency injection container of the application using the AddScoped method   builder object.
builder.Services.AddScoped<IOrderService, OrderService>();//register the service interface and its implementation in the dependency injection container of the application using the AddScoped method   builder object.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
