using CqrsMediatRDemo.Application.Commands.Orders.CreateOrder;
using CqrsMediatRDemo.Application.Interfaces;
using CqrsMediatRDemo.Infrastructure.Persistence.Mock;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add MediatR
// typeof(CreateOrderCommand).Assembly tells MediatR where to scan for handlers
builder.Services.AddMediatR(typeof(CreateOrderCommand).Assembly);

// Register the repository service (mock for now)
builder.Services.AddSingleton<IOrderRepository, MockOrderRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable routing and controller mapping
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
