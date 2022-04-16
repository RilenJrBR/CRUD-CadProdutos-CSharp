using Microsoft.AspNetCore.Mvc;
using cadProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace cadProdutos.Controllers;

#region snippet_Route
[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
#endregion
{

    private readonly ProdutoContext _context;

    public ProdutosController(ProdutoContext context){
        _context = context;
    }    

    [HttpPost]
    public async Task<ActionResult<Produto>> cadastrar(Produto produtos){
        _context.Produtos.Add(produtos);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProdutos), new { id = produtos.Id }, produtos);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos(){
        return await _context.Produtos.ToListAsync();
    }
}
