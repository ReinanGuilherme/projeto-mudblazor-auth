using MudblazorAuth.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Dependecy Injection Extension
builder.Services.AddInfrastructure(builder.Configuration);

// add config cors
builder.Services.AddCors(option =>
{
	option.AddPolicy("CorsPolicy", builder =>
	{
		builder.
		AllowAnyOrigin().
		AllowAnyMethod().
		AllowAnyHeader();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// add config cors
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();