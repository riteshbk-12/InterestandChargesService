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
client.BaseAddress=new Uri("https://loanaccountservice-e2d2dpg8ccc7gjfk.canadacentral-01.azurewebsites.net/api/"));
builder.Services.AddHttpClient<IEmiScheduleClientService, EmiScheduleClientService>(client =>
    client.BaseAddress = new Uri("https://emischedulingservice-djd3dwabewc0epac.canadacentral-01.azurewebsites.net/api/")
);

builder.Services.AddHangfire(options => options.UseSqlServerStorage(builder.Configuration.GetConnectionString("dbconn")));
builder.Services.AddHangfireServer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200") // Angular dev URL
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new AllowAllDashboardAuthorizationFilter() }
});
RecurringJob.AddOrUpdate<PenaltyJobService>(
    "daily penalty",
     job => job.CalculatePenaltyAsync(),
    "45 11 * * *",
    TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")
    );

RecurringJob.AddOrUpdate<InterestAccrualJobService>(
    "daily interest accrual",
    job => job.CalculateInterestAccrual(),
    "54 14 * * *",
    TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")

    );


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularDev");
app.UseAuthorization();

app.MapControllers();

app.Run();
