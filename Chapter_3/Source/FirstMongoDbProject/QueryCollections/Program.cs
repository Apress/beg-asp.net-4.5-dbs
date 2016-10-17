using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace QueryCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoServer dbServer = MongoServer.Create();
            dbServer.Connect();

            MongoDatabase db = dbServer.GetDatabase("test");
            if (db.GetCollection("items") == null)
            {
                db.CreateCollection("items");
                BsonDocument document = new BsonDocument
                {
                    {"SKU", "I001"},
                    {"Variant", "Tubes"},
                    {"Quantity", "10"},
                    {"Cost", "150.50"}
                };

                db["items"].Insert<BsonDocument>(document);
            }
            Console.WriteLine(db["items"].FindOne());
            dbServer.Disconnect();
            Console.ReadLine();
        }
    }
}
