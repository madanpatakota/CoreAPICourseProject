using CoreAPI.Data;
using CoreAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IRegionReposity rep = new RegionRepository();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();

//IWalkRepository walk = new WalkRepository(null, "test", 0);
builder.Services.AddScoped<IWalkRepository, WalkRepository>();

//Access to XMLHttpRequest at 'https://localhost:7078/api/Test/GetStudents' from origin 'http://localhost:4200' has been blocked by CORS policy: No 'Access-Control-Allow-Origin' header is present on the requested resource.
//code setup .. allow localhost:4200 request or allow any kind of origin 



//check the user tokens


//you are allowing all the origins . so any origin can access your endpoint now.
builder.Services.AddCors(options =>
{
    //AllowAllOrigins
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


builder.Services.AddDbContext<ProWalksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProWalks"));
});


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

//route to controllers
app.MapControllers();



app.Run();
