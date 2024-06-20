using System.Data.Common;
using Microsoft.OpenApi.Models;
using PizzaStore.Db;
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
app.MapGet("/products", () => PizzaDB.GetPizzas());
app.MapGet("/products/{id}", (int id) =>  PizzaDB.GetPizza(id));
app.MapPost("/product/create",(Pizza pizza) => PizzaDB.CreatePizza(pizza));
app.MapPut("/product/",(Pizza pizza)=> PizzaDB.UpdatePizza(pizza));
app.MapDelete("/product/{id}",(int id)=>PizzaDB.RemovePizza(id));
app.Run();
