using JJMasterData.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod().
        AllowAnyHeader();
    });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJJMasterDataWeb();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("DevCorsPolicy");
//app.UseHttpsRedirection();

//JJMasterData
app.UseJJMasterDataWeb();
app.MapJJMasterData();

app.UseAuthorization();

app.MapControllers();

app.Run();
