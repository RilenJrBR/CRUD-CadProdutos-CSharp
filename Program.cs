using Microsoft.EntityFrameworkCore;
using cadProdutos.Models;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddDbContext<ProdutoContext>(opt =>
    opt.UseInMemoryDatabase("ProdutoList"));


var app = builder.Build();

if (builder.Environment.IsDevelopment()){
    
    app.UseDeveloperExceptionPage();    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
