using Backends.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);

builder.Services.AddScoped<ITareaRepository, TareaRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyOrigin",
        policy =>
        {
            policy.AllowAnyOrigin() // Agrega los orígenes permitidos
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseCors("MyOrigin"); // Habilita CORS con la política "MyOrigin"

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();