using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;


namespace TweetClassifier.v3
{
    public class Mongo
    {
        string connectionString; 
        MongoServer server;
        MongoDatabase database;
        MongoCollection<BsonDocument> collection;
        public MongoCursor<BsonDocument> cursor;

        public Mongo()
        {
            connectionString = "mongodb://localhost";
            server = MongoServer.Create(connectionString); //Connect to server
        }

        public void setDataBase(string s)
        {
            if (server.DatabaseExists(s))
                database = server.GetDatabase(s); //Get database that name is taken 
            else
                throw new Exception("Database does not exist.");
        }

        public void setCollection(string s)
        {
            if (database.CollectionExists(s))
                collection = database.GetCollection<BsonDocument>(s); //Get collection that name is taken 
            else
                throw new Exception("Collection does not exist.");
        }

        public void getAllData()
        {
            cursor = collection.FindAll();
        }
    }
}
