using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaStore API", Description = "Making the Pizzas you love", Version = "v1" });
});

var app = builder.Build();

if(app.Environment.IsDevelopment()){

    app.UseSwagger();
    app.UseSwaggerUI(c=>{
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });    
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/products", () => "data");
app.MapGet("/products/{id}", (int id) =>  "id : "+id);
app.MapPost("/product/create",( ) => {});
app.MapPut("/product/",()=>{});
app.MapDelete("/product/{id}",(int id)=>{});
app.Run();
