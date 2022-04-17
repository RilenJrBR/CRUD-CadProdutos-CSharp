using Microsoft.EntityFrameworkCore;
using cadProdutos.Models;
using System.Configuration;

public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc();

             services.AddEntityFrameworkNpgsql()
             .AddDbContext<ProdutoContext>(options => options.UseNpgsql(Configuration.GetConnectionString("produtosDB")));
        }