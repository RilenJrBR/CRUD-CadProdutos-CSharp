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

        public static void Salvar(Produto produtos)
        {
            var produtosExistente = Produto.listagem.Find(u => u.Id ==produtos.Id);
            if (produtosExistente != null)
            {
                produtosExistente.nome = produtos.nome;
            }
        }

        public static void Excluir(long Id)
        {
            var produtosExistente = Produto.listagem.Find(u => u.Id == Id);
            if (produtosExistente != null)
            {
                Produto.listagem.Remove(produtosExistente);
            }
        }

    }
}


