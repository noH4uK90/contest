using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var app = builder.Build();
ConfigureApp(app);
await app.RunAsync();

void RegisterServices(IServiceCollection service)
{
    service.AddDbContext<PassDbContext>();
    service.AddControllers();
    service.AddEndpointsApiExplorer();
    service.AddSwaggerGen();
}

void ConfigureApp(WebApplication application)
{
    if (application.Environment.IsDevelopment())
    {
        application.UseSwagger();
        application.UseSwaggerUI();
    }
    
    application.UseHttpsRedirection();
    application.UseAuthorization();
    application.MapControllers();
}