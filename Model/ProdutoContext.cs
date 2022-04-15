using Microsoft.EntityFrameworkCore;

namespace cadProdutos.Models{
    public class ProdutoContext : DbContext{
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; } = null!;
    }
}