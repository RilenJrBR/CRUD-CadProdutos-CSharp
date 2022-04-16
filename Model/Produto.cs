namespace cadProdutos.Models
{
    public class Produto{
        public long Id { get; set;}
            
        public string? nome { get; set; }

        public float valor { get; set; }

        public int quantEstoque { get; set; }

        private static List<Produto> listagem = new List<Produto>();
        public static IQueryable<Produto> Listagem
        { 
            get
            {
                return listagem.AsQueryable();
            }
        }

        

    }
}


