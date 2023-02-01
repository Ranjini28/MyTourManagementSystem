using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyTourManagementAPI.DataAccessLayer;
using MyTourManagementAPI.IRepository;
using MyTourManagementAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/*builder.Services.AddDbContext<TourDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToursConn"));
}
);*/

builder.Services.AddDbContext<TourDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("ToursConn")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
