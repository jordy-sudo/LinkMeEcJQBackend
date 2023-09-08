using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LinkMeEcJQ.Domain
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UPC")]
        public string UPC { get; set; }

        [BsonElement("prodName")]
        public string ProdName { get; set; }

        [BsonElement("mfgr")]
        public string Mfgr { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("unitListPrice")]
        public double UnitListPrice { get; set; }

        [BsonElement("unitInStock")]
        public int UnitInStock { get; set; }
    }
}
