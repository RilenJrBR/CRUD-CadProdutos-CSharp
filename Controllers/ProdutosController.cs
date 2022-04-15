using Microsoft.AspNetCore.Mvc;
using cadProdutos.Models;

namespace cadProdutos.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase{
    

    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto){
        
        _context.Produto.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }    
}
