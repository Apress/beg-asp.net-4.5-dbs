using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FirstMongoDbProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoServer dbServer = MongoServer.Create();
            dbServer.Connect();

            MongoDatabase database = dbServer.GetDatabase("test");
            foreach (var doc in database["test"].FindAll())
            {
                Console.WriteLine(doc);
            }
            
            Console.ReadLine();
            dbServer.Disconnect();
        }
    }
}
