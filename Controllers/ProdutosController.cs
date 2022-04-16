using Microsoft.AspNetCore.Mvc;
using cadProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace cadProdutos.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase{

    private readonly ProdutoContext _context;

    public ProdutosController(ProdutoContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> cadastrar(Produto produtos)
    {
        _context.Produto.Add(produtos);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduto), new { id = produtos.Id }, produtos);
    }

    
}
