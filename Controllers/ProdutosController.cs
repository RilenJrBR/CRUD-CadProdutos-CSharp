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

    private bool ProdutoExists(long id)
    {
        return _context.Produtos.Any(e => e.Id == id);
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
    

    
    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(long id){
        var produtos = await _context.Produtos.FindAsync(id);

        if (produtos == null){
            return NotFound();
        }

        return produtos;
    }
    

    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(long id, Produto produtos){
        if (id != produtos.Id){
            return BadRequest();
        }

        _context.Entry(produtos).State = EntityState.Modified;

        try{
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException){
            if (!ProdutoExists(id))
            {
                return NotFound();
            }
            else{
                throw;
            }
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(long id)
    {
        var produtos = await _context.Produtos.FindAsync(id);
        if (produtos == null)
        {
            return NotFound();
        }

        _context.Produtos.Remove(produtos);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    
}
