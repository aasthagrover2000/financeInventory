using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace financeInventoryProject.Models;

public class FinanceInventory
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("FinanceDetails")]
    public string? source { get; set; }
    public string? type { get; set; }
    public double principalAmount { get; set; }
    public double currentValue {get; set;}
}