using MediatR;
using Microsoft.EntityFrameworkCore;
using StockApi.ApplicationServices.API.Domain;
using StockApi.ApplicationServices.Mappings;
using StockAPI.DataAccess;
using StockAPI.DataAccess.CQRS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IQuerryExecutor, QuerryExecutor>();
builder.Services.AddAutoMapper(typeof(ItemsProfile).Assembly);
builder.Services.AddMediatR(typeof(ResponseBase<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<StockApiStorageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockApiDatabaseConnection")));
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
