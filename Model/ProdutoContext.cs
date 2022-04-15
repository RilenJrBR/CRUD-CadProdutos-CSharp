using Microsoft.EntityFrameworkCore;

namespace cadProdutos.Models{
    public class ProdutoContext : DbContext{
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<ProdutoContext> Produto { get; set; } = null!;
    }
}