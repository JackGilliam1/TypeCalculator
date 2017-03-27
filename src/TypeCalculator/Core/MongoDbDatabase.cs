using MongoDB.Driver;
using MongoDB.Driver.Builders;

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

        public ElementTypeAttributes GetAttributesFor(ElementType elementType)
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
    }
}