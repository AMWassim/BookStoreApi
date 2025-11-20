using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookStoreApi.Models
{
    public class Pizza
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = null!; // les strings lazem t9ol bli not null || lazem tfham hade les anotation chewia weird ta3 ! ?
        public bool IsDispo { get; set; } // askip lazem ikounou majiscule 
        public decimal Price { get; set; }
    }
}
