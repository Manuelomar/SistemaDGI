using DGI.API.Settings;

var builder = WebApplication.CreateBuilder(args);

var setup = new AppSetup(builder.Configuration);

setup.Configure(builder.Environment);

builder.Services.AddCors(option =>
{
    option.AddPolicy("devCors",
        builder => builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials());
});


setup.RegisterServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("devCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
