using Hangfire;
using InterestAndChargesService.API.ExceptionMiddlerware;
using InterestAndChargesService.Application.Interface;
using InterestAndChargesService.Application.Mapper;
using InterestAndChargesService.Application.Services;
using InterestAndChargesService.Infrastructure.Data;
using InterestAndChargesService.Infrastructure.ExternalServices;
using InterestAndChargesService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<IInterestAccrualRepo, InterestAccrualRepo>();
builder.Services.AddScoped<IInterestAccrualService, InterestAccrualService>();
builder.Services.AddScoped<IPenaltyRepo, PenaltyRepo>();
builder.Services.AddScoped<IPenaltyService, PenaltyService>();
builder.Services.AddScoped<PenaltyJobService>();
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddHttpClient<ILoanAccountClientService,LoanAccountClientService>(client=>
client.BaseAddress=new Uri("https://loanledgerservice-cnbngdcjgcc9ctgz.canadacentral-01.azurewebsites.net/api/"));
builder.Services.AddHttpClient<IEmiScheduleClientService, EmiScheduleClientService>(client =>
    client.BaseAddress = new Uri("https://emischedularservice-hjgrbxhkd3awecc5.canadacentral-01.azurewebsites.net/api/")
);

builder.Services.AddHangfire(options => options.UseSqlServerStorage(builder.Configuration.GetConnectionString("dbconn")));
builder.Services.AddHangfireServer();
var app = builder.Build();

app.UseHangfireDashboard("/hangfire");
RecurringJob.AddOrUpdate<PenaltyJobService>(
    "daily penalty",
     job => job.CalculatePenaltyAsync(),
    "00 08 * * *",
    TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")
    );

RecurringJob.AddOrUpdate<InterestAccrualJobService>(
    "daily interest accrual",
    job => job.CalculateInterestAccrual(),
    "00 08 * * *",
    TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")

    );


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
