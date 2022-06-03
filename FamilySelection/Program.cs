using FamilySelection.Domain.Entities;
using FamilySelection.Infra.Data.Context;
using FamilySelection.Infra.Data.Interfaces;
using FamilySelection.Infra.Data.Repositories;
using FamilySelection.Service.Common.Interfaces;
using FamilySelection.Service.Common.Services;
using FamilySelection.Service.Common.Services.PontuationRules;
using FamilySelection.Service.Validator.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<FamilySelectionDataContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("ApiConection"));
});


ConfigureRepositories(builder.Services);
ConfigureValidators(builder.Services);
ConfigureBusinessServices(builder.Services);

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

void ConfigureRepositories(IServiceCollection services)
{
    services.AddScoped<IPersonRepository, PersonRepository>();
    services.AddScoped<IFamilyRepository, FamilyRepository>();
}

void ConfigureValidators(IServiceCollection services)
{
    services.AddScoped<IValidator<Person>, PersonValidator>();
    services.AddScoped<IValidator<Family>, FamilyValidator>();
}

void ConfigureBusinessServices(IServiceCollection services)
{
    services.AddScoped<IPersonService, PersonService>();
    services.AddScoped<IFamilyService, FamilyService>();
    services.AddScoped<IPontuationService, PontuationService>(); 
    services.AddTransient<IPontuationRule, Over3DependentsRule>();
    services.AddTransient<IPontuationRule, Over900Under1500Rule>();
    services.AddTransient<IPontuationRule, Under3DependentsRule>();
    services.AddTransient<IPontuationRule, Under900Rule>();
}
