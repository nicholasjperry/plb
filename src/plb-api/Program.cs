using plb_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<FirebaseAuthService>();

// Add other services.
builder.Services.AddControllers();
//builder.Services.AddDbContext();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Need?
// builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // TODO: Need?
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
