using Microsoft.AspNetCore.Mvc;
using cadProdutos.Models;

namespace cadProdutos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase{

[HttpPost]
public async Task<ActionResult<Produto>> cadastrar(Produto produtos)
{
    _context.TodoItems.Add(produtos);
    await _context.SaveChangesAsync();

    //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
    return CreatedAtAction(nameof(GetProduto), new { id = produtos.Id }, produtos);
}
}
