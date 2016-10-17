using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace QueryCollectionsWithLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoServer dbServer = MongoServer.Create();
            dbServer.Connect();

            MongoDatabase db = dbServer.GetDatabase("test");
            var collection = db.GetCollection("items").AsQueryable();

            var result = collection.FirstOrDefault();
            Console.WriteLine(result);
            dbServer.Disconnect();
            Console.ReadLine();
        }
    }
}