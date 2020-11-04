using Dummy.DataAccess.Repository;
using MongoDB.Driver;
using MongoDbGenericRepository;
using System.Collections.Generic;

namespace Dummy.DataAccess.MongoDB.Repository
{
    public class DummiesRepository : IDummiesRepository
    {
        private readonly IMongoDbContext context;

        public DummiesRepository(IMongoRepository context)
        {
            this.context = context.GetContext();
        }
        public Model.Dummy Create(Model.Dummy dummy)
        {
            context.GetCollection<Model.Dummy>().InsertOne(dummy);

            return dummy;
        }

        public bool Delete(string id)
        {
            var filter = Builders<Model.Dummy>.Filter.Eq("_id", id);

            var result = context.GetCollection<Model.Dummy>().DeleteOne(filter);

            return result.IsAcknowledged;
        }

        public List<Model.Dummy> GetDummies()
        {
            return context.GetCollection<Model.Dummy>().AsQueryable().ToList();
        }

        public Model.Dummy GetDummyById(string id)
        {
            var filter = Builders<Model.Dummy>.Filter.Eq("_id", id);
            return context.GetCollection<Model.Dummy>().Find(filter).FirstOrDefault();
        }

        public Model.Dummy UpdateById(Model.Dummy dummy)
        {
            var filter = Builders<Model.Dummy>.Filter.Eq("_id", dummy.Id);
            var original = context.GetCollection<Model.Dummy>().Find(filter).FirstOrDefault();
            if (original != null)
            {
                var options = new FindOneAndReplaceOptions<Model.Dummy, Model.Dummy> { ReturnDocument = ReturnDocument.After };

                original = context.GetCollection<Model.Dummy>().FindOneAndReplace(filter, dummy, options);
            }
            return original;
        }
    }
}
