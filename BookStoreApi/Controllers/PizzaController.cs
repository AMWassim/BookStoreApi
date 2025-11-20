using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _pizzaService;
        public PizzaController(PizzaService pizzaService) =>
          _pizzaService = pizzaService;

        // GET: api/<PizzaController>
        [HttpGet]
        public async Task<List<Pizza>> GetPizzas()=>
            await _pizzaService.GetPizzasAsync();

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(string id)
        {
            var pizza= await _pizzaService.GetPizzaAsync(id);
            if(pizza == null)
            {
                return NotFound(); // voir les autres choses dispo ASKIP kayen ghir howa ou NoContent()
            }
            return pizza;
        }

        // POST api/<PizzaController>
        [HttpPost]
        public async Task<IActionResult> CreatePizza(Pizza pizza) // IActionResult a comprendre 
        {
            await _pizzaService.CreatePizzaAsync(pizza);
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza); // a comprendre
            
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedPizza(string id, Pizza updatedPizza)
        {
            var pizza = await _pizzaService.GetPizzaAsync(id);
            if(pizza == null)
            {
                return NotFound();
            }
            updatedPizza.Id = pizza.Id;
            return NoContent();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletePizza(string id)
        {
            var pizza = await _pizzaService.GetPizzaAsync(id);
            if (pizza == null) return NotFound();
            await _pizzaService.DeletePizzaAsync(id);
            return id;
        }
    }
}
