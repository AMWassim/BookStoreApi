using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppelController : ControllerBase
    {
        public AppelController() { }

        // GET: api/<PizzaController>
        [HttpGet]
        public IActionResult GetHello() {
            return Ok(3);
        }



    }
}
