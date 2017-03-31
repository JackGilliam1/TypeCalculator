using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TypeCalculator.Views;

namespace TypeCalculator.Core
{
    public class MongoDbDatabase : ITypeCalculatorDatabase
    {
        private readonly MongoDbSettings _settings;
        private readonly MongoDatabase _database;

        public MongoDbDatabase(MongoDbSettings settings)
        {
            _settings = settings;
            var client = new MongoClient(settings.Url);
            _database = client.GetServer().GetDatabase(_settings.DatabaseName);
        }

        public ElementTypeAttributes GetAttributesFor(string elementType)
        {
            var query = Query<ElementTypeAttributes>.EQ(x => x.ElementType, elementType);
            var collection = GetAttributesCollection();
            var attributes = collection.FindOne(query);
            if (attributes != null)
            {
                return attributes;
            }
            attributes = new ElementTypeAttributes
            {
                ElementType = elementType
            };
            collection.Insert(attributes);
            return attributes;
        }

        public void UpdateAttributes(ElementTypeAttributes attributes)
        {
            var collection = GetAttributesCollection();
            collection.Save(attributes);
        }

        private MongoCollection<ElementTypeAttributes> GetAttributesCollection()
        {
            var collection = _database.GetCollection<ElementTypeAttributes>(_settings.ElementAttributesCollectionName);
            return collection;
        }

        public void AddStat(string typeOne, string typeTwo, StatType stat)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTypesList(IList<string> types)
        {
            throw new System.NotImplementedException();
        }

        public IList<string> GetTypesList()
        {
            throw new System.NotImplementedException();
        }
    }
}