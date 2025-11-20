using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services
{// a verifier le meaning ta3 task 
    public class PizzaService
    {
        private readonly IMongoCollection<Pizza> _pizzasCollection;

        public PizzaService(
            IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _pizzasCollection = mongoDatabase.GetCollection<Pizza>(bookStoreDatabaseSettings.Value.PizzaCollectionName);//entre les parenthese lazem tu definit le nom de la collection dans la base de donnes qui est un string et kayen 2 cas soit tktab string direct soit tu le definit dans appsettings PUIS DANS BookStoreSettings.cs
        }

        public async Task<List<Pizza>> GetPizzasAsync() =>
            await _pizzasCollection.Find(_ => true).ToListAsync();
        public async Task<Pizza> GetPizzaAsync(string id) =>
            await _pizzasCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreatePizzaAsync(Pizza pizza) =>
            await _pizzasCollection.InsertOneAsync(pizza);
        public async Task UpdatePizzaAsync(Pizza pizza, string id) =>
            await _pizzasCollection.ReplaceOneAsync(x => x.Id == id, pizza);
        public async Task DeletePizzaAsync(string id) =>
            await _pizzasCollection.DeleteOneAsync(x => x.Id == id);

    }
}